namespace BenchmarkNetPlayground.Optimizations.Pooling
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Engines;
    using BenchmarkDotNet.Jobs;

    using PatternsAndConcepts.DummyModels;
    using PatternsAndConcepts.Services;

    using System.Buffers;

    public class ArrayPooling
    {
        [MemoryDiagnoser]
        [Config(typeof(DontForceGcCollectionsConfig))] // we don't want to interfere with GC, we want to include it's impact
        public class ArrayPoolOfStructs
        {
            private string[] arrayOfStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
            }

            [Benchmark]
            public long ArrayWithoutPool()
            {
                int upperBound = arrayOfStrings.Length;
                ProductStruct[] data = new ProductStruct[upperBound];
                long result = 0;
                for (int i = 0; i < upperBound; ++i)
                {
                    data[i] = new ProductStruct()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i],
                        ManufacturerId = i + 10
                    };
                }
                result = ProcessData(ref data);
                return result;
            }
            [Benchmark]
            public long ArrayUsingPool()
            {
                int upperBound = arrayOfStrings.Length;
                ProductStruct[] data = ArrayPool<ProductStruct>.Shared.Rent(upperBound);
                long result = 0;
                for (int i = 0; i < upperBound; ++i)
                {
                    data[i] = new ProductStruct()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i],
                        ManufacturerId = i + 10
                    };
                }
                result = ProcessData(ref data);
                ArrayPool<ProductStruct>.Shared.Return(data);
                return result;
            }

            private long ProcessData(ref ProductStruct[] data)
            {
                long result = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    result += data[i].Id;
                }
                return result;
            }
        }
        //https://adamsitnik.com/Array-Pool/
        [MemoryDiagnoser]
        [Config(typeof(DontForceGcCollectionsConfig))] // we don't want to interfere with GC, we want to include it's impact
        public class ArrayPoolOfBytes
        {
            [Params((int)1E+2, // 100 bytes
                (int)1E+3, // 1 000 bytes = 1 KB
                (int)1E+4, // 10 000 bytes = 10 KB
                (int)1E+5, // 100 000 bytes = 100 KB
                (int)1E+6, // 1 000 000 bytes = 1 MB
                (int)1E+7)] // 10 000 000 bytes = 10 MB
            public int SizeInBytes { get; set; }

            private ArrayPool<byte> sizeAwarePool;

            [GlobalSetup]
            public void GlobalSetup()
                => sizeAwarePool = ArrayPool<byte>.Create(SizeInBytes + 1, 10); // let's create the pool that knows the real max size

            [Benchmark]
            public void Allocate()
                => DeadCodeEliminationHelper.KeepAliveWithoutBoxing(new byte[SizeInBytes]);

            [Benchmark]
            public void RentAndReturn_Shared()
            {
                var pool = ArrayPool<byte>.Shared;
                byte[] array = pool.Rent(SizeInBytes);
                pool.Return(array);
            }

            [Benchmark]
            public void RentAndReturn_Aware()
            {
                var pool = sizeAwarePool;
                byte[] array = pool.Rent(SizeInBytes);
                pool.Return(array);
            }
        }


    }
    public class DontForceGcCollectionsConfig : ManualConfig
    {
        public DontForceGcCollectionsConfig()
        {
            AddJob(Job.Default
                .WithGcMode(new GcMode()
                {
                    Force = false // tell BenchmarkDotNet not to force GC collections after every iteration
                }));
        }
    }
}
