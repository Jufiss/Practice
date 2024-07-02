namespace CosmeticShop.DAL.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductSize> ProductSize { get; set; }
    }
}
