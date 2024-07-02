using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product? GetProductById(int id);
        void Delete(int id);
        void Add(Product product);
        void Update(Product product);
        void Save();
        bool ProductExists(int id);
    }
}
