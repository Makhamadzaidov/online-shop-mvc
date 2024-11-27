using OnlineMarket.Domain.Commons;
using OnlineMarket.Domain.Enums;

namespace OnlineMarket.Domain.Entities
{
    public class Order : Auditable
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
