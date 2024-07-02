namespace CosmeticShop.DAL.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal? Sum { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartProducts> CartProducts { get; set; }
    }
}
