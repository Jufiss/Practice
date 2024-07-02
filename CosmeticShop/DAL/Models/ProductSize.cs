namespace CosmeticShop.DAL.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int? Count { get; set; }
    }
}
