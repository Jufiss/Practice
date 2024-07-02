using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;

namespace CosmeticShop.BLL.Services
{
    public interface ICategoryService
    {
        public IEnumerable<Category> GetCategories();
        public Category? GetCategoryById(int id);

        public void Delete(int id);
        public Category Add(Category category);
        public bool Update(int id, Category category, out string errorMessage);

        public void Save();
    }
}
