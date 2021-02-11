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
                int upperBound = 10000;//arrayOfStrings.Length;
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
            public int ForLoop()
            {
                int counter = 0;
                int upperBound = listOfProducts.Count;
                for (int i = 0; i < upperBound; i++)
                {
                    var product = listOfProducts[i];
                    counter = counter + product.Id;
                }

                return counter;
            }

            [Benchmark]
            public int ForEach()
            {
                int counter = 0;
                foreach (var product in listOfProducts)
                {
                    counter = counter + product.Id;
                }
                return counter;
            }


            [Benchmark]
            public int ForEachWithLambda()
            {
                int counter = 0;
                listOfProducts.ForEach(product =>
                {
                    counter = counter + product.Id;
                });

                return counter;
            }



        }


    }


}
