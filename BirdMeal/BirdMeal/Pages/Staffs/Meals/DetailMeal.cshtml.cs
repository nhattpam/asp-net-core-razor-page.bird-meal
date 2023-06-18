using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealProductRepository;
using Repository.UserRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages.Staffs.Meals
{
    public class DetailMealModel : PageModel
    {
        public IUserRepository userRepository { get; set; }
        public IEnumerable<MealProductViewModel> ListMealProductsDetail { get; set; }
        public IMealProductRepository mealProductRepository { get; set; }
        public MealViewModel mealViewModel { get; set; }

        public DetailMealModel()
        {
            userRepository= new UserRepository();
            mealProductRepository = new MealProductRepository();
            mealViewModel = new MealViewModel();
        }
        public IActionResult OnGet(string id)
        {
            string loginMem = HttpContext.Session.GetString("loginMem");
            if (loginMem != null)
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u != null && u.Role.Equals("STAFF"))
                {
                    mealViewModel.MealId = id;
                    ListMealProductsDetail = List();
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }

        public IEnumerable<MealProductViewModel> List()
        {
            var orderDetailsByOrderId = mealProductRepository.GetMealProductByMealId(mealViewModel.MealId);

            var dtos = orderDetailsByOrderId.Select(oo => new MealProductViewModel()
            {
               MealId = oo.MealId,
               Product = MapProductToViewModel(oo.Product),
               Quantity = oo.Quantity
            });
            return dtos;
        }

        private ProductViewModel MapProductToViewModel(Product product)
        {
            return new ProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity  = product.Quantity,
                Price = product.Price
            };
        }
    }
}
