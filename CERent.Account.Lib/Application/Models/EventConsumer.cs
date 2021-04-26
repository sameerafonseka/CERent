using CERent.Core.Lib.QueueModels;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Account.Lib.Application.Models
{
    public class EventConsumer : IConsumer<LoginNotification>
    {
        ILogger<EventConsumer> _logger;

        public EventConsumer(ILogger<EventConsumer> logger)
        {
            _logger = logger;
        }

        async Task IConsumer<LoginNotification>.Consume(ConsumeContext<LoginNotification> context)
        {
            _logger.LogInformation("Value: {Value}", context.Message.Email);
        }
    }
}
