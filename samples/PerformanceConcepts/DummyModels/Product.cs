namespace PatternsAndConcepts.DummyModels
{
    using System.Runtime.InteropServices;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }

    public struct ProductStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProductStructLayoutSequential
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }

    [StructLayout(LayoutKind.Auto)]
    public struct ProductStructLayoutAuto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}
