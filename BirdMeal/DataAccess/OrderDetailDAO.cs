using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        // Using Singleton Pattern
        private static OrderDetailDAO instance = null;
        private static object instanceLook = new object();

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public void AddOrderDetail(OrderDetail c)
        {

            try
            {
                var context = new BirdMealContext();
                context.OrderDetails.Add(c);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderDetail GeIOrderDetailByOrderId(int orderlId)
		{
			OrderDetail p = null;

			try
			{

				var context = new BirdMealContext();
				p = context.OrderDetails.SingleOrDefault(f => f.OrderId.Equals(orderlId));

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return p;
		}
	}
}
