namespace BenchmarkNetPlayground.Optimizations.Loops
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;

    using DummyClasses;

    using Services;

    using System.Collections.Generic;

    using Utils;

    public class ForLoopTesting
    {

        [SimpleJob(RuntimeMoniker.CoreRt31)]

        //https://benchmarkdotnet.org/articles/configs/diagnosers.html
        [MemoryDiagnoser]
        [ArtifactsPath(@"C:\ProgAppLogs")]
        [HtmlExporter]
        public class ForVsForEach
        {

            private List<Product> listOfProducts;
            private string[] arrayOfStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
                int upperBound = arrayOfStrings.Length;
                listOfProducts = new List<Product>(upperBound);
                for (int i = 0; i < upperBound; i++)
                {
                    listOfProducts.Add(new Product()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i]
                    });
                }

            }

            //[IterationSetup]
            //public void Setup()
            //{
            //    //var arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
            //    RandomizerUtil.Shuffle(arrayOfStrings);
            //    int upperBound = arrayOfStrings.Length;
            //    listOfProducts = new List<Product>(upperBound);
            //    for (int i = 0; i < upperBound; i++)
            //    {
            //        listOfProducts.Add(new Product()
            //        {
            //            Id = i + 100,
            //            Name = arrayOfStrings[i]
            //        });
            //    }
            //}
            [Benchmark]
            public Dictionary<string, Product> ForLoop()
            {
                int upperBound = listOfProducts.Count;
                Dictionary<string, Product> dict = new Dictionary<string, Product>(listOfProducts.Count);
                for (int i = 0; i < upperBound; i++)
                {
                    var product = listOfProducts[i];
                    dict.Add(product.Name, product);
                }
                return dict;
            }

            [Benchmark]
            public Dictionary<string, Product> ForEach()
            {

                Dictionary<string, Product> dict = new Dictionary<string, Product>(listOfProducts.Count);
                foreach (var product in listOfProducts)
                {
                    dict.Add(product.Name, product);
                }
                return dict;
            }


            [Benchmark]
            public Dictionary<string, Product> ForEachWithLambda()
            {
                Dictionary<string, Product> dict = new Dictionary<string, Product>(listOfProducts.Count);
                listOfProducts.ForEach(product =>
                {
                    dict.Add(product.Name, product);
                });

                return dict;
            }



        }


    }


}
