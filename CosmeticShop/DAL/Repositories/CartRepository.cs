using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class CartRepository : RepositoryBase, ICartRepository
    {
        public CartRepository(ShopContext context) : base(context)
        {
        }
        public IEnumerable<Cart> GetCarts()
        {
            return db.Cart.Include(p => p.User).Include(p => p.CartProducts).ToList();
        }
        public Cart? GetCartByUserName(string id)
        {
            var cart = db.Cart.Include(p => p.User).Include(p => p.CartProducts).FirstOrDefault(p => p.Id == id);
            return cart;
        }
       
        public void Delete(int id)
        {
            var cartProduct = db.CartProducts.Find(id);
            db.CartProducts.Remove(cartProduct);
        }
        public void Add(Cart cart)
        {
            db.Cart.Add(cart);
        }
        public void AddCartProducts(CartProducts cartProduct) 
        {
            db.CartProducts.Add(cartProduct);
        }
        public void Update(CartProducts cartProduct)
        {
            db.Entry(cartProduct).State = EntityState.Modified;
        }

        public bool CartProductExists(int id)
        {
            return db.CartProducts.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
