using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using ViewModel;

namespace BirdMeal.Pages.Globals.Products
{
    public class ListProductModel : PageModel
	{
		public IProductRepository productRepository { get; set; }
		public IEnumerable<ProductViewModel> ListProducts { get; set; }

		public ListProductModel()
		{
			productRepository = new ProductRepository();
		}
		public void OnGet()
        {
			ListProducts = ListProductActive();

		}

		public IEnumerable<ProductViewModel> ListProductActive()
		{
			var products = productRepository.GetProductListActive();

			var dtos = products.Select(pro => new ProductViewModel()
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
	}
}
