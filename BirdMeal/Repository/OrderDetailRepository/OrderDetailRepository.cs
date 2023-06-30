using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.OrderDetailRepository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail c)
        {
            OrderDetailDAO.Instance.AddOrderDetail(c);
        }

		public IEnumerable<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);
		}

	}
}
