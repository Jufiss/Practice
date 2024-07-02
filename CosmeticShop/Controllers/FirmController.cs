using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmeticShop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class FirmController : ControllerBase
    {
        private readonly IFirmService firmService;

        public FirmController(IFirmService _firmService)
        {
            firmService = _firmService;
        }

        // GET: api/Firm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firm>>> GetFirm()
        {
            var firms = firmService.GetFirms();
            return Ok(firms);
        }

        // GET: api/Firm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Firm>> GetFirm(int id)
        {
            var firm = firmService.GetFirmById(id);
            if (firm == null)
            {
                return NotFound();
            }
            return Ok(firm);
        }

        // POST: api/Firm
        [HttpPost]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<Firm>> PostFirm(Firm firm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var firmnew = firmService.Add(firm);
            return CreatedAtAction("GetFirm", new { id = firmnew.Id }, firmnew);
        }

        // PUT: api/Firm/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> PutFirm(int id, Firm firm)
        {
            if (id != firm.Id)
            {
                return BadRequest();
            }
            string errorMessage;

            if (!firmService.Update(id, firm, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            
            return NoContent();
        }

        // DELETE: api/Firm/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteFirm(int id)
        {
            firmService.Delete(id);
            return NoContent();
        }
    }
}
