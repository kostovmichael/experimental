﻿namespace BenchmarkNetPlayground.DummyClasses
{
    using System.Runtime.InteropServices;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct ProductStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProductStructLayoutSequential
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
