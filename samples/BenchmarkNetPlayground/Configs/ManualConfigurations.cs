

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


        #region "Manual Configs"

        public static ManualConfig GetManualConfig_Net472_CoreRt31_X86()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472(runAsX64: false).AsBaseline(), Get_Job_DotNet_Core_31(runAsX64: false));

            return config;
        }

        public static ManualConfig GetManualConfig_Net472_CoreRt31_64()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472().AsBaseline(), Get_Job_DotNet_Core_31());
            return config;
        }

        public static ManualConfig GetManualConfig_Net472_CoreRt31_DotNet50_64()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Get_Job_DotNet_Legacy_472().AsBaseline());
            config.AddJob(Get_Job_DotNet_Core_31());
            config.AddJob(Get_Job_DotNet_50());
            return config;
        }

        public static ManualConfig GetManualConfig_Net472_CoreRt31_64_backup()
        {
            ManualConfig config = GetManualConfigDefault();
            config.AddJob(Job.Default // Adding first job
                    .WithRuntime(ClrRuntime.Net472) // .NET Framework 4.7.2
                    .WithPlatform(Platform.X64) // Run as x86 application
                    .WithJit(Jit.LegacyJit) // Use LegacyJIT instead of the default RyuJIT
                    .WithGcServer(true)// Use Server GC
                                       //.WithMaxIterationCount(maxIterationsCount)// Max Iterations (Default is 100)
            );


            config.AddJob(Job.Default // Adding second job
                    .WithRuntime(CoreRtRuntime.CoreRt31)
                    .WithPlatform(Platform.X64) // Run as x86 application
                    .WithJit(Jit.RyuJit) // Use RyuJIT
                    .WithGcServer(true)// Use Server GC
                                       //.WithMaxIterationCount(maxIterationsCount)// Max Iterations (Default is 100)
            );

            return config;

        }


        #endregion "Manual Configs"


        #region "Jobs"

        public static Job Get_Job_DotNet_Legacy_472(bool runAsX64 = true)
        {
            var job = new Job(Job.Default);
            job.WithId("Net472");
            job.WithRuntime(ClrRuntime.Net472);
            job.WithPlatform(runAsX64 ? Platform.X64 : Platform.X86);
            job.WithJit(Jit.LegacyJit);
            job.WithGcServer(true);
            return job;
        }

        public static Job Get_Job_DotNet_Core_31(bool runAsX64 = true)
        {

            var job = new Job(Job.Default);
            job.WithId("CoreRt31");
            job.WithRuntime(CoreRtRuntime.CoreRt31);
            job.WithPlatform(runAsX64 ? Platform.X64 : Platform.X86);
            job.WithJit(Jit.RyuJit);
            job.WithGcServer(true);
            return job;
        }

        public static Job Get_Job_DotNet_50(bool runAsX64 = true)
        {
            var job = new Job(Job.Default);
            job.WithId("CoreRt50");
            job.WithRuntime(CoreRtRuntime.CoreRt50);
            job.WithPlatform(runAsX64 ? Platform.X64 : Platform.X86);
            job.WithJit(Jit.RyuJit);
            job.WithGcServer(true);
            return job;
        }

        #endregion "Jobs"

    }
}
