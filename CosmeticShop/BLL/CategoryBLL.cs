using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;

namespace CosmeticShop.BLL
{
    public class CategoryBLL : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        public CategoryBLL(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetCategories();
        }
        public Category? GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
            Save();
        }
        public Category Add(Category category)
        {
            categoryRepository.Add(category);
            Save();
            return category;
        }
        public bool Update(int id, Category category, out string errorMessage)
        {
            categoryRepository.Update(category);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!categoryRepository.CategoryExists(id))
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
            categoryRepository.Save();
        }
    }
}
