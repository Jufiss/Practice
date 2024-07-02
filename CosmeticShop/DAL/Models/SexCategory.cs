namespace CosmeticShop.DAL.Models
{
    public class SexCategory
    {
        public SexCategory()
        {
            Product = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
