namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;

    using BenchmarkNetPlayground.Services;

    using System.Collections.Generic;

    public class DictionaryConcreteVsInterface
    {
        Dictionary<int, string> dict;
        IDictionary<int, string> idict;


        [GlobalSetup]
        public void Setup()
        {
            string[] arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
            dict = new Dictionary<int, string>(arrayOfStrings.Length);
            int upperBound = arrayOfStrings.Length;
            for (int i = 0; i < upperBound; i++)
            {
                dict.Add(i, arrayOfStrings[i]);

            }
            idict = (IDictionary<int, string>)dict;
        }

        [Benchmark]
        public List<string> DictionaryEnumeration()
        {
            var result = Iterate_Dictionary(this.dict);
            return result;
        }

        [Benchmark]
        public List<string> IDictionaryEnumeration()
        {
            var result = Iterate_IDictionary(this.idict);
            return result;
        }

        private List<string> Iterate_IDictionary(IDictionary<int, string> suppliedIDictionary)
        {
            List<string> listOfResults = new List<string>(suppliedIDictionary.Count);
            foreach (var item in suppliedIDictionary)
            {
                listOfResults.Add(item.Value);
            }
            return listOfResults;
        }

        private List<string> Iterate_Dictionary(Dictionary<int, string> suppliedDictionary)
        {
            List<string> listOfResults = new List<string>(suppliedDictionary.Count);
            foreach (var item in suppliedDictionary)
            {
                listOfResults.Add(item.Value);
            }
            return listOfResults;
        }

    }
}
