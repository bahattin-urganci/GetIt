using GetIt.Domain.Base;
using GetIt.Domain.Products.Events;

namespace GetIt.Domain.Products
{
    public class Product : AuditEntity
    {
        protected Product() { }
        public Product(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public void AddNewProductEvent()
        {
            AddDomainEvent(new NewProductEvent(Name));
        }
    }
}
