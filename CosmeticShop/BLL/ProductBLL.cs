using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL
{
    public class ProductBLL : IProductService
    {

        private IProductRepository productRepository;
        private ISexCategoryRepository sexCategoryRepository;
        private ICategoryRepository categoryRepository;

        public ProductBLL(IProductRepository _productRepository, ISexCategoryRepository _sexCategoryRepository, ICategoryRepository _categoryRepository)
        {
            productRepository = _productRepository;
            sexCategoryRepository = _sexCategoryRepository;
            categoryRepository = _categoryRepository;
        }
        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }
        public Product? GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }
        public void Delete(int id)
        {
            productRepository.Delete(id);
            Save();
        }
        public Product Add(ProductDto productDto)
        {
            var sexCategory = sexCategoryRepository.GetSexCategoryById(productDto.SexCategoryId);
            var category = categoryRepository.GetCategoryById(productDto.CategoryId);
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                SexCategoryId = productDto.SexCategoryId,
                SexCategory = sexCategory,
                Category = category,
                CategoryId = productDto.CategoryId,
                //Color = productDto.Color,
                //Count = productDto.Count,
                //Smell = productDto.Smell,
                //ImageLink = productDto.ImageLink,
                //UseMethod = productDto.UseMethod,
                //Weight = productDto.Weight,
            };
            productRepository.Add(product);
            productRepository.Save();
            return product;
        }
        public bool Update(int id, ProductDto productDto, out string errorMessage)
        {
            var sexCategory = sexCategoryRepository.GetSexCategoryById(productDto.SexCategoryId);
            var category = categoryRepository.GetCategoryById(productDto.CategoryId);
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                SexCategoryId = productDto.SexCategoryId,
                SexCategory = sexCategory,
                Category = category,
                CategoryId = productDto.CategoryId,
                //Color = productDto.Color,
                //Count = productDto.Count,
                //Smell = productDto.Smell,
                //ImageLink = productDto.ImageLink,
                //UseMethod = productDto.UseMethod,
                //Weight = productDto.Weight,
            };
            productRepository.Update(product);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!productRepository.ProductExists(id))
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
            productRepository.Save();
        }

    }
}
