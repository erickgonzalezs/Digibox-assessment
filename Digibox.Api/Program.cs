using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Digibox.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(Configuration)
        .CreateLogger();
   
      CreateHostBuilder(args)
        .Build()
        .Run();
    



    }

    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
      .Build();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) => config
          .SetBasePath(
            hostingContext.HostingEnvironment.ContentRootPath)
          .AddJsonFile("appsettings.json", true, true)
          .AddJsonFile(
            $"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json",
            true, true)
          .AddJsonFile(
            $"configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json",
            optional: true,
            reloadOnChange: true)
          .AddEnvironmentVariables())
        .ConfigureWebHostDefaults(webBuilder => webBuilder
          .UseSerilog((_, config) => config.ReadFrom.Configuration(_.Configuration))
          .UseStartup<Startup>());
  }
}
