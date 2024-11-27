using OnlineMarket.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Domain.Entities
{
    public class Customer : Auditable
    {
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [MinLength(7), MaxLength(15)]
        public string PhoneNumber { get; set; } = String.Empty;
        public ICollection<Order> Orders { get; set; }
    }
}
