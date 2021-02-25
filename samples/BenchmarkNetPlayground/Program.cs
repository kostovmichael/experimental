
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    using BenchmarkNetPlayground.Optimizations.Uncommon;
    using BenchmarkNetPlayground.Services;

    using Configs;

    using Microsoft.Extensions.Primitives;

    using Optimizations;
    using Optimizations.Loops;

    using ScratchPad;

    using System;

    public class Program
    {
        static void Main(string[] args)
        {



            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);


            #region "Value vs Ref Types"

            //BenchmarkRunner.Run<RefAllocation>();

            #endregion "Value vs Ref Types"



            #region "For loops"

            BenchmarkRunner.Run<Optimizations.Loops.ForLoopTesting.ForVsForEach>();
            //(ManualConfigurations.GetManualConfig_Default_Job());

            #endregion "For loops"


            #region "Dictionary Benchmarks"

            //BenchmarkRunner.Run<DictionaryConcreteVsInterface>(
            //  ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());

            //BenchmarkRunner.Run<Optimizations.DictionaryWithOrWithoutSupplyingInitialCount>(
            //    ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64_backup());


            #endregion "Dictionary Benchmarks"

            // Memory Benchmarks
            //BenchmarkRunner.Run<IntroNativeMemory>();

            // Compiler Inlining Benchmarks
            //BenchmarkRunner.Run<Optimizations.Inlining>();



            #region "Sorting"

            //BenchmarkRunner.Run<SortingArraysUsingSpan.DoubleSorting>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64());
            //BenchmarkRunner.Run<SortingArraysUsingSpan.Int32Sorting>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64());
            //BenchmarkRunner.Run<SortingArraysUsingSpan.StringSorting>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64());

            #endregion "Sorting"

        }

    }
}
