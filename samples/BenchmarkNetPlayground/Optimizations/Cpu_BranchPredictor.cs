﻿namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnosers;

    using System;
    /// <summary>
    /// Please the following article https://adamsitnik.com/Hardware-Counters-Diagnoser/
    /// </summary>

    [HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
    public class Cpu_BranchPredictor
    {
        private const int N = 32767;
        private readonly int[] sorted, unsorted;

        public Cpu_BranchPredictor()
        {
            var random = new Random(0);
            unsorted = new int[N];
            sorted = new int[N];
            for (int i = 0; i < N; i++)
                sorted[i] = unsorted[i] = random.Next(256);
            Array.Sort(sorted);
        }

        private static int Branch(int[] data)
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
                if (data[i] >= 128)
                    sum += data[i];
            return sum;
        }

        private static int Branchless(int[] data)
        {
            int sum = 0;
            for (int i = 0; i < N; i++)
            {
                int t = (data[i] - 128) >> 31;
                sum += ~t & data[i];
            }
            return sum;
        }

        [Benchmark]
        public int SortedBranch() => Branch(sorted);

        [Benchmark]
        public int UnsortedBranch() => Branch(unsorted);

        [Benchmark]
        public int SortedBranchless() => Branchless(sorted);

        [Benchmark]
        public int UnsortedBranchless() => Branchless(unsorted);
    }
}
