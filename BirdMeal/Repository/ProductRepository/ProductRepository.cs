using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ProductRepository
{
	public class ProductRepository : IProductRepository
	{
		public IEnumerable<Product> GetProductList()
		{
			return ProductDAO.Instance.GetProductList();
		}
	}
}
