namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Environments;
    using BenchmarkDotNet.Jobs;

    using System.Runtime.CompilerServices;

    [Config(typeof(Config))]
    [MemoryDiagnoser]
    public class RefAllocation
    {

        private const int forLoopIterationsCount = 1000000;
        private class Config : ManualConfig
        {
            public Config()
            {
                AddJob(Job.Default
                        .WithPlatform(Platform.X64)
                        .WithJit(Jit.RyuJit)

                );
            }
        }

        public struct Value
        {
            public long A;
            public long B;
            public long C;
            public long D;
        }

        public class Reference
        {
            public long A;
            public long B;
            public long C;
            public long D;
        }


        [Benchmark]
        public long StackByRef()
        {
            long result = 0;
            Value output = default(Value);
            for (long i = 0; i < forLoopIterationsCount; i++)
            {
                WorkByRef(i, ref output);
                result += output.A;
            }
            return result;
        }

        [Benchmark]
        public long StackByValue()
        {
            long result = 0;
            for (int i = 0; i < forLoopIterationsCount; i++)
            {
                result += WorkByValue(i).A;
            }
            return result;
        }

        [Benchmark]
        public long HeapByConstruction()
        {
            long result = 0;
            for (int i = 0; i < forLoopIterationsCount; i++)
            {
                result += WorkByHeapConstruction(i).A;
            }
            return result;
        }

        [Benchmark]
        public long HeapByReuse()
        {
            long result = 0;
            var output = new Reference();
            for (int i = 0; i < forLoopIterationsCount; i++)
            {
                WorkByHeapReuse(i, output);
                result += output.A;
            }
            return result;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private void WorkByRef(long i, ref Value output)
        {
            output.A = i;
            output.B = i;
            output.C = i;
            output.D = i;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private Value WorkByValue(int i)
        {
            return new Value { A = i, B = i, C = i, D = i };
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private Reference WorkByHeapConstruction(int i)
        {
            return new Reference { A = i, B = i, C = i, D = i };
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private void WorkByHeapReuse(long i, Reference output)
        {
            output.A = i;
            output.B = i;
            output.C = i;
            output.D = i;
        }


    }
}
