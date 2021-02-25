namespace BenchmarkNetPlayground.Optimizations.Loops
{
    using BenchmarkDotNet.Analysers;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Columns;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Environments;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Validators;

    using DummyClasses;

    using Perfolizer.Horology;

    using Services;

    using System.Collections.Generic;
    using System.Linq;

    using Utils;

    public class ForLoopTesting
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

        public class ForVsForEachSlim
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
            public long ForLoop()
            {
                long result = 0;
                int upperBound = listOfProducts.Count;
                for (int i = 0; i < upperBound; i++)
                {
                    var product = listOfProducts[i];
                    result += product.Id;
                }
                return result;
            }

            [Benchmark]
            public long ForEach()
            {

                long result = 0;
                foreach (var product in listOfProducts)
                {
                    result += product.Id;
                }
                return result;
            }


            [Benchmark]
            public long ForEachWithLambda()
            {
                long result = 0;
                listOfProducts.ForEach(product =>
                {
                    result += product.Id;
                });

                return result;
            }



        }

   }


}
