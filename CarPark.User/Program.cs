using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //logging begin
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                //.WriteTo.File("log.txt")
                .WriteTo.Seq("http://localhost:5341/")
                .MinimumLevel.Information()
                .Enrich.WithProperty("ApplicationName", "CarPark.User")
                .Enrich.WithMachineName()
                .CreateLogger();
            //logging end

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                //logging begin
                .UseSerilog() // <-- Add this line
                //logging end
                ;

    }
}
