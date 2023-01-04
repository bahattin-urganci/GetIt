using GetIt.Core.Domain;

namespace GetIt.Domain.Products.Events;

public class NewProductEvent : DomainEventBase
{
    public string ProductName { get; set; }
    public NewProductEvent(string productName)
    {
        ProductName = productName;
    }
}
