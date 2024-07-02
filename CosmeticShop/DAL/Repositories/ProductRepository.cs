using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Product.Include(p => p.Category).Include(p => p.Firm).ToList();
        }
        public Product? GetProductById(int id)
        {
            var product = db.Product.Include(p => p.Category).Include(p => p.Firm).FirstOrDefault(p => p.Id == id);
            return product;
        }
        public void Delete(int id)
        {
            var product = db.Product.Find(id);
            db.Product.Remove(product);
        }
        public void Add(Product product) 
        {
            db.Product.Add(product);
        }
        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public bool ProductExists(int id)
        {
            return db.Product.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
