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

        //[SimpleJob(RuntimeMoniker.Net472)]
        ////https://benchmarkdotnet.org/articles/configs/diagnosers.html
        //[MemoryDiagnoser]
        ////[ArtifactsPath(@"C:\ProgAppLogs")]
        //[HtmlExporter]
        public class ForVsForEach
        {

            private List<Product> listOfProducts;
            private string[] arrayOfStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
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

            [Benchmark]
            public Dictionary<int, Product> ForLoop()
            {
                int upperBound = listOfProducts.Count;
                var dict = new Dictionary<int, Product>(listOfProducts.Count);
                for (int i = 0; i < upperBound; i++)
                {
                    var product = listOfProducts[i];
                    dict.Add(product.Id, product);
                }
                return dict;
            }

            [Benchmark]
            public Dictionary<int, Product> ForEach()
            {

            var dict = new Dictionary<int, Product>(listOfProducts.Count);
            foreach (var product in listOfProducts)
                {
                    dict.Add(product.Id, product);
                }
                return dict;
            }


            [Benchmark]
            public Dictionary<int, Product> ForEachWithLambda()
            {
            var dict = new Dictionary<int, Product>(listOfProducts.Count);
            listOfProducts.ForEach(product =>
                {
                    dict.Add(product.Id, product);
                });

                return dict;
            }



        }


    }


}
