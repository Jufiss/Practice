using CosmeticShop.DAL.Models;

namespace CosmeticShop.ModelsDTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Weight { get; set; }
        public string? UseMethod { get; set; }
        public string? ImageLink { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int SexCategoryId { get; set; }
        public string? Color { get; set; }
        public string? Smell { get; set; }
    }
}
