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
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrderService _orderService, UserManager<User> userManager)
        {
            orderService = _orderService;
            _userManager = userManager;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            var orders = orderService.GetOrders();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{userName}")]
        public async Task<ActionResult<Order>> GetOrder(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var order = orderService.GetOrderById(user.Id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]

        public async Task<ActionResult<Order>> PostOrder(OrderDto orderDto, string userName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(userName);
            var neworder = orderService.Add(orderDto, user);
            orderService.AddOrderProducts(neworder, user);
            return CreatedAtAction("GetOrder", new { id = neworder.Id }, neworder);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutOrder(int id, OrderDto orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }
            
            string errorMessage;

            if (!orderService.Update(id, orderDto, out errorMessage))
            {
                return BadRequest(errorMessage);
            }

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteOrder(int id)
        {
            orderService.Delete(id);
            return NoContent();
        }
    }
}
