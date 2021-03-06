﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection; //Добавлено
using ACSWeb.Data; //Добавлено

namespace ACSWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //    BuildWebHost(args).Run();  //original

            //--------- для ініціалізаці БД у разі її відсутності або пустоти
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<GTSContext>();
                    // DbInitializer.Initialize(context); //не пробовать инициализировать БД
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
            //---------------------------------------------------------------------
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
