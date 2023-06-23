using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealProductRepository;
using Repository.UserRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages.Globals.Meals
{
    public class DetailGlobalModel : PageModel
    {
		private IUserRepository userRepository { get; set; }
		private IMealProductRepository mealProductRepository { get; set; }
        public IEnumerable<MealProductViewModel> MealDetail { get; set; } = new List<MealProductViewModel>();
        [BindProperty]
        public MealViewModel MealModel { get; set; }

        [BindProperty]
        public float? Total { get; set; }

        [BindProperty]
        public int UserId { get; set; }
        public DetailGlobalModel()
        {
            mealProductRepository = new MealProductRepository();
            MealModel = new MealViewModel();
            userRepository = new UserRepository();
        }

		public IActionResult OnGet(string id)
		{
			string loginMem = HttpContext.Session.GetString("loginMem");

			if (loginMem == null)
			{
				MealModel.MealId = id;
				MealDetail = List();
				return Page();
			}
			else
			{
				User u = userRepository.GetUserByEmail(loginMem);
				if (u.Role.Equals("STAFF") || u.Role.Equals("ADMIN"))
				{
					return RedirectToPage("/Error");
                }
                //gan de ban qua Cart
                UserId = u.UserId;
            }
            
			MealModel.MealId = id;
			MealDetail = List();
			return Page();
		}

		public IEnumerable<MealProductViewModel> List()
        {
            var orderDetailsByOrderId = mealProductRepository.GetMealProductByMealId(MealModel.MealId);

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
                Quantity = product.Quantity,
                Price = product.Price,
                Image = product.Image
            };
        }
    }
}
