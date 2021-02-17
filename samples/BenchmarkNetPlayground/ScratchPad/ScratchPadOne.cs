using Microsoft.Extensions.Primitives;

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

        public static void Test_IsValueWriteAtomic()
        {
            int testInt32 = 100;
            string testString = "abc";

            StringValues stringValues = new StringValues(testString);
            //ReadOnlySpan<char> spanFromString = testString.AsSpan();

            Console.WriteLine($"IsValueWriteAtomic {testInt32.GetType().ToString()} : {ScratchPadOne.IsValueWriteAtomic(testInt32).ToString()}");
            Console.WriteLine($"IsValueWriteAtomic {testString.GetType().ToString()} : {ScratchPadOne.IsValueWriteAtomic(testString).ToString()}");
            Console.WriteLine($"IsValueWriteAtomic {stringValues.GetType().ToString()} : {ScratchPadOne.IsValueWriteAtomic(stringValues).ToString()}");
        }

        /// <summary>Determines whether type TValue can be written atomically.</summary>
        public static bool IsValueWriteAtomic<TValue>(TValue value)
        {
            // Section 12.6.6 of ECMA CLI explains which types can be read and written atomically without
            // the risk of tearing. See https://www.ecma-international.org/publications/files/ECMA-ST/ECMA-335.pdf

            if (!typeof(TValue).IsValueType ||
                typeof(TValue) == typeof(IntPtr) ||
                typeof(TValue) == typeof(UIntPtr))
            {
                return true;
            }

            switch (Type.GetTypeCode(typeof(TValue)))
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                    return true;

                case TypeCode.Double:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return IntPtr.Size == 8;

                default:
                    return false;
            }
        }
    }
}
