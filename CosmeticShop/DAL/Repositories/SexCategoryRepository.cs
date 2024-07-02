using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class SexCategoryRepository : RepositoryBase, ISexCategoryRepository
    {
        public SexCategoryRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<SexCategory> SexCategories()
        {
            return db.SexCategory.ToList();
        }
        public SexCategory? GetSexCategoryById(int id)
        {
            var SexCategory = db.SexCategory.FirstOrDefault(p => p.Id == id);
            return SexCategory;
        }
        public void Delete(int id)
        {
            var SexCategory = db.SexCategory.Find(id);
            db.SexCategory.Remove(SexCategory);
        }
        public void Add(SexCategory SexCategory)
        {
            db.SexCategory.Add(SexCategory);
        }
        public void Update(SexCategory SexCategory)
        {
            db.Entry(SexCategory).State = EntityState.Modified;
        }
        public bool SexCategoryExists(int id)
        {
            return db.SexCategory.Any(e => e.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<SexCategory> GetSexCategories()
        {
            throw new NotImplementedException();
        }
    }
}
