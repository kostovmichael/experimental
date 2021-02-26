namespace BenchmarkNetPlayground.Optimizations.Loops
{
    using BenchmarkDotNet.Attributes;

    using PatternsAndConcepts.DummyModels;

    using Services;

    using System.Collections.Generic;

    public class ForLoops
    {
        //[Config(typeof(Config))]
        public class ForVsForEach
        {
            //private class Config : ManualConfig
            //{
            //    public Config()
            //    {
            //        // The same, using the .With() factory methods:
            //        AddJob(
            //            Job.ShortRun
            //                .WithPlatform(Platform.X64)
            //                .WithJit(Jit.RyuJit)
            //                .WithRuntime(CoreRuntime.Core50)
            //                .WithMaxRelativeError(0.01)
            //                .WithId("Core50Job")
            //        );
            //        AddDiagnoser(MemoryDiagnoser.Default);
            //        // Exporters for data
            //        AddExporter(GetExporters().ToArray());
            //        AddColumn(StatisticColumn.AllStatistics);

            //    }
            //}

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

            [Benchmark(Baseline =true)]
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

        public class ForVsForEachUsingStructLayoutSequential
        {
            private List<ProductStructLayoutSequential> listOfProducts;
            private string[] arrayOfStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
                int upperBound = arrayOfStrings.Length;
                listOfProducts = new List<ProductStructLayoutSequential>(upperBound);
                for (int i = 0; i < upperBound; i++)
                {
                    listOfProducts.Add(new ProductStructLayoutSequential()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i]
                    });
                }

            }

            [Benchmark]
            public Dictionary<int, ProductStructLayoutSequential> ForLoop()
            {
                int upperBound = listOfProducts.Count;
                var dict = new Dictionary<int, ProductStructLayoutSequential>(listOfProducts.Count);
                for (int i = 0; i < upperBound; i++)
                {
                    var product = listOfProducts[i];
                    dict.Add(product.Id, product);
                }
                return dict;
            }

            [Benchmark]
            public Dictionary<int, ProductStructLayoutSequential> ForEach()
            {

                var dict = new Dictionary<int, ProductStructLayoutSequential>(listOfProducts.Count);
                foreach (var product in listOfProducts)
                {
                    dict.Add(product.Id, product);
                }
                return dict;
            }


            [Benchmark]
            public Dictionary<int, ProductStructLayoutSequential> ForEachWithLambda()
            {
                var dict = new Dictionary<int, ProductStructLayoutSequential>(listOfProducts.Count);
                listOfProducts.ForEach(product =>
                {
                    dict.Add(product.Id, product);
                });

                return dict;
            }



        }


        public class ForVsForEachClassVsSequentialStruct
        {
            private List<ProductStructLayoutSequential> listOfProductStructs;
            private List<Product> listOfProducts;

            private string[] arrayOfStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
                int upperBound = arrayOfStrings.Length;
                listOfProductStructs = new List<ProductStructLayoutSequential>(upperBound);
                listOfProducts = new List<Product>(upperBound);
                for (int i = 0; i < upperBound; i++)
                {
                    listOfProductStructs.Add(new ProductStructLayoutSequential()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i]
                    });
                    listOfProducts.Add(new Product()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i]
                    });
                }

            }

            [Benchmark]
            public Dictionary<int, ProductStructLayoutSequential> ForLoop_Struct()
            {
                int upperBound = listOfProductStructs.Count;
                var dict = new Dictionary<int, ProductStructLayoutSequential>(listOfProductStructs.Count);
                for (int i = 0; i < upperBound; i++)
                {
                    var product = listOfProductStructs[i];
                    dict.Add(product.Id, product);
                }
                return dict;
            }

            [Benchmark]
            public Dictionary<int, ProductStructLayoutSequential> ForEach_Struct()
            {

                var dict = new Dictionary<int, ProductStructLayoutSequential>(listOfProductStructs.Count);
                foreach (var product in listOfProductStructs)
                {
                    dict.Add(product.Id, product);
                }
                return dict;
            }


            [Benchmark]
            public Dictionary<int, ProductStructLayoutSequential> ForEachWithLambda_Struct()
            {
                var dict = new Dictionary<int, ProductStructLayoutSequential>(listOfProductStructs.Count);
                listOfProductStructs.ForEach(product =>
                {
                    dict.Add(product.Id, product);
                });

                return dict;
            }

            [Benchmark]
            public Dictionary<int, Product> ForLoop_Class()
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
            public Dictionary<int, Product> ForEach_Class()
            {

                var dict = new Dictionary<int, Product>(listOfProducts.Count);
                foreach (var product in listOfProducts)
                {
                    dict.Add(product.Id, product);
                }
                return dict;
            }


            [Benchmark]
            public Dictionary<int, Product> ForEachWithLambda_Class()
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
