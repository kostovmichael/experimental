

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

      #region "Manual Configs"
      public static ManualConfig GetManualConfigDefault()
      {
         ManualConfig config = ManualConfig.CreateEmpty();
         //https://benchmarkdotnet.org/articles/configs/diagnosers.html
         config.AddDiagnoser(MemoryDiagnoser.Default);
         config.WithArtifactsPath(ArtifactsPath);
         config.AddExporter(DefaultExporters.Html);
         config.AddLogger(ConsoleLogger.Default);
         config.AddColumnProvider(DefaultColumnProviders.Instance);
         return config;

      }
      public static ManualConfig GetManualConfig_Default_Job()
      {
         ManualConfig config = GetManualConfigDefault();
         config.AddJob(Job.Default.WithGcServer(true));
         return config;

      }




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
         config.AddJob(Get_Job_DotNet_Legacy_472());
         config.AddJob(Get_Job_DotNet_Core_31());
         config.AddJob(Get_Job_DotNet_50());
         return config;
      }

      public static ManualConfig GetManualConfig_Net472_CoreRt31_DotNet50_64_backup()
      {
         ManualConfig config = GetManualConfigDefault();
         config.AddJob(Job.ShortRun
               .WithRuntime(ClrRuntime.Net472)
               .WithPlatform(Platform.X64)
               .WithJit(Jit.RyuJit)
               .WithGcServer(true)
               //.WithBaseline(true)
               //.AsBaseline()
               .WithId("Net472")

         );

         config.AddJob(Job.ShortRun
            .WithRuntime(CoreRtRuntime.CoreRt31)
            .WithPlatform(Platform.X64)
            .WithJit(Jit.RyuJit)
            .WithGcServer(true)
            .WithId("CoreRt31")

         );

         //config.AddJob(Job.ShortRun
         //      .WithRuntime(CoreRuntime.Core50)
         //      .WithPlatform(Platform.X64)
         //      .WithJit(Jit.RyuJit)
         //      .WithGcServer(true)
         //      .WithId("CoreRt50")
         ////.WithMaxIterationCount(maxIterationsCount)// Max Iterations (Default is 100)
         //);

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
