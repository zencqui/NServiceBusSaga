﻿using Microsoft.Extensions.Hosting;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Billing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Billing";

            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Billing");
                    endpointConfiguration.UseTransport<LearningTransport>();
                    return endpointConfiguration;
                })
                .RunConsoleAsync();
        }
    }
}
