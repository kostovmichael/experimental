

namespace BenchmarkNetPlayground.Optimizations.Memory
{

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;

    using System.Collections.Generic;

    public class StringAllocations
    {


        [ShortRunJob]
        [NativeMemoryProfiler] // <-- This attribute enables the profiler for native allocation.
        [MemoryDiagnoser]
        public class SingleStringVsChunks
        {

            [Benchmark]
            public string GetSingleString()
            {
                var largeString =
                    PatternsAndConcepts.Services.
                        TestDataRetrievalService.
                        GetTestStringDataFromFile("mthesaur.txt");
                return largeString;
            }

            [Benchmark]
            public List<string> GetListOfStrings()
            {
                var listOfStrings =
                    PatternsAndConcepts.Services.
                        TestDataRetrievalService.
                        GetTestStreamDataFromFile("mthesaur.txt");
                return listOfStrings;
            }
        }

    }
}
