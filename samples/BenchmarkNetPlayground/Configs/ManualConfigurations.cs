

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

            config.AddJob(Job.Default // Adding first job
                .WithRuntime(ClrRuntime.Net472) // .NET Framework 4.7.2
                .WithPlatform(Platform.X86) // Run as x86 application
                .WithJit(Jit.LegacyJit) // Use LegacyJIT instead of the default RyuJIT
                .WithGcServer(true)); // Use Server GC


            config.AddJob(Job.Default // Adding second job
                    .WithRuntime(CoreRtRuntime.CoreRt31)
                    .WithPlatform(Platform.X86) // Run as x86 application
                    .WithJit(Jit.RyuJit) // Use LegacyJIT instead of the default RyuJIT
                    .WithGcServer(true) // Use Server GC

            );

            return config;

        }

        public static ManualConfig GetManualConfig_Net472_CoreRt31_64(int maxIterationsCount = 100)
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
                    .WithJit(Jit.RyuJit) // Use LegacyJIT instead of the default RyuJIT
                    .WithGcServer(true)// Use Server GC
                                       //.WithMaxIterationCount(maxIterationsCount)// Max Iterations (Default is 100)
            );

            return config;

        }
        public static ManualConfig GetManualConfig_Net472_X86()
        {
            ManualConfig config = GetManualConfigDefault();

            config.AddJob(Job.LegacyJitX86 // Adding first job
                    .WithRuntime(ClrRuntime.Net472) // .NET Framework 4.7.2
                    .WithPlatform(Platform.X86) // Run as x86 application
                    .WithJit(Jit.LegacyJit) // Use LegacyJIT instead of the default RyuJIT
                    .WithGcServer(true) // Use Server GC

            );

            return config;

        }
    }
}
