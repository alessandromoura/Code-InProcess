using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(Insights.BigPurpleBank.Startup))]

namespace Insights.BigPurpleBank
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Dependency injection for repository classes
            builder.Services.AddScoped<Repositories.IOnPremisesRepository, Repositories.OnPremisesRepository>();


            // Dependency injection for service classes
            builder.Services.AddScoped<Services.IProductsService, Services.ProductsService>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var rootDir = Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot") ??
                          $"{Environment.GetEnvironmentVariable("HOME")}/site/wwwroot";

            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(rootDir)
                                    .AddEnvironmentVariables()
                                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                                    .Build();
        }
    }
}