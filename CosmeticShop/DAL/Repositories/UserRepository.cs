using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<User> GetUsers()
        {
            return db.User.ToList();
        }
        public User? GetUserById(string id)
        {
            var User = db.User.FirstOrDefault(p => p.Id == id);
            return User;
        }
        public void Delete(string id)
        {
            var User = db.User.Find(id);
            db.User.Remove(User);
        }
        public void Add(User User)
        {
            db.User.Add(User);
        }
        public void Update(User User)
        {
            db.Entry(User).State = EntityState.Modified;
        }

        public bool UserExists(string id)
        {
            return db.User.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
