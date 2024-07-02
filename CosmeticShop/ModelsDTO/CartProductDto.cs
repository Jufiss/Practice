using CosmeticShop.DAL.Models;

namespace CosmeticShop.ModelsDTO
{
    public class CartProductDto
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string? CartId { get; set; }
        public int ProductId { get; set; }
    }
}
