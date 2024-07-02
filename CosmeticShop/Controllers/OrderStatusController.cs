using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CosmeticShop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderStatusController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        // GET: api/OrderStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatus>>> GetOrderStatus()
        {
            var orders = orderService.GetOrderStatuses();
            return Ok(orders);
        }

        // GET: api/OrderStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatus>> GetOrderStatus(int id)
        {
            var orderStatus = orderService.GetOrderStatusById(id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            return Ok(orderStatus);
        }
    }
}
