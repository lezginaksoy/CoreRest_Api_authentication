using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATM_Management_CoreRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);

            host.Run();


        }

        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();


        //public static IWebHost BuildWebHost(string[] args) =>
        // WebHost.CreateDefaultBuilder(args)
        // .UseStartup<Startup>()
        //     .ConfigureAppConfiguration((hostContext, config) =>
        //     {
        //            // delete all default configuration providers
        //            //config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
        //            config.Sources.Clear();
        //         config.AddJsonFile("appsettings.json", optional: true);
        //     })
        // .Build();


    }
}
