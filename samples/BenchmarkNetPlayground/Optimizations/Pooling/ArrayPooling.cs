namespace BenchmarkNetPlayground.Optimizations.Pooling
{
    using BenchmarkDotNet.Attributes;

    using PatternsAndConcepts.DummyModels;
    using PatternsAndConcepts.Services;

    using System.Buffers;

    public class ArrayPooling
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
}
