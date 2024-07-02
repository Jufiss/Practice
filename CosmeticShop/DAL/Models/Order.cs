using System.Numerics;

namespace CosmeticShop.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public int OrderStatusId { get; set; }
        public string UserId { get; set; }
        public decimal Sum { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
