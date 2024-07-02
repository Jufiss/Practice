using CosmeticShop.DAL.Models;

namespace CosmeticShop.ModelsDTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Number { get; set; }
        public int OrderStatusId { get; set; }
        public string? UserId { get; set; }
        public decimal Sum { get; set; }
        public DateTime OrderDate { get; set; }
        
    }
}
