
namespace BenchmarkNetPlayground
{

    using BenchmarkDotNet.Running;

    using BenchmarkNetPlayground.Configs;

    using Optimizations.Loops;

    public class Program
    {
        static void Main(string[] args)
        {


            BenchmarkRunner.Run<ForLoopTesting.ForVsForEach>(
                ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());


            //Dictionary Benchmarks


            //BenchmarkRunner.Run<DictionaryConcreteVsInterface>(
            //ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());

            //BenchmarkRunner.Run<Optimizations
            //    .DictionaryWithOrWithoutSupplyingInitialCount>(
            //    ManualConfigurations.GetManualConfig_Net472_CoreRt31_X86());

            //BenchmarkRunner.Run<IntroNativeMemory>();

            //Compiler Inlining Benchmarks
            //BenchmarkRunner.Run<Optimizations.Inlining>();
        }



    }
}
