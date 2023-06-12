using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.ProductRepository;
using System.Windows;
using ViewModel;

namespace BirdMeal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IProductRepository productRepository { get; set; }
        public IEnumerable<ProductViewModel> ListProducts { get; set; } 

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            productRepository = new ProductRepository();
        }

        public void OnGet()
        {
			//if((HttpContext.Session.GetString("loginMemId") != null))
			//    {
			//    int userId = Int32.Parse(HttpContext.Session.GetString("loginMemId"));
			//    if (userId != null)
			//    {
			//        MessageBox.Show(userId.ToString());
			//    }


			//}
			ListProducts = List();

			
		}

		public IEnumerable<ProductViewModel> List()
		{
			var products = productRepository.GetProductList();

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
	}
}