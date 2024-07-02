using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL
{
    public class CartBLL : ICartService
    {
        private ICartRepository cartRepository;

        public CartBLL(ICartRepository _cartRepository)
        {
            cartRepository = _cartRepository;
        }
        public IEnumerable<Cart> GetCarts()
        {
            return cartRepository.GetCarts();
        }
        public Cart? GetCartById(string id)
        {
            return cartRepository.GetCartByUserName(id);
        }
        public void Delete(int id)
        {
            cartRepository.Delete(id);
            Save();
        }
        public Cart Add(User user)
        {
            var cart = new Cart
            {
                Id = user.Id,
                UserId = user.Id
            };
            cartRepository.Add(cart);
            Save();
            return cart;
        }
        public CartProducts AddCartProducts(CartProductDto CartProductDto, User user)
        {
            var cartProduct = new CartProducts
            {
                Count = CartProductDto.Count,
                CartId = user.Id,
                ProductId = CartProductDto.ProductId
            };
            cartRepository.AddCartProducts(cartProduct);
            cartRepository.Save();
            return cartProduct;

        }
        public bool Update(int id, CartProductDto cartProductDto, out string errorMessage)
        {
            var cartProduct = new CartProducts
            {
                Id = cartProductDto.Id,
                CartId = cartProductDto.CartId,
                Count = cartProductDto.Count,
                ProductId = cartProductDto.ProductId
            }; 
            cartRepository.Update(cartProduct);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!cartRepository.CartProductExists(id))
                {
                    errorMessage = "There was a problem: " + ae.Message;
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public void Save()
        {
            cartRepository.Save();
        }
    }
}
