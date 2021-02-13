
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    using Configs;

    using Optimizations.Loops;

    using System;

    public class Program
    {
        static void Main(string[] args)
        {


            #region "For loops"

            BenchmarkRunner.Run<ForLoopTesting.ForVsForEach>();//ManualConfigurations.GetManualConfig_CoreRt31_64());

            #endregion "For loops"


            #region "Dictionary Benchmarks"

            // Dictionary Benchmarks


            //BenchmarkRunner.Run<DictionaryConcreteVsInterface>(
            //  ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());

            //BenchmarkRunner.Run<Optimizations
            //    .DictionaryWithOrWithoutSupplyingInitialCount>(
            //    ManualConfigurations.GetManualConfig_Net472_CoreRt31_X86());


            #endregion "Dictionary Benchmarks"

            // Memory Benchmarks
            //BenchmarkRunner.Run<IntroNativeMemory>();

            // Compiler Inlining Benchmarks
            //BenchmarkRunner.Run<Optimizations.Inlining>();
        }



    }
}
