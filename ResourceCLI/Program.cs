using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using ResourceCLI.Commands;

// DI, Serilog, Settings

namespace ResourceCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<AppInstance>();
                    services.AddTransient<IKnowledgeRepo, LiteDbRepo>();
                    
                    services.AddTransient<Create>();
                    services.AddTransient<List>();
                    services.AddTransient<Remove>();
                    services.AddTransient<RemoveOne>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<AppInstance>(host.Services);

            svc.Run(args);
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true).AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                    true).AddEnvironmentVariables();
        }
    }
}