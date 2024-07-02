using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CosmeticShop.ModelsDTO;
using Microsoft.AspNetCore.Identity;
using CosmeticShop.DAL.Models;
using CosmeticShop.BLL.Services;

namespace CosmeticShop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly UserManager<User> _userManager;
        public CartController(ICartService _cartService, UserManager<User> userManager)
        {
            cartService = _cartService;
            _userManager = userManager;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            var carts = cartService.GetCarts();
            return Ok(carts);
        }

        // GET: api/Cart/5
        [HttpGet("{userName}")]
        public async Task<ActionResult<Cart>> GetCart(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var cart = cartService.GetCartById(user.Id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        // POST: api/Cart
        [HttpPost]

        public async Task<ActionResult<Cart>> PostCart(string userName, CartProductDto CartProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(userName);
            var IsCart = cartService.GetCartById(user.Id);

            if (IsCart == null) 
            {
                cartService.Add(user);
            }

            var cartProduct = cartService.AddCartProducts(CartProductDto, user);
            return CreatedAtAction("GetCart", new { id = cartProduct.Id }, cartProduct);
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutCart(int id, CartProductDto CartProductDto)
        {
            if (id != CartProductDto.Id)
            {
                return BadRequest();
            }

            string errorMessage;

            if (!cartService.Update(id, CartProductDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return NoContent();
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCart(int id)
        {

            cartService.Delete(id);
            return NoContent();
        }
    }
}
