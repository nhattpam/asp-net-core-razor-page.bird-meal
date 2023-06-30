using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderRepository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetOrdersList();

    }
}
