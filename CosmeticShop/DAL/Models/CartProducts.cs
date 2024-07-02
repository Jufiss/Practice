namespace CosmeticShop.DAL.Models
{
    public class CartProducts
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }

    }
}
