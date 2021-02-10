
namespace BenchmarkNetPlayground
{

   using BenchmarkDotNet.Running;

   using BenchmarkNetPlayground.Configs;

   using Optimizations;

   public class Program
   {
      static void Main(string[] args)
      {

         BenchmarkRunner.Run<DictionaryConcreteVsInterface>(
         ManualConfigurations.GetManualConfig_Net472_CoreRt31_X86());

         //Dictionary Benchmarks
         //BenchmarkRunner.Run<Optimizations
         //    .DictionaryWithOrWithoutSupplyingInitialCount>(
         //    ManualConfigurations.GetManualConfig_Net472_CoreRt31_X86());

         //BenchmarkRunner.Run<IntroNativeMemory>();

         //Compiler Inlining Benchmarks
         //BenchmarkRunner.Run<Optimizations.Inlining>();
      }



   }
}
