using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

namespace CosmeticShop.DAL.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Order = new HashSet<Order>();
            Cart = new HashSet<Cart>();
        }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }

    }
}
