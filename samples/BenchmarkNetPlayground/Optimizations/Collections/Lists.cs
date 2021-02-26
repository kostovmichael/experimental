using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;

using PatternsAndConcepts.Services;

namespace BenchmarkNetPlayground.Optimizations.Collections
{
   public class Lists
   {
      public class ListWithOrWithoutSupplyingInitialCount
      {
         private string[] arrayOfStrings;
         [GlobalSetup]
         public void Setup()
         {
            arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();
         }


         [Benchmark]
         public List<string> List_Without_Initial_Count()
         {
            List<string> list = new List<string>();
            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
               list.Add(arrayOfStrings[i]);
            }
            return list;
         }

         [Benchmark]
         public List<string> List_With_Initial_Count()
         {
            List<string> list = new List<string>(arrayOfStrings.Length);
            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
               list.Add(arrayOfStrings[i]);
            }
            return list;
         }

      }
   }
}
