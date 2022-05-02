using TaskControl.Backend.ProgramSetters;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace TaskControl.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                RunningEnvironment.SetupEnvironment(args);

                Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                var configurationRoot = ConfigurationRootBuilder.Build(args);

                Logger.Setup(configurationRoot);

                new App(configurationRoot).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
