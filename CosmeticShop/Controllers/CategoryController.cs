using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using CosmeticShop.DAL.Models;
using CosmeticShop.BLL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmeticShop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var categorys = categoryService.GetCategories();
            return Ok(categorys);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<Product>> PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categorynew = categoryService.Add(category);
            return CreatedAtAction("GetCategory", new { id = categorynew.Id }, categorynew);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            string errorMessage;

            if (!categoryService.Update(id, category, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return NoContent();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            categoryService.Delete(id);
            return NoContent();
        }
    }
}
