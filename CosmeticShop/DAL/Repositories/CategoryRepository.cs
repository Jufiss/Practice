using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Category.ToList();
        }
        public Category? GetCategoryById(int id)
        {
            var Category = db.Category.FirstOrDefault(p => p.Id == id);
            return Category;
        }
        public void Delete(int id)
        {
            var Category = db.Category.Find(id);
            db.Category.Remove(Category);
        }
        public void Add(Category Category)
        {
            db.Category.Add(Category);
        }
        public void Update(Category Category)
        {
            db.Entry(Category).State = EntityState.Modified;
        }
        public bool CategoryExists(int id)
        {
            return db.Category.Any(e => e.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
