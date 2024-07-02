using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;

namespace CosmeticShop.BLL.Services
{
    public interface ISexCategoryService
    {
        public IEnumerable<SexCategory> GetSexCategories();
        public SexCategory? GetSexCategoryById(int id);

        public void Delete(int id);
        public SexCategory Add(SexCategory sexCategory);
        public bool Update(int id, SexCategory sexCategory, out string errorMessage);

        public void Save();
    }
}
