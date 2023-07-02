using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.OrderDetailRepository;
using Repository.UserRepository;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Orders
{
    public class DetailOrderModel : PageModel
    {
        [BindProperty]
        public IEnumerable<OrderDetailViewModel> OrdeDetailModel { get; set; }
        public IOrderDetailRepository orderDetailRepository { get; set; }
        public UserViewModel CustomerModel { get; set; }
        public IUserRepository userRepository { get; set; }
        public OrderViewModel orderViewModel { get; set; }
        public DetailOrderModel()
        {
            CustomerModel = new UserViewModel();
            userRepository = new UserRepository();
            orderDetailRepository = new OrderDetailRepository();
            orderViewModel = new OrderViewModel();
        }
        public IActionResult OnGet(int id)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    orderViewModel.OrderId = id;
                    OrdeDetailModel = List();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        public IEnumerable<OrderDetailViewModel> List()
        {
            var orderDetailsByOrderId = orderDetailRepository.GetOrderDetailByOrderId(orderViewModel.OrderId);

            var dtos = orderDetailsByOrderId.Select(oo => new OrderDetailViewModel()
            {
                OrderId = oo.OrderId,
                Quantity = oo.Quantity,
                UnitPrice = oo.UnitPrice,
                OrderDetailId = oo.OrderDetailId,
                MealId = oo.MealId,
                Meal = MapMealToViewModel(oo.Meal)
            });
            return dtos;
        }

        private MealViewModel MapMealToViewModel(Meal meal)
        {
            return new MealViewModel()
            {
              MealId = meal.MealId,
              Description = meal.Description,
              RoutingTime = meal.RoutingTime,
              TotalCost = meal.TotalCost,
            };
        }

        private MealProductViewModel MapMealProductToViewModel(MealProduct mealProduct)
        {
            return new MealProductViewModel()
            {
                MealId = mealProduct.MealId,
               MealProductId = mealProduct.MealProductId,
               ProductId = mealProduct.ProductId,
               Quantity = mealProduct.Quantity
            };
        }

    }
}
