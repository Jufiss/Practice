using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL
{
    public class UserBLL : IUserService
    {
        private IUserRepository UserRepository;
        public UserBLL(IUserRepository _UserRepository)
        {
            UserRepository = _UserRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return UserRepository.GetUsers();
        }
        public User? GetUserById(string id)
        {
            return UserRepository.GetUserById(id);
        }

        public void Delete(string id)
        {
            UserRepository.Delete(id);
            Save();
        }
        public User Add(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,
            };

            UserRepository.Add(user);
            Save();
            return user;
        }
        public bool Update(string id, UserDto userDto, out string errorMessage)
        {
            var user = new User
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,
            };

            UserRepository.Update(user);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!UserRepository.UserExists(id))
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
            UserRepository.Save();
        }
    }
}
