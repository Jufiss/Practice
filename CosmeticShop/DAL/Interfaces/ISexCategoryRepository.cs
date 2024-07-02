using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Interfaces
{
    public interface ISexCategoryRepository
    {
        IEnumerable<SexCategory> GetSexCategories();
        SexCategory GetSexCategoryById(int id);
        void Delete(int id);
        void Add(SexCategory sexCategory);
        void Update(SexCategory sexCategory);
        public bool SexCategoryExists(int id);
        void Save();
    }
}
