namespace CosmeticShop.DAL.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ImageLink { get; set; }
        public virtual Product Product { get; set; }
    }
}
