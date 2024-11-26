using OnlineMarket.Domain.Commons;

namespace OnlineMarket.Domain.Entities
{
    public class Customer : Auditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
