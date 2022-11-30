using GetIt.Domain.Base;

namespace GetIt.Domain.Products
{
    public class Product : AuditEntity
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
    }
}
