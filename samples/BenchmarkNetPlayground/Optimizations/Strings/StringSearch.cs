namespace BenchmarkNetPlayground.Optimizations.Strings
{
    using BenchmarkDotNet.Attributes;

    using BenchmarkNetPlayground.Services;

    using PatternsAndConcepts.Algs;
    using PatternsAndConcepts.DummyModels;

    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class StringSearch
    {
        public class DictionaryVsTrie
        {

            private List<Product> listOfProducts;
            private string[] arrayOfStrings;

            private Dictionary<string, int> dictionaryIndexByName;
            private TernarySearchTrie<int> trieIndexByName;

            private List<string> arrayOfRandomSearchStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
                int upperBound = arrayOfStrings.Length;
                listOfProducts = new List<Product>(upperBound);

                dictionaryIndexByName = new Dictionary<string, int>(upperBound);
                trieIndexByName = new TernarySearchTrie<int>();



                for (int i = 0; i < upperBound; i++)
                {
                    listOfProducts.Add(new Product()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i]
                    });
                    dictionaryIndexByName.Add(arrayOfStrings[i], i);
                    trieIndexByName.Put(arrayOfStrings[i].AsSpan(), i);
                }

                var random = new Random();
                int searchStringsUpperBound = 10000;
                arrayOfRandomSearchStrings = new List<string>(searchStringsUpperBound);
                for (int i = 0; i < searchStringsUpperBound; i++)
                {
                    int randomIndex = random.Next(0, upperBound - 1);
                    string randomString = arrayOfStrings[randomIndex];

                    if (randomIndex % 2 == 0)
                    {
                        arrayOfRandomSearchStrings.Add(randomString.Reverse().ToString());
                    }
                    else
                    {
                        arrayOfRandomSearchStrings.Add(randomString);
                    }
                }


            }

            [Benchmark]
            public List<Product> RetriveFromDictionary()
            {
                List<Product> listOfFoundProduct = new List<Product>(5000);
                int missedCount = 0;
                for (int i = 0; i < arrayOfRandomSearchStrings.Count; i++)
                {
                    if (dictionaryIndexByName.TryGetValue(arrayOfRandomSearchStrings[i], out int indexOfProduct))
                    {
                        listOfFoundProduct.Add(listOfProducts[indexOfProduct]);
                    }
                    else
                    {
                        missedCount++;
                    }

                }
                //Console.WriteLine($"RetriveFromDictionary found: {listOfFoundProduct.Count.ToString()} missed: {missedCount.ToString()}");
                return listOfFoundProduct;
            }

            [Benchmark]
            public List<Product> RetriveFromTrie()
            {
                List<Product> listOfFoundProduct = new List<Product>(5000);
                int missedCount = 0;
                for (int i = 0; i < arrayOfRandomSearchStrings.Count; i++)
                {
                    var indexOfProduct = trieIndexByName.Get(arrayOfRandomSearchStrings[i].AsSpan());
                    if (indexOfProduct > 0)
                    {
                        listOfFoundProduct.Add(listOfProducts[indexOfProduct]);
                    }
                    else
                    {
                        missedCount++;
                    }
                }
                //Console.WriteLine($"RetriveFromTrie found: {listOfFoundProduct.Count.ToString()} missed: {missedCount.ToString()}");
                return listOfFoundProduct;
            }
        }
        public class TrieVsDictionary
        {

            private List<Product> listOfProducts;
            private string[] arrayOfStrings;

            private Dictionary<string, Product> dictionaryIndexByName;
            private TernarySearchTrie<Product> trieIndexByName;

            private List<string> arrayOfRandomSearchStrings;

            [GlobalSetup]
            public void GlobalSetup()
            {
                arrayOfStrings = TestDataRetrievalService.GetCommonWordsTestData();
                int upperBound = arrayOfStrings.Length;
                listOfProducts = new List<Product>(upperBound);

                dictionaryIndexByName = new Dictionary<string, Product>(upperBound);
                trieIndexByName = new TernarySearchTrie<Product>();



                for (int i = 0; i < upperBound; i++)
                {
                    var product = new Product()
                    {
                        Id = i + 100,
                        Name = arrayOfStrings[i]
                    };
                    listOfProducts.Add(product);
                    dictionaryIndexByName.Add(product.Name, product);
                    trieIndexByName.Put(product.Name.AsSpan(), product);
                }

                var random = new Random();
                int searchStringsUpperBound = 10000;
                arrayOfRandomSearchStrings = new List<string>(searchStringsUpperBound);
                for (int i = 0; i < searchStringsUpperBound; i++)
                {
                    int randomIndex = random.Next(0, upperBound - 1);
                    string randomString = arrayOfStrings[randomIndex];

                    if (randomIndex % 2 == 0)
                    {
                        arrayOfRandomSearchStrings.Add(randomString.Reverse().ToString());
                    }
                    else
                    {
                        arrayOfRandomSearchStrings.Add(randomString);
                    }
                }


            }

            [Benchmark]
            public List<Product> RetriveFromDictionary()
            {
                List<Product> listOfFoundProduct = new List<Product>(5000);
                int missedCount = 0;
                for (int i = 0; i < arrayOfRandomSearchStrings.Count; i++)
                {
                    if (dictionaryIndexByName.TryGetValue(arrayOfRandomSearchStrings[i], out Product product))
                    {
                        listOfFoundProduct.Add(product);
                    }
                    else
                    {
                        missedCount++;
                    }

                }
                //Console.WriteLine($"RetriveFromDictionary found: {listOfFoundProduct.Count.ToString()} missed: {missedCount.ToString()}");
                return listOfFoundProduct;
            }

            [Benchmark]
            public List<Product> RetriveFromTrie()
            {
                List<Product> listOfFoundProduct = new List<Product>(5000);
                int missedCount = 0;
                for (int i = 0; i < arrayOfRandomSearchStrings.Count; i++)
                {
                    var product = trieIndexByName.Get(arrayOfRandomSearchStrings[i].AsSpan());
                    if (product != null)
                    {
                        listOfFoundProduct.Add(product);
                    }
                    else
                    {
                        missedCount++;
                    }
                }
                //Console.WriteLine($"RetriveFromTrie found: {listOfFoundProduct.Count.ToString()} missed: {missedCount.ToString()}");
                return listOfFoundProduct;
            }
        }

    }
}
