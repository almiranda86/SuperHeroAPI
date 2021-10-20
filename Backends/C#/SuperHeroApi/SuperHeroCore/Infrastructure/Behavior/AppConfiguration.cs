using Microsoft.Extensions.Configuration;
using System;

namespace SuperHeroCore.Infrastructure.Behavior
{
    public static class AppConfiguration
    {
        public static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true, reloadOnChange: false)
                .Build();
        }

        public static IConfigurationRoot GetConfiguration(string fileName)
        {
            return new ConfigurationBuilder()
                .AddJsonFile(fileName, optional: true, reloadOnChange: false)
                .Build();
        }
    }
}
