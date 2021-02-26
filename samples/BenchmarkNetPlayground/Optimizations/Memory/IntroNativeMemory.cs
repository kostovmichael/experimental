using System;

namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;

    using System.Runtime.InteropServices;


    /// <summary>
    /// Please see the following article: https://wojciechnagorski.com/2019/08/analyzing-native-memory-allocation-with-benchmarkdotnet/
    /// </summary>


    [ShortRunJob]
    [NativeMemoryProfiler] // <-- This attribute enables the profiler for native allocation.
    [MemoryDiagnoser]
    public class IntroNativeMemory
    {
        private const int Size = 20; // Greater value could cause System.OutOfMemoryException for a test with memory leaks.
        private int ArraySize = Size * Marshal.SizeOf(typeof(int));

        [Benchmark]
        public unsafe void AllocHGlobal()
        {
            IntPtr unmanagedHandle = Marshal.AllocHGlobal(ArraySize);
            Span<byte> unmanaged = new Span<byte>(unmanagedHandle.ToPointer(), ArraySize);
            Marshal.FreeHGlobal(unmanagedHandle);
        }

        [Benchmark]
        public unsafe void AllocHGlobalWithLeaks()
        {
            IntPtr unmanagedHandle = Marshal.AllocHGlobal(ArraySize);
            Span<byte> unmanaged = new Span<byte>(unmanagedHandle.ToPointer(), ArraySize);
        }
    }
}
