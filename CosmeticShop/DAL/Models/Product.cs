using System.ComponentModel.DataAnnotations;

namespace CosmeticShop.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductSize> ProductSize { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
        public decimal Price { get; set; }
        public int SexCategoryId { get; set; }
        public virtual SexCategory SexCategory { get; set; }

    }
}
