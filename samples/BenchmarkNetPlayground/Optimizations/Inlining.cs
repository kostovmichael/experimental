namespace BenchmarkNetPlayground.Optimizations
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;

    using System.Runtime.CompilerServices;

    [SimpleJob(RuntimeMoniker.Net472), SimpleJob(RuntimeMoniker.CoreRt31)]

    //https://benchmarkdotnet.org/articles/configs/diagnosers.html

    [InliningDiagnoser(true, true)]
    //[MemoryDiagnoser]
    [ArtifactsPath(@"C:\ProgAppLogs")]
    [MarkdownExporterAttribute.Atlassian, HtmlExporter]
    public class Inlining
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int Inlined(int i)
        {
            return i;
        }

        [Benchmark]
        public int SumInlined()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
                result += Inlined(i);
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private int NonInlined(int i)
        {
            return i;
        }

        [Benchmark]
        public int SumNonInlined()
        {
            int result = 0;
            for (int i = 0; i < 1000; i++)
                result += NonInlined(i);
            return result;
        }
    }
}
