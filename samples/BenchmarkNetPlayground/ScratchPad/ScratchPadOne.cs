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
   }
}
