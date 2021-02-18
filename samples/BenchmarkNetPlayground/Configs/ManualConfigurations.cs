

namespace BenchmarkNetPlayground.Configs
{
    using BenchmarkDotNet.Columns;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Environments;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Loggers;

    public static class ManualConfigurations
    {
        public const string ArtifactsPath = @"C:\ProgAppLogs\BenchmarkDotNet";

        public static ManualConfig GetManualConfigDefault()
        {
            ManualConfig config = ManualConfig.CreateEmpty();
            //https://benchmarkdotnet.org/articles/configs/diagnosers.html
            config.AddDiagnoser(MemoryDiagnoser.Default);
            config.WithArtifactsPath(ArtifactsPath);
            config.AddExporter(DefaultExporters.Html);
            config.AddLogger(ConsoleLogger.Default);
            config.AddColumnProvider(DefaultColumnProviders.Instance);

            //config.AddHardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions, HardwareCounter.TotalCycles);
            return config;

        }




        public static ManualConfig GetManualConfig_Net472_CoreRt31_X86()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472(runAsX64: false), Get_Job_DotNet_Core_31(runAsX64: false));
            return config;
        }

        public static ManualConfig GetManualConfig_Net472_CoreRt31_64()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472(), Get_Job_DotNet_Core_31());
            return config;
        }

        public static ManualConfig GetManualConfig_Net472_CoreRt31_DotNet50_64()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472(), Get_Job_DotNet_Core_31(), Get_Job_DotNet_50());
            return config;
        }



        public static Job Get_Job_DotNet_Legacy_472(bool runAsX64 = true)
        {
            var job = new Job(Job.Default);
            job.WithRuntime(ClrRuntime.Net472);
            job.WithPlatform(runAsX64 ? Platform.X64 : Platform.X86);
            job.WithJit(Jit.LegacyJit);
            job.WithGcServer(true);
            return job;
        }

        public static Job Get_Job_DotNet_Core_31(bool runAsX64 = true)
        {
            var job = new Job(Job.Default);
            job.WithRuntime(CoreRtRuntime.CoreRt50);
            job.WithPlatform(runAsX64 ? Platform.X64 : Platform.X86);
            job.WithJit(Jit.RyuJit);
            job.WithGcServer(true);
            return job;
        }
        public static Job Get_Job_DotNet_50(bool runAsX64 = true)
        {
            var job = new Job(Job.Default);
            job.WithRuntime(CoreRtRuntime.CoreRt50);
            job.WithPlatform(runAsX64 ? Platform.X64 : Platform.X86);
            job.WithJit(Jit.RyuJit);
            job.WithGcServer(true);
            return job;
        }



        public static ManualConfig GetManualConfig_CoreRt31_64(int maxIterationsCount = 100)
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Core_31());
            return config;
        }
        public static ManualConfig GetManualConfig_Net472_X86()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472(runAsX64: false));
            return config;
        }
    }
}
