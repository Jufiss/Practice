using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;

namespace CosmeticShop.BLL.Services
{
    public interface IFirmService
    {
        public IEnumerable<Firm> GetFirms();
        public Firm? GetFirmById(int id);

        public void Delete(int id);
        public Firm Add(Firm firm);
        public bool Update(int id, Firm firm, out string errorMessage);

        public void Save();
    }
}
