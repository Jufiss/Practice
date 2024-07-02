namespace CosmeticShop.DAL.Models
{
    public class Firm
    {
        public Firm()
        {
            Product = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
