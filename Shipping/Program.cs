﻿using Microsoft.Extensions.Hosting;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Shipping
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Shipping";

            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Shipping");
                    endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UsePersistence<LearningPersistence>();
                    return endpointConfiguration;
                })
                .RunConsoleAsync();
        }
    }
}
