using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL
{
    public class FirmBLL : IFirmService
    {
        private IFirmRepository firmRepository;
        public FirmBLL(IFirmRepository _firmRepository) 
        {
            firmRepository = _firmRepository;
        }

        public IEnumerable<Firm> GetFirms()
        {
            return firmRepository.GetFirms();
        }
        public Firm? GetFirmById(int id)
        {
            return firmRepository.GetFirmById(id);
        }

        public void Delete(int id)
        {
            firmRepository.Delete(id);
            Save();
        }
        public Firm Add(Firm firm)
        {
            firmRepository.Add(firm);
            Save();
            return firm;
        }
        public bool Update(int id, Firm firm, out string errorMessage)
        {
            firmRepository.Update(firm);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!firmRepository.FirmExists(id))
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
            firmRepository.Save();
        }
    }
}
