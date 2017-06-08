using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services;
using Services.Mocks;
using Services.Services;
using BrokerContext = Broker.DbModels.BrokerContext;

namespace Broker
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IRegistryService, RegistryService>(_ => new RegistryService(Configuration.GetSection("RegistryApiAddress").Value));
            services.AddTransient<ITaxService, TaxService>(_ => new TaxService(Configuration.GetSection("TaxApiAddress").Value));
            services.AddDbContext<BrokerContext>(options => options.UseMySql(GetConnectionString()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        public static string GetConnectionString()
        {
            return $"Server={Configuration.GetSection("dbhost")};"
            + $"User Id={Configuration.GetSection("dbuser")};"
            + $"Password={Configuration.GetSection("dbpassword")};"
            + $"Database={Configuration.GetSection("dbdatabase")}";
        }
    }
}
