using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            await Task.Delay(TimeSpan.FromSeconds(20));

            log.Info($"Receioved OrderPlaced, OrderId = {message.OrderId}");

            await context.Publish(new OrderBilled { OrderId = message.OrderId });
        }

        static ILog log = LogManager.GetLogger<OrderPlacedHandler>();
    }
}
