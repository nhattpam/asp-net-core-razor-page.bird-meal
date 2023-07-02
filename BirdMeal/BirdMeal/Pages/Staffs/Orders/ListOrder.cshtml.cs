using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.OrderRepository;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Orders
{
    public class ListOrderModel : PageModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
        public IOrderRepository orderRepository { get; set; }
        public UserViewModel CustomerModel { get; set; }
        public IUserRepository userRepository { get; set; }

        public ListOrderModel()
        {
            orderRepository = new OrderRepository();
            CustomerModel = new UserViewModel();
            userRepository = new UserRepository();
        }

        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    Orders = List();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        public IEnumerable<OrderViewModel> List()
        {
            var orders = orderRepository.GetOrdersList();
            DateTime dateTime = DateTime.Now;
            var dtos = orders.Select(oo => new OrderViewModel()
            {
                OrderId = oo.OrderId,
                OrderDate = oo.OrderDate,
                Status   = oo.Status,
                TotalPrice = oo.TotalPrice,
                UserId = oo.UserId,
                User = MapUserToViewModel(oo.User)
            });

            return dtos;
        }

        private UserViewModel MapUserToViewModel(User user)
        {
            return new UserViewModel()
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Role = user.Role,
                WalletId = user.WalletId
            };
        }
    }
}
