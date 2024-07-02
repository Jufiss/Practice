using Microsoft.AspNetCore.Mvc;
using CosmeticShop.ModelsDTO;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        [Authorize(Roles = "admin")]

        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = productService.Add(productDto);
           
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]

        public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }
            string errorMessage;

            if (!productService.Update(id, productDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }
            
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            productService.Delete(id);
            return NoContent();
        }
    }
}

