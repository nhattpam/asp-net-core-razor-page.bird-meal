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
		public bool AddProduct(Product product)
		{
			return ProductDAO.Instance.AddProduct(product);
		}

        public Product GetProductById(int productId)
        {
            return ProductDAO.Instance.GetProductById(productId);
        }

        public IEnumerable<Product> GetProductList()
		{
			return ProductDAO.Instance.GetProductList();
		}

        public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
