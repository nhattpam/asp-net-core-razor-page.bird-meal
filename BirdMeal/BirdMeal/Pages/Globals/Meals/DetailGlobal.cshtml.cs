using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.MealProductRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages.Globals.Meals
{
    public class DetailGlobalModel : PageModel
    {
        private IMealProductRepository mealProductRepository { get; set; }
        public IEnumerable<MealProductViewModel> MealDetail { get; set; }
        [BindProperty]
        public MealViewModel MealModel { get; set; }
        public DetailGlobalModel()
        {
            mealProductRepository = new MealProductRepository();
            MealModel = new MealViewModel();
        }
        public void OnGet(string id)
        {
            MealModel.MealId = id;
            MealDetail = List();
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
