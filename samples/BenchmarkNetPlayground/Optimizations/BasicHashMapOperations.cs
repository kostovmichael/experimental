namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;

    using Services;

    using System.Collections.Generic;

    [SimpleJob(RuntimeMoniker.Net472), SimpleJob(RuntimeMoniker.CoreRt31)]

    //https://benchmarkdotnet.org/articles/configs/diagnosers.html
    [MemoryDiagnoser]
    [ArtifactsPath(@"C:\ProgAppLogs")]
    [HtmlExporter]
    public class BasicHashMapOperations
    {
        private static string[] arrayOfStrings;
        [GlobalSetup]
        public void Setup()
        {
            arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
        }

        [Benchmark]
        public Dictionary<string, object> ValueAsObjectWithoutDefaultInitialCount()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
            }

            return dictionary;
        }
        [Benchmark]
        public Dictionary<string, string> ValueAsStringWithoutDefaultInitialCount()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
            }

            return dictionary;
        }


        [Benchmark]
        public Dictionary<string, object> ValueAsObjectWithtInitialCount()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>(arrayOfStrings.Length);

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
            }

            return dictionary;
        }
        [Benchmark]
        public Dictionary<string, string> ValueAsStringWithInitialCount()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(arrayOfStrings.Length);

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
            }

            return dictionary;
        }


    }
}
