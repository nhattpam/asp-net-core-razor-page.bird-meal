using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepository
{
    public interface IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail c);
        public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId);

	}
}
