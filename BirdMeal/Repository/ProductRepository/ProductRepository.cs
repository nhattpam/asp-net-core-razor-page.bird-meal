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

        public bool DeleteProductById(int productId)
        {
            return ProductDAO.Instance.DeleteProductById(productId);   
        }

        public Product GetProductById(int productId)
        {
            return ProductDAO.Instance.GetProductById(productId);
        }

        public IEnumerable<Product> GetProductList()
		{
			return ProductDAO.Instance.GetProductList();
		}
        public IEnumerable<Product> GetProductListHot()
        {
            return ProductDAO.Instance.GetProductListHot();
        }

		public IEnumerable<Product> GetProductListActive()
        {
            return ProductDAO.Instance.GetProductListActive();
        }


		public bool UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
