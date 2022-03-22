﻿using Microsoft.Extensions.Hosting;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Sales
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Sales";

            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Sales");
                    endpointConfiguration.UseTransport<LearningTransport>();
                    return endpointConfiguration;
                })
                .RunConsoleAsync();
        }
    }
}
