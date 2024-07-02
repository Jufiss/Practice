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
    public class SexCategoryController : ControllerBase
    {
        private readonly ISexCategoryService sexCategoryService;

        public SexCategoryController(ISexCategoryService _sexcategoryService)
        {
            sexCategoryService = _sexcategoryService;
        }

        // GET: api/SexCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SexCategory>>> GetSexCategories()
        {
            var sexcategorys = sexCategoryService.GetSexCategories();
            return Ok(sexcategorys);
        }

        // GET: api/SexCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SexCategory>> GetSexCategory(int id)
        {
            var sexcategory = sexCategoryService.GetSexCategoryById(id);
            if (sexcategory == null)
            {
                return NotFound();
            }
            return Ok(sexcategory);
        }

        // POST: api/SexCategory
        [HttpPost]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<SexCategory>> PostSexCategory(SexCategory sexcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sexcategorynew = sexCategoryService.Add(sexcategory);
            return CreatedAtAction("GetSexCategory", new { id = sexcategorynew.Id }, sexcategorynew);
        }

        // PUT: api/SexCategory/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> PutSexCategory(int id, SexCategory sexcategory)
        {
            if (id != sexcategory.Id)
            {
                return BadRequest();
            }
            string errorMessage;

            if (!sexCategoryService.Update(id, sexcategory, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            
            return NoContent();
        }

        // DELETE: api/SexCategory/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteSexCategory(int id)
        {
            sexCategoryService.Delete(id);
            return NoContent();
        }
    }
}
