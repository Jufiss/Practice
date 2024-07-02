using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsers();
        public User? GetUserById(string id);

        public void Delete(string id);
        public User Add(UserDto userDto);
        public bool Update(string id, UserDto userDto, out string errorMessage);

        public void Save();
    }
}
