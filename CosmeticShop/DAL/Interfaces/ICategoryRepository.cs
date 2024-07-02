using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void Delete(int id);
        void Add(Category category);
        void Update(Category category);
        public bool CategoryExists(int id);
        void Save();
    }
}
