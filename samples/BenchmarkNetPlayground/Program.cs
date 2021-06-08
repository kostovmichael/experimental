
using BenchmarkNetPlayground.Optimizations.DataStructures;

namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    using BenchmarkNetPlayground.Optimizations.Uncommon;
    using BenchmarkNetPlayground.Services;

    using Configs;

    using Microsoft.Extensions.Primitives;

    using Optimizations;
    using Optimizations.Loops;
    using Optimizations.Memory;
    using Optimizations.Pooling;

    using ScratchPad;

    using System;
    using System.Collections.Generic;

    using static BenchmarkNetPlayground.Optimizations.Collections.Lists;

    public class Program
    {
        static void Main(string[] args)
        {

         var test = new TreesAndHashTables.TrieVsDictionary();
         test.GlobalSetup();
            //BenchmarkRunner.Run<ArrayPooling.ArrayPoolOfBytes>();
        }
        #region "For loops"


        #endregion "For loops"

    }
}
