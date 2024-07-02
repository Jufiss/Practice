using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(string id);
        void Delete(string id);
        void Add(User user);
        void Update(User user);
        public bool UserExists(string id);
        void Save();
    }
}
