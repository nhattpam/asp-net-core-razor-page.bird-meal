using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.OrderRepository;
using Repository.UserRepository;
using System;

namespace BirdMeal.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        private IOrderRepository orderRepository { get; set; }
        [BindProperty]
        public int OrderCount { get; set; }
        [BindProperty]
        public double IncomeByMonth { get; set; }
        [BindProperty]
        public double IncomeByYear { get; set; }
        [BindProperty]
        public double IncomeByPreviousMonth { get; set; }

        public IndexModel()
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();
        }
        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("ADMIN"))
                {
                    OrderCount = orderRepository.GetOrdersList().Count();
                    IncomeByMonth = TotalOrderPriceByMonth();
                    IncomeByYear= TotalOrderPriceByYear();
                    IncomeByPreviousMonth = TotalOrderPriceByPreviousMonth();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }


        public double TotalOrderPriceByMonth()
        {
            var orders = orderRepository.GetOrdersList();
            var filteredOrders = orders.Where(o => o.OrderDate?.Month == DateTime.Now.Month);
            return filteredOrders.Sum(o => o.TotalPrice ?? 0);
        }

        public double TotalOrderPriceByYear()
        {
            var orders = orderRepository.GetOrdersList();
            var filteredOrders = orders.Where(o => o.OrderDate?.Year == DateTime.Now.Year);
            return filteredOrders.Sum(o => o.TotalPrice ?? 0);
        }

        public double TotalOrderPriceByPreviousMonth()
        {
            var orders = orderRepository.GetOrdersList();
            var previousMonth = DateTime.Now.AddMonths(-1);
            var filteredOrders = orders.Where(o => o.OrderDate?.Month == previousMonth.Month);
            return filteredOrders.Sum(o => o.TotalPrice ?? 0);
        }
    }
}
