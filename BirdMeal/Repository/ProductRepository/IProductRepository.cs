using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepository
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetProductList();
		public IEnumerable<Product> GetProductListHot();

		public IEnumerable<Product> GetProductListActive();

		public bool AddProduct(Product product);
        public bool UpdateProduct(Product product);
		public Product GetProductById(int productId);
		public bool DeleteProductById(int productId);

    }
}
