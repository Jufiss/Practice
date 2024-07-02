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


        //public ShopContext db;
        //public RepositoryBase()
        //{
        //    db = new ShopContext();
        //}
    }
}
