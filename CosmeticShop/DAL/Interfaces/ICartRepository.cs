using CosmeticShop.DAL.Models;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.DAL.Interfaces
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetCarts();
        Cart GetCartByUserName(string userName);
        void Delete(int id);
        void Add(Cart cart);
        public void AddCartProducts(CartProducts CartProducts);
        void Update(CartProducts cartProduct);
        public bool CartProductExists(int id);
        void Save();
    }
}
