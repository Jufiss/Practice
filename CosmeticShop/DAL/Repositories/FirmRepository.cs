using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class FirmRepository : RepositoryBase, IFirmRepository
    {
        public FirmRepository(ShopContext context) : base(context)
        {
        }

        public IEnumerable<Firm> GetFirms()
        {
            return db.Firm.ToList();
        }
        public Firm? GetFirmById(int id)
        {
            var Firm = db.Firm.FirstOrDefault(p => p.Id == id);
            return Firm;
        }
        public void Delete(int id)
        {
            var Firm = db.Firm.Find(id);
            db.Firm.Remove(Firm);
        }
        public void Add(Firm Firm)
        {
            db.Firm.Add(Firm);
        }
        public void Update(Firm Firm)
        {
            db.Entry(Firm).State = EntityState.Modified;
        }
        public bool FirmExists(int id)
        {
            return db.Firm.Any(e => e.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
