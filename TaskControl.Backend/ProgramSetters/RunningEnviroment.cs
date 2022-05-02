using System;
using Microsoft.Extensions.Configuration;

namespace TaskControl.Backend.ProgramSetters
{
    public static class RunningEnvironment
    {
        public static string CurrentEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        }

        public static bool IsDevelopment()
        {
            return CurrentEnvironment() == "Development";
        }

        public static void SetupEnvironment(string[] args)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddCommandLine(args);

            var environment = builder.Build().GetValue<string>("environment") ?? "Development";

            if (!string.IsNullOrWhiteSpace(environment))
            {
                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", environment);
            }
        }
    }
}
