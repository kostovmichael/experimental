namespace BenchmarkNetPlayground.Optimizations.Loops
{
    using BenchmarkDotNet.Attributes;

    using DummyClasses;

    using Services;

    using System.Collections.Generic;

    public class ForLoopTesting
    {
        public class ForVsForEach
        {

            private static List<Product> listOfProducts;
            [GlobalSetup]
            public void Setup()
            {
                string[] arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
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
                Dictionary<int, Product> dict = new Dictionary<int, Product>(upperBound);
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

                Dictionary<int, Product> dict = new Dictionary<int, Product>(listOfProducts.Count);
                foreach (var product in listOfProducts)
                {
                    dict.Add(product.Id, product);
                }
                return dict;
            }


            [Benchmark]
            public Dictionary<int, Product> ForEachWithLambda()
            {
                Dictionary<int, Product> dict = new Dictionary<int, Product>(listOfProducts.Count);
                listOfProducts.ForEach(product =>
                {
                    dict.Add(product.Id, product);
                });

                return dict;
            }



        }


    }


}
