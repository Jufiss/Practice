using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Repositories
{
    public class RepositoryBase
    {
        public ShopContext db;
        public RepositoryBase(ShopContext context)
        {
            db = context;
        }
    }
}
