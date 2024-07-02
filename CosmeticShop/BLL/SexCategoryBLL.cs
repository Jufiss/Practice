using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL
{
    public class SexCategoryBLL : ISexCategoryService
    {
        private ISexCategoryRepository sexCategoryRepository;
        public SexCategoryBLL(ISexCategoryRepository _sexCategoryRepository) 
        {
            sexCategoryRepository = _sexCategoryRepository;
        }

        public IEnumerable<SexCategory> GetSexCategories()
        {
            return sexCategoryRepository.GetSexCategories();
        }
        public SexCategory? GetSexCategoryById(int id)
        {
            return sexCategoryRepository.GetSexCategoryById(id);
        }

        public void Delete(int id)
        {
            sexCategoryRepository.Delete(id);
            Save();
        }
        public SexCategory Add(SexCategory sexCategory)
        {
            sexCategoryRepository.Add(sexCategory);
            Save();
            return sexCategory;
        }
        public bool Update(int id, SexCategory sexCategory, out string errorMessage)
        {
            sexCategoryRepository.Update(sexCategory);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!sexCategoryRepository.SexCategoryExists(id))
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
            sexCategoryRepository.Save();
        }
    }
}
