using System;

namespace SandboxConsoleApp
{
    using ObjectLayoutInspector;

    class Program
    {
        static void Main(string[] args)
        {


            TypeLayout.PrintLayout(
                typeof(PatternsAndConcepts.DummyModels.Product));


            Console.WriteLine(" ");

            TypeLayout.PrintLayout(
                typeof(PatternsAndConcepts.DummyModels.ProductStruct));

            Console.WriteLine(" ");

            TypeLayout.PrintLayout(
                typeof(PatternsAndConcepts.DummyModels.ProductStructLayoutAuto));

            Console.WriteLine(" ");

            TypeLayout.PrintLayout(
                typeof(PatternsAndConcepts.DummyModels.ProductStructLayoutSequential));

        }
    }
}
