using GetIt.Domain.Products.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Application.Products.Events
{
    public class NewProductEventHandler : INotificationHandler<NewProductEvent>
    {
        private readonly ILogger<NewProductEventHandler> _logger;

        public NewProductEventHandler(ILogger<NewProductEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NewProductEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("new product added:{productName}", notification.ProductName);
            //push notification
            //email            
            return Task.CompletedTask;
        }
    }
}
