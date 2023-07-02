using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        // Using Singleton Pattern
        private static OrderDAO instance = null;
        private static object instanceLook = new object();

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrdersList()
        {
            IEnumerable<Order> orders = null;

            try
            {
                var context = new BirdMealContext();
                // Get From Database
                orders = context.Orders.Include(o => o.User);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orders;
        }

        public void AddOrder(Order c)
        {

            try
            {
                var context = new BirdMealContext();
                context.Orders.Add(c);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Order> GetOrders(int customerId)
        {
            IEnumerable<Order> os = null;

            try
            {

                var context = new BirdMealContext();
                os = context.Orders.Include(pro => pro.User)
                    .Where(c => c.UserId == customerId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return os;
        }
    }
}
