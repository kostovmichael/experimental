
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    using BenchmarkNetPlayground.Optimizations.Uncommon;
    using BenchmarkNetPlayground.Services;

    using Configs;

    using Microsoft.Extensions.Primitives;

    using Optimizations;
    using Optimizations.Loops;
    using Optimizations.Memory;
    using Optimizations.Pooling;

    using ScratchPad;

    using System;
    using System.Collections.Generic;

    using static BenchmarkNetPlayground.Optimizations.Collections.Lists;

    public class Program
    {
        static void Main(string[] args)
        {
            //ArrayPooling
            //RunForLoopBenchmarks();


            //BenchmarkRunner.Run<ArrayPooling>
            //    (ManualConfigurations.GetManualConfig_Default_Job());
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);


            #region "String Search"

            //   BenchmarkRunner.Run<Optimizations.Strings.StringSearch.TrieVsDictionary>
            //(ManualConfigurations.GetManualConfig_Default_Job());

            #endregion "String Search"

            #region "Value vs Ref Types"

            //BenchmarkRunner.Run<RefAllocation>();

            #endregion "Value vs Ref Types"



            #region "For loops"




            #endregion "For loops"


            #region "Dictionary Benchmarks"

            //BenchmarkRunner.Run<DictionaryConcreteVsInterface>(
            //  ManualConfigurations.GetManualConfig_Net472_CoreRt31_64());

            //BenchmarkRunner.Run<Optimizations.DictionaryWithOrWithoutSupplyingInitialCount>(
            //    ManualConfigurations.GetManualConfig_Default_Job());


            #endregion "Dictionary Benchmarks"

            // Memory Benchmarks
            //BenchmarkRunner.Run<IntroNativeMemory>();
            //var t1 = new StringAllocations.SingleStringVsChunks();
            //var singleString = t1.GetSingleString();
            //var array = t1.GetListOfStrings();
            //Console.WriteLine(array[0]);

            //Console.WriteLine(array[1]);
            //BenchmarkRunner.Run<StringAllocations.SingleStringVsChunks>();
            // Compiler Inlining Benchmarks
            //BenchmarkRunner.Run<Optimizations.Inlining>();



            #region "Sorting"

            //BenchmarkRunner.Run<SortingArraysUsingSpan.DoubleSorting>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64());
            //BenchmarkRunner.Run<SortingArraysUsingSpan.Int32Sorting>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64());
            //BenchmarkRunner.Run<SortingArraysUsingSpan.StringSorting>(ManualConfigurations.GetManualConfig_Net472_CoreRt31_DotNet50_64());

            #endregion "Sorting"

        }
        #region "For loops"

        static void RunForLoopBenchmarks()
        {
            //Runs benchmarks against array of ref types

            //BenchmarkRunner.Run<Optimizations.Loops.ForLoops.ForVsForEach>
            //   (ManualConfigurations.GetManualConfig_Default_Job());

            BenchmarkRunner.Run<ListWithOrWithoutSupplyingInitialCount>
                  (ManualConfigurations.GetManualConfig_Default_Job());


            ////Runs benchmarks against aray of value types with sequential layout
            //BenchmarkRunner.Run<Optimizations.Loops.ForLoops.ForVsForEachUsingStructLayoutSequential>
            //    (ManualConfigurations.GetManualConfig_Default_Job());


            ////Runs benchmarks against aray of value types vs ref types

            //BenchmarkRunner.Run<Optimizations.Loops.ForLoops.ForVsForEachClassVsSequentialStruct>
            //    (ManualConfigurations.GetManualConfig_Default_Job());
        }

        #endregion "For loops"

    }
}
