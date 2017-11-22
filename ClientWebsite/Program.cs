﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ClientWebsite.Data;

namespace ClientWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            ExternalDataProvider.Initialize().Wait();
            HistoryAPIDataProvider.Initialize().Wait();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}