
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    using BenchmarkNetPlayground.Services;

    using Configs;

    using Optimizations;
    using Optimizations.Loops;

    using System;

    public class Program
    {
        static void Main(string[] args)
        {


            #region "For loops"

            //BenchmarkRunner.Run<ForLoopTesting.ForVsForEach>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());

            #endregion "For loops"


            #region "Dictionary Benchmarks"

            BenchmarkRunner.Run<DictionaryConcreteVsInterface>(
              ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());

            //BenchmarkRunner.Run<Optimizations.DictionaryWithOrWithoutSupplyingInitialCount>(
            //    ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());


            #endregion "Dictionary Benchmarks"

            // Memory Benchmarks
            //BenchmarkRunner.Run<IntroNativeMemory>();

            // Compiler Inlining Benchmarks
            //BenchmarkRunner.Run<Optimizations.Inlining>();
        }



    }
}
