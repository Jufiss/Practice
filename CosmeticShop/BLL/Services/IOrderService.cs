using CosmeticShop.DAL.Models;
using CosmeticShop.DAL.Repositories;
using CosmeticShop.ModelsDTO;

namespace CosmeticShop.BLL.Services
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetOrders();
        public IEnumerable<OrderStatus> GetOrderStatuses();
        public Order? GetOrderById(string id);
        public OrderStatus? GetOrderStatusById(int id);
        public void Delete(int id);
        public Order Add(OrderDto orderDto, User user);
        public void AddOrderProducts(Order neworder, User user);
        public bool Update(int id, OrderDto orderDto, out string errorMessage);
        public void Save();
    }
}
