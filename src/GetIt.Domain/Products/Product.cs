using GetIt.Domain.Base;

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
    }
}
