using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();
        public Product? GetProductById(int id);
        public void Delete(int id);
        public Product Add(ProductDto productDto);
        public bool Update(int id, ProductDto productDto, out string errorMessage);

        public void Save();
    }
}
