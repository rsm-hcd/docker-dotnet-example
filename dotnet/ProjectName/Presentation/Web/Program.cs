using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjectName.Business.Core.Utilities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            // Configure logging first so everything moving forward can use the same logging
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code);
                
            // Configure application insights if key is provided
            var applicationInsightsKey = System.Environment.GetEnvironmentVariable("WEB_APPLICATION_INSIGHTS_KEY");
            if (!string.IsNullOrWhiteSpace(applicationInsightsKey)) {
                Log.Information("Using Application Insights with Logger");
                logger = logger.WriteTo.ApplicationInsightsEvents(applicationInsightsKey);
            }

            // Instantiate the logger!
            Log.Logger = logger.CreateLogger();

            try
            {
                Log.Information("Starting web host");
                BuildWebHost(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
