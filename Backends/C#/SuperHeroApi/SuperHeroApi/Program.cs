using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SuperHeroCore.Infrastructure;
using SuperHeroCore.Infrastructure.Behavior;
using SuperHeroCore.Logs.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                  .Enrich.FromLogContext()
                  .WriteTo.Console()
                  .WriteTo.Seq("http://localhost:5341")
                  .CreateLogger();

            Log.Information("Starting aplication...");

            CreateHostBuilder(args).Build().Run();
        }

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .CaptureStartupErrors(true)
                          .ConfigureAppConfiguration((context, builder) =>
                          {
                              builder.AddConfiguration(configuration);
                          })
                          .UseStartup<Startup>()
                          .UseContentRoot(Directory.GetCurrentDirectory())
                          .UseSerilog()
                          .Build();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });
    }
}
