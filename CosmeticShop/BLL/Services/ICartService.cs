using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL.Services
{
    public interface ICartService
    {
        public IEnumerable<Cart> GetCarts();
        public Cart? GetCartById(string id);
        public void Delete(int id);
        public Cart Add(User user);
        public CartProducts AddCartProducts(CartProductDto CartProductDto, User user);
        public bool Update(int id, CartProductDto cartProductDto, out string errorMessage);

        public void Save();
    }
}
