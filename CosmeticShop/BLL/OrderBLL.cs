using CosmeticShop.BLL.Services;
using CosmeticShop.DAL.Interfaces;
using CosmeticShop.DAL.Models;
using CosmeticShop.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace CosmeticShop.BLL
{
    public class OrderBLL : IOrderService
    {
        private IOrderRepository orderRepository;
        private ICartRepository cartRepository;

        public OrderBLL(IOrderRepository _orderRepository, ICartRepository _cartRepository)
        {
            orderRepository = _orderRepository;
            cartRepository = _cartRepository;
        }
        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetOrders();
        }
        public IEnumerable<OrderStatus> GetOrderStatuses()
        {
            return orderRepository.GetOrderStatuses();
        }
        public Order? GetOrderById(string id)
        {
            return orderRepository.GetOrderById(id);
        }
        public OrderStatus? GetOrderStatusById(int id)
        {
            return orderRepository.GetOrderStatusById(id);
        }
        public void Delete(int id)
        {
            orderRepository.Delete(id);
            Save();
        }
        public Order Add(OrderDto orderDto, User user)
        {
            var userUniquePart = user.Id.ToString().Substring(0, 5);
            var currentDate = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                Number = $"{userUniquePart}-{currentDate}",
                OrderStatusId = orderDto.OrderStatusId,
                Sum = orderDto.Sum,
                UserId = user.Id
            };

            orderRepository.Add(order);
            Save();
            return order;
        }
        public void AddOrderProducts(Order neworder, User user)
        {
            var userCart = cartRepository.GetCartByUserName(user.Id);
            var products = userCart.CartProducts.ToList();

            for (int i = 0; i < products.Count; i++)
            {
                var orderProduct = new OrderProducts
                {
                    OrderId = neworder.Id,
                    Count = products[i].Count,
                    ProductId = products[i].ProductId
                };
                orderRepository.AddOrderProducts(orderProduct);
            }

            orderRepository.Save();
        }
        public bool Update(int id, OrderDto orderDto, out string errorMessage)
        {
            var status = orderRepository.GetOrderStatusById(orderDto.OrderStatusId);
            var order = new Order
            {
                Id = orderDto.Id,
                OrderDate = orderDto.OrderDate,
                Number = orderDto.Number,
                OrderStatus = status,
                OrderStatusId = orderDto.OrderStatusId,
                Sum = orderDto.Sum,
                UserId = orderDto.UserId
            };
            orderRepository.Update(order);

            try
            {
                Save();
                errorMessage = null;
                return true;
            }
            catch (ArgumentException ae)
            {
                if (!orderRepository.OrderExists(id))
                {
                    errorMessage = "There was a problem: " + ae.Message;
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        public void Save()
        {
            orderRepository.Save();
        }
    }
}
