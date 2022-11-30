using GetIt.Domain.Base;

namespace GetIt.Domain.Orders
{
    public class OrderDetail : AuditEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}