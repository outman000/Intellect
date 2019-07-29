using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace IntellWeChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
             .MinimumLevel.Override("Dto.Service", LogEventLevel.Information)
             .WriteTo .File(
                "logs/log.txt",
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: 1_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1)
                )

             .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Build().Run();
          
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
 
            }
            finally
            {
                Log.CloseAndFlush();
            }



        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                   .UseSerilog();

    }
}
