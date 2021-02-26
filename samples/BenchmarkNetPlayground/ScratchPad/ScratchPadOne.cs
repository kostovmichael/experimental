namespace BenchmarkNetPlayground.ScratchPad
{
    using BenchmarkDotNet.Running;

    using BenchmarkNetPlayground.Optimizations.Uncommon;
    using BenchmarkNetPlayground.Services;

    using Configs;

    using Microsoft.Extensions.Primitives;

    using Optimizations;
    using Optimizations.Collections;
    using Optimizations.Loops;
    using Optimizations.Memory;
    using Optimizations.Pooling;

    using ScratchPad;

    using System;
    using System;
    using System.Collections.Generic;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using static BenchmarkNetPlayground.Optimizations.Collections.Lists;

    public class ScratchPadOne
    {

        public void GetCharSize()
        {
            var marshalSizeOfChar = System.Runtime.InteropServices.Marshal.SizeOf(typeof(char));

            var sizeOfChar = sizeof(char);

            var sizeOfInte = sizeof(int);
        }


        public static void BenchmarkSnippets()
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

        static void RunForLoopBenchmarks()
        {
            //Runs benchmarks against array of ref types

            //BenchmarkRunner.Run<Optimizations.Loops.ForLoops.ForVsForEach>
            //   (ManualConfigurations.GetManualConfig_Default_Job());

            BenchmarkRunner.Run<Lists.ListWithOrWithoutSupplyingInitialCount>
                (ManualConfigurations.GetManualConfig_Default_Job());


            ////Runs benchmarks against aray of value types with sequential layout
            //BenchmarkRunner.Run<Optimizations.Loops.ForLoops.ForVsForEachUsingStructLayoutSequential>
            //    (ManualConfigurations.GetManualConfig_Default_Job());


            ////Runs benchmarks against aray of value types vs ref types

            //BenchmarkRunner.Run<Optimizations.Loops.ForLoops.ForVsForEachClassVsSequentialStruct>
            //    (ManualConfigurations.GetManualConfig_Default_Job());
        }

        public void TestLargeStringArray()
        {
            //var arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();

            //Console.WriteLine("Total words count: " + arrayOfStrings.Length.ToString());


            //var test = new ForLoopTesting.ForVsForEach();
            //test.GlobalSetup();

            //var dict1 = test.ForLoop();
            //Console.WriteLine("Total words count ForLoop: " + dict1.Count.ToString());

            //var dict2 = test.ForEach();
            //Console.WriteLine("Total words count ForEach: " + dict2.Count.ToString());

            //var dict3 = test.ForEachWithLambda();
            //Console.WriteLine("Total words count ForEachWithLambda: " + dict3.Count.ToString());

        }

        public static void Test_IsValueWriteAtomic()
        {
            int testInt32 = 100;
            string testString = "abc";

            StringValues stringValues = new StringValues(testString);
            //ReadOnlySpan<char> spanFromString = testString.AsSpan();

            Console.WriteLine($"IsValueWriteAtomic {testInt32.GetType().ToString()} : {ScratchPadOne.IsValueWriteAtomic(testInt32).ToString()}");
            Console.WriteLine($"IsValueWriteAtomic {testString.GetType().ToString()} : {ScratchPadOne.IsValueWriteAtomic(testString).ToString()}");
            Console.WriteLine($"IsValueWriteAtomic {stringValues.GetType().ToString()} : {ScratchPadOne.IsValueWriteAtomic(stringValues).ToString()}");
        }

        /// <summary>Determines whether type TValue can be written atomically.</summary>
        public static bool IsValueWriteAtomic<TValue>(TValue value)
        {
            // Section 12.6.6 of ECMA CLI explains which types can be read and written atomically without
            // the risk of tearing. See https://www.ecma-international.org/publications/files/ECMA-ST/ECMA-335.pdf

            if (!typeof(TValue).IsValueType ||
                typeof(TValue) == typeof(IntPtr) ||
                typeof(TValue) == typeof(UIntPtr))
            {
                return true;
            }

            switch (Type.GetTypeCode(typeof(TValue)))
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                    return true;

                case TypeCode.Double:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return IntPtr.Size == 8;

                default:
                    return false;
            }
        }
    }
}
