using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Data.Configurations;
using TaskControl.Backend.Data.MongoDb;
using TaskControl.Backend.Data.Repositories;
using TaskControl.Backend.Domain;
using TaskControl.Backend.TaskControl.Ioc;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace TaskControl.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };

                });

            services.Configure<MongoDBConfiguration>(Configuration.GetSection(nameof(MongoDBConfiguration)));
            services.AddSingleton<IMongoDBConfiguration>(sp => sp.GetRequiredService<IOptions<MongoDBConfiguration>>().Value);


            services.AddMvc();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            ConfigureAppServices(services);

            services.AddTransient(typeof(IMongoDbRepository<>), typeof(MongoDbRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskListRepository, TaskListRepository>();
            services.AddTransient<IProceedingRepository, ProceedingRepository>();
            services.AddTransient<ISequenceRepository, SequenceRepository>();

            services.AddTransient<IBaseUserContext, ApiUserContext>();

            var iocContainer = new Container(rules =>
                    rules.With(propertiesAndFields: request =>
                        request.ServiceType.CustomAttributes.Any(w => w.AttributeType.Name == typeof(LazyInjection).Name) ||
                        request.ImplementationType.CustomAttributes.Any(w => w.AttributeType.Name == typeof(LazyInjection).Name)
                            ? PropertiesAndFields.Properties()(request)
                            : null)
                    .WithCaptureContainerDisposeStackTrace()
                )
                .WithDependencyInjectionAdapter(services);

            Ioc.RootContainer = iocContainer;

            return iocContainer;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void ConfigureAppServices(IServiceCollection services)
        {
            services.RegisterForDevelopment();
        }

        
    }
}
