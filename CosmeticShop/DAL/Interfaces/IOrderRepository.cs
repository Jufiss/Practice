using CosmeticShop.DAL.Models;

namespace CosmeticShop.DAL.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        IEnumerable<OrderStatus> GetOrderStatuses();
        Order GetOrderById(string id);
        OrderStatus GetOrderStatusById(int id);
        void Delete(int id);
        void Add(Order order);
        public void AddOrderProducts(OrderProducts orderProducts);
        void Update(Order order);
        public bool OrderExists(int id);
        void Save();
    }
}
