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

		public bool AddProduct(Product product);
	}
}
