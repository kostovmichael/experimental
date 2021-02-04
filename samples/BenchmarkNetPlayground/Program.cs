
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    public class Program
    {
        static void Main(string[] args)
        {
            //Dictionary Benchmarks
            //BenchmarkRunner.Run<Optimizations.BasicHashMapOperations>();

            //Compiler Inlining Benchmarks
            BenchmarkRunner.Run<Optimizations.Inlining>();
        }

    }
}
