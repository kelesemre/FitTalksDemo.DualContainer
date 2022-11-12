
using FitTalksDemo.DualContainer.Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FitTalksDemo.DualContainer.API.Infrastructure.Extensions;

namespace FitTalksDemo.DualContainer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
               .MigrateDatabase<CustomerDbContext>((context, services) => // passing a Action Delegate method from HostExtensions.cs
                {
                   var logger = services.GetService<ILogger<CustomerDbContextSeed>>();
                    CustomerDbContextSeed.SeedAsync(context, logger).Wait(); // after Migration, seed the Db
                })
               .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
