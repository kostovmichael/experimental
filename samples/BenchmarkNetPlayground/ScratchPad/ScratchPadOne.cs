using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkNetPlayground.ScratchPad
{
   public class ScratchPadOne
   {

      public void GetCharSize()
      {
         var marshalSizeOfChar = System.Runtime.InteropServices.Marshal.SizeOf(typeof(char));

         var sizeOfChar = sizeof(char);

         var sizeOfInte = sizeof(int);
      }



      public void TestLargeStringArray()
      {
         //var arrayOfStrings = TestDataRetrievalService.GetMThesaurStringArray();

         //Console.WriteLine("Total words count: " + arrayOfStrings.Length.ToString());


         //var test = new ForLoopTesting.ForVsForEach();
         //test.GlobalSetup();

         //var dict1 = test.ForLoop();
         //Console.WriteLine("Total words count ForLoop: " + dict1.Count.ToString());

         //var dict2 = test.ForEach();
         //Console.WriteLine("Total words count ForEach: " + dict2.Count.ToString());

         //var dict3 = test.ForEachWithLambda();
         //Console.WriteLine("Total words count ForEachWithLambda: " + dict3.Count.ToString());

      }
   }
}
