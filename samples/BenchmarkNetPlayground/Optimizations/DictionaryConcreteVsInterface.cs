using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using BenchmarkNetPlayground.Services;

namespace BenchmarkNetPlayground.Optimizations
{
   // Taken from the BenchmarkDotNet samples. 
   // From https://github.com/dotnet/coreclr/issues/1579
   //[MemoryDiagnoser]
   public class DictionaryConcreteVsInterface
   {
      Dictionary<string, string> dict;
      IDictionary<string, string> idict;
      

      [GlobalSetup]
      public void Setup()
      {
         string[] arrayOfStrings =  TestDataRetrievalService.GetCommonWordsTestData();
         dict = new Dictionary<string, string>(arrayOfStrings.Length);


         int upperBound = 10000;//arrayOfStrings.Length;
         int backwardsCursor = upperBound - 1;
         for (int i = 0; i < upperBound; i++)
         {
            dict.Add(arrayOfStrings[i], arrayOfStrings[backwardsCursor]);
            backwardsCursor--;
         }
         idict = (IDictionary<string, string>)dict;
      }
      private int counter1;

      [Benchmark]
      public List<string> DictionaryEnumeration()
      {
         List<string> listOfStrings = new List<string>(dict.Count);
         // Doesn't allocate (as much)
         foreach (var item in dict)
         {
            listOfStrings.Add(item.Key + item.Value);
         }
         return listOfStrings;
      }


      [Benchmark]
      public List<string> IDictionaryEnumeration()
      {
         // Allocates (more)
         List<string> listOfStrings = new List<string>(dict.Count);
         foreach (var item in idict)
         {
            listOfStrings.Add(item.Key + item.Value);
         }
         return listOfStrings;
      }

   }
}
