using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Interfaces
{
    public interface IFirmRepository
    {
        IEnumerable<Firm> GetFirms();
        Firm GetFirmById(int id);
        void Delete(int id);
        void Add(Firm firm);
        void Update(Firm firm);
        public bool FirmExists(int id);
        void Save();
    }
}
