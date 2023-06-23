using BirdMeal.Pages.Staffs.Products;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealProductRepository;
using Repository.MealRepository;
using Repository.ProductRepository;
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
        private IProductRepository productRepository { get; set; }
        public IEnumerable<ProductViewModel> ListProducts { get; set; }
        [BindProperty]
        public MealProductViewModel AddMealProduct { get; set; }

        [BindProperty]
        public float? Total { get; set; }

        private IMealRepository mealRepository { get; set; }


        public DetailMealModel()
        {
            userRepository= new UserRepository();
            mealProductRepository = new MealProductRepository();
            mealViewModel = new MealViewModel();
            productRepository = new ProductRepository();
            AddMealProduct = new MealProductViewModel();
            mealRepository = new MealRepository();
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
                    ListProducts = ListProductModel();
                    
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Error");
        }
        //DELETE
        public IActionResult OnPost(string mealId, int productId, float? total)
        {
            var mealProducts = mealProductRepository.GetMealProductByMealId(mealId);
            var mealProductToDelete = mealProducts.FirstOrDefault(mp => mp.ProductId == productId);
            if (mealProductToDelete != null)
            {
                bool success = mealProductRepository.DeleteMealProduct(mealProductToDelete);

                if (success)
                {
                    var meal = mealRepository.GeMealById(mealId);
                    meal.TotalCost = mealProducts.Sum(mp => mp.Product.Price * mp.Quantity); // Calculate the updated total

                    mealRepository.UpdateMeal(meal);
                    TempData["DeleteSuccessMessage"] = "Meal product deleted successfully.";
                }
                else
                {
                    TempData["DeleteErrorMessage"] = "Failed to delete the meal product.";
                }
            }
            return RedirectToPage(new { id = mealId });
        }

        //ADD
        public IActionResult OnPostAddProduct(string mealId)
        {
            if (AddMealProduct.Quantity == null)
            {
                TempData["DeleteErrorMessage"] = "Quantity is required.";
                return RedirectToPage(new { id = mealId });
            }
            var mealproduct = new MealProduct()
            {
                MealId = mealId,
                ProductId = AddMealProduct.ProductId,
                Quantity = AddMealProduct.Quantity
            };
            

            bool success = mealProductRepository.AddMealProduct(mealproduct);
            if (success)
            {
                var meal = mealRepository.GeMealById(mealId);
                meal.TotalCost = Total;
                mealRepository.UpdateMeal(meal);
                TempData["DeleteSuccessMessage"] = "Meal product created successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to create the meal product.";
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
        private IEnumerable<ProductViewModel> ListProductModel()
        {
            var products = productRepository.GetProductList();

            var dtos = products.Select(pro => new ProductViewModel()
            {
                ProductId = pro.ProductId,
                ProductName = pro.ProductName,
                Price = pro.Price,
                Quantity = pro.Quantity,
                Description = pro.Description,
                Weight = pro.Weight,
                Image = pro.Image,
                Status = pro.Status
            });

            return dtos;
        }
       
    }
}
