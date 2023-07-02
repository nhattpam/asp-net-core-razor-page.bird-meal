using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrdersList()
        {
            return OrderDAO.Instance.GetOrdersList();
        }
        public void AddOrder(Order c)
        {
            OrderDAO.Instance.AddOrder(c);
        }
        public IEnumerable<Order> GetOrders(int customerId)
        {
            return OrderDAO.Instance.GetOrders(customerId);
        }
    }
}
