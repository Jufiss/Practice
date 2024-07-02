using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }
        public IEnumerable<Order> GetOrders()
        {
            return db.Order.Include(p => p.User).Include(p => p.OrderStatus).Include(p => p.OrderProducts).ToList();
        }
        public IEnumerable<OrderStatus> GetOrderStatuses()
        {
            return db.OrderStatus.ToList();
        }
        public Order? GetOrderById(string id)
        {
            var order = db.Order.Include(p => p.User).Include(p => p.OrderStatus).Include(p => p.OrderProducts).FirstOrDefault(p => p.UserId == id);
            return order;
        }
        public OrderStatus? GetOrderStatusById(int id) 
        {
            return db.OrderStatus.Find(id);
        }
        public void Delete(int id)
        {
            var order = db.Order.Find(id);
            db.Order.Remove(order);
        }
        public void Add(Order order)
        {
            db.Order.Add(order);
        }
        public void AddOrderProducts(OrderProducts orderProducts)
        {
            db.OrderProducts.Add(orderProducts);
        }
        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public bool OrderExists(int id)
        {
            return db.Order.Any(e => e.Id == id);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
