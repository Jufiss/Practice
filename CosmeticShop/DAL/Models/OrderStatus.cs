namespace CosmeticShop.DAL.Models
{
    public class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
