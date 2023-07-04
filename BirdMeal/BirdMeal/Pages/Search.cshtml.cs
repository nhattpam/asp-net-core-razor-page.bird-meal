using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealRepository;
using Repository.ProductRepository;
using ViewModel;

namespace BirdMeal.Pages
{
    public class SearchModel : PageModel
    {
        private  IProductRepository productRepository { get; set; }
        private  IMealRepository mealRepository { get; set; }

        public IEnumerable<ProductViewModel> ListProducts { get; set; }
        public IEnumerable<MealViewModel> ListMeals { get; set; }

        public SearchModel()
        {
            productRepository = new ProductRepository();
            mealRepository = new MealRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(string txtSearch)
        {
            ListProducts = SearchProducts(txtSearch);
            ListMeals = SearchMeals(txtSearch);

            return Page();
        }

        private IEnumerable<ProductViewModel> SearchProducts(string searchTerm)
        {
            var products = productRepository.GetProductListActive();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var dtos = products.Where(p => p.ProductName != null && p.ProductName.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                                   .Select(pro => new ProductViewModel()
                                   {
                                       ProductId = pro.ProductId,
                                       ProductName = pro.ProductName,
                                       Price = pro.Price,
                                       Quantity = pro.Quantity,
                                       Description = pro.Description,
                                       Weight = pro.Weight,
                                       Image = pro.Image
                                   });

                return dtos;
            }

            return Enumerable.Empty<ProductViewModel>(); // Return an empty enumerable if searchTerm is null or empty
        }


        private IEnumerable<MealViewModel> SearchMeals(string searchTerm)
        {
            var meals = mealRepository.GetMealList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var dtos = meals.Where(m => m.Description != null && m.Description.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                                .Select(meal => new MealViewModel()
                                {
                                    MealId = meal.MealId,
                                    Description = meal.Description,
                                    RoutingTime = meal.RoutingTime,
                                    TotalCost = meal.TotalCost
                                });

                return dtos;
            }

            return Enumerable.Empty<MealViewModel>(); // Return an empty enumerable if searchTerm is null or empty
        }


    }
}
