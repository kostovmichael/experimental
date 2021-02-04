
namespace BenchmarkNetPlayground
{
    using BenchmarkDotNet.Running;

    public class Program
    {
        static void Main(string[] args)
        {

            BenchmarkRunner.Run<Optimizations.BasicHashMapOperations>();
            //BenchmarkRunner.Run<Optimizations.Inlining>();
        }

    }
}
