using GetIt.Domain.Base;

namespace GetIt.Domain.Orders
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
