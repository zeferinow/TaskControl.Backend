using Microsoft.Extensions.Configuration;
using System.IO;

namespace TaskControl.Backend.ProgramSetters
{
    public class ConfigurationRootBuilder
    {
        public static IConfigurationRoot Build(params string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, false);

            var environmentJson = $"appsettings.{RunningEnvironment.CurrentEnvironment()}.json";

            if (File.Exists(environmentJson))
            {
                builder.AddJsonFile(environmentJson, false, false);
            }

            builder.AddEnvironmentVariables();

            if (args != null)
            {
                builder.AddCommandLine(args);
            }

            return builder.Build();
        }
    }
}
