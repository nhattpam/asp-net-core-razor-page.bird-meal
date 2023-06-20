using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages.Globals.Products
{
    public class DetailGlobalModel : PageModel
    {
        private IProductRepository productRepository { get; set; }

        [BindProperty]
        public ProductViewModel ProductDetail { get; set; }
        public DetailGlobalModel()
        {
            productRepository = new ProductRepository();
            ProductDetail = new ProductViewModel();
        }
        public void OnGet(int id)
        {
            ProductDetail.ProductId = id;
            ProductDetail = Pro();
        }

        public ProductViewModel Pro()
        {
            var product = productRepository.GetProductById(ProductDetail.ProductId);
            if (product != null)
            {
                ProductDetail = new ProductViewModel()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Image = product.Image,
                    Quantity = product.Quantity,
                    Weight = product.Weight,
                    Description = product.Description
                };
            }
            return ProductDetail;
        }
    }
}
