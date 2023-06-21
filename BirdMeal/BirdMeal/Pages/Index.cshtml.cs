using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealRepository;
using Repository.ProductRepository;
using Repository.UserRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages
{
    public class IndexModel : PageModel
    {
        private IUserRepository userRepository { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public IProductRepository productRepository { get; set; }
        public IMealRepository mealRepository { get; set; }
        public IEnumerable<MealViewModel> ListMeals { get; set; }
        public IEnumerable<ProductViewModel> ListProducts { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            userRepository = new UserRepository();
            productRepository = new ProductRepository();
            mealRepository = new MealRepository();
        }

        public IActionResult OnGet()
        {
            string loginMem = HttpContext.Session.GetString("loginMem");

            if (loginMem == null)
            {
                ListProducts = ListHotProduct();
                ListMeals = ListHotMeal();
                return Page();
            }
            else
            {
                User u = userRepository.GetUserByEmail(loginMem);
                if (u.Role.Equals("STAFF") || u.Role.Equals("ADMIN"))
                {
                    return RedirectToPage("/Error");
                }
            }
            ListMeals = ListHotMeal();
            ListProducts = ListHotProduct();
            return Page();
        }

		public IEnumerable<ProductViewModel> ListHotProduct()
		{
			var products = productRepository.GetProductListHot();

			var dtos = products.Select(pro => new ProductViewModel()
			{
				ProductId = pro.ProductId,
				ProductName = pro.ProductName,
				Price = pro.Price,
                Quantity = pro.Quantity,
                Description = pro.Description,
                Weight= pro.Weight,
				Image = pro.Image
			});

			return dtos;
		}

        public IEnumerable<MealViewModel> ListHotMeal()
        {
            var meals = mealRepository.GetMealListHot();

            var dtos = meals.Select(pro => new MealViewModel()
            {
                MealId = pro.MealId,
                Description = pro.Description,
                RoutingTime = pro.RoutingTime,
                TotalCost = pro.TotalCost
            });

            return dtos;
        }
    }
}