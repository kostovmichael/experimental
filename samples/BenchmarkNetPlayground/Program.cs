
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    using Configs;

    public class Program
    {
        static void Main(string[] args)
        {

            //Dictionary Benchmarks
            BenchmarkRunner.Run<Optimizations
                .DictionaryWithOrWithoutSupplyingInitialCount>(
                ManualConfigs.GetManualConfig_Net472_CoreRt31_X86());

            //Compiler Inlining Benchmarks
            //BenchmarkRunner.Run<Optimizations.Inlining>();
        }

    }
}
