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
        [BindProperty]
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

        public IActionResult OnPost(string mealId, int productId)
        {
            var mealProducts = mealProductRepository.GetMealProductByMealId(mealId);
            var mealProductToDelete = mealProducts.FirstOrDefault(mp => mp.ProductId == productId);
            if (mealProductToDelete != null)
            {
                bool success = mealProductRepository.DeleteMealProduct(mealProductToDelete);

                if (success)
                {
                    TempData["DeleteSuccessMessage"] = "Meal product deleted successfully.";
                }
                else
                {
                    TempData["DeleteErrorMessage"] = "Failed to delete the meal product.";
                }
            }
            return RedirectToPage(new { id = mealId });
        }
        public IEnumerable<MealProductViewModel> List()
        {
            var orderDetailsByOrderId = mealProductRepository.GetMealProductByMealId(mealViewModel.MealId);


            if (orderDetailsByOrderId != null)
            {
                var dtos = orderDetailsByOrderId.Select(oo => new MealProductViewModel()
                {
                    MealId = oo.MealId,
                    Product = MapProductToViewModel(oo.Product),
                    Quantity = oo.Quantity
                });

                return dtos;
            }

            return Enumerable.Empty<MealProductViewModel>();
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
