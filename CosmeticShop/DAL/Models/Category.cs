namespace CosmeticShop.DAL.Models
{
    public class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageLink { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
