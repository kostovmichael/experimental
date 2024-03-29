﻿namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;

    using Services;

    using System.Collections.Generic;

    //[SimpleJob(RuntimeMoniker.Net472), SimpleJob(RuntimeMoniker.CoreRt31)]

    ////https://benchmarkdotnet.org/articles/configs/diagnosers.html
    //[MemoryDiagnoser]
    //[ArtifactsPath(@"C:\ProgAppLogs")]
    //[HtmlExporter]
    public class DictionaryWithOrWithoutSupplyingInitialCount
    {
        private string[] arrayOfStrings;
        [GlobalSetup]
        public void Setup()
        {
            arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
        }


        //[Benchmark(Baseline =true)]
        //public Dictionary<string, object> Value_As_Object_Without_Initial_Count()
        //{
        //    Dictionary<string, object> dictionary = new Dictionary<string, object>();

        //    for (int i = 0; i < arrayOfStrings.Length; i++)
        //    {
        //        dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
        //    }

        //    return dictionary;
        //}
        [Benchmark(Baseline = true)]
        public Dictionary<string, string> Dictionary_Without_Initial_Count()
        {

            var dictionary = new Dictionary<string, string>();

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
            }

            return dictionary;
        }
        //[Benchmark]
        //public Dictionary<string, dynamic> Value_As_Dynamic_Without_Initial_Count()
        //{
        //    Dictionary<string, dynamic> dictionary = new Dictionary<string, dynamic>();

        //    for (int i = 0; i < arrayOfStrings.Length; i++)
        //    {
        //        dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
        //    }

        //    return dictionary;
        //}



        //[Benchmark]
        //public Dictionary<string, object> Value_As_Object_With_Initial_Count()
        //{
        //    Dictionary<string, object> dictionary = new Dictionary<string, object>(arrayOfStrings.Length);

        //    for (int i = 0; i < arrayOfStrings.Length; i++)
        //    {
        //        dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
        //    }

        //    return dictionary;
        //}
        [Benchmark]
        public Dictionary<string, string> Dictionary_With_Initial_Count()
        {
            var dictionary = new Dictionary<string, string>(2600000);

            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
            }

            return dictionary;
        }
        //[Benchmark]
        //public Dictionary<string, dynamic> Value_As_Dynamic_With_Initial_Count()
        //{
        //    Dictionary<string, dynamic> dictionary = new Dictionary<string, dynamic>(arrayOfStrings.Length);

        //    for (int i = 0; i < arrayOfStrings.Length; i++)
        //    {
        //        dictionary.Add(arrayOfStrings[i], arrayOfStrings[i]);
        //    }

        //    return dictionary;
        //}

    }
}
