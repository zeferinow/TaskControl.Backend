using TaskControl.Backend.Data.Configurations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace TaskControl.Backend
{
    public class App
    {
        protected internal static MongoDBConfiguration MongoDBConfiguration;

        private static IConfigurationRoot configurationRoot;

        public App(IConfigurationRoot configurationRoot)
        {
            App.configurationRoot = configurationRoot;
        }

        public IWebHost Build()
        {
            MongoDBConfiguration = configurationRoot.Get<MongoDBConfiguration>();

            configurationRoot.Bind("MongoDB", MongoDBConfiguration);

            return CreateWebHostBuilder(configurationRoot).Build();
        }

        private IWebHostBuilder CreateWebHostBuilder(IConfiguration hostConfiguration)
        {
            return WebHost
                .CreateDefaultBuilder()
                .UseConfiguration(hostConfiguration)
                .ConfigureServices(services => services.AddSingleton(this))
                .UseStartup<Startup>()
                .UseSerilog();
        }
    }
}
