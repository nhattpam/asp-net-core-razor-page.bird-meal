using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
		private static ProductDAO instance;
		private static object instanceLock = new object();

		public static ProductDAO Instance
		{
			get
			{
				lock (instanceLock)
				{
					if (instance == null)
					{
						instance = new ProductDAO();
					}
					return instance;
				}
			}
		}

		public IEnumerable<Product> GetProductList()
		{
			IEnumerable<Product> products = null;

			try
			{
				var context = new BirdMealContext();
				// Get From Database

				products = context.Products;
							
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return products;
		}

        public IEnumerable<Product> GetProductListHot()
        {
            IEnumerable<Product> products = null;

            try
            {
                var context = new BirdMealContext();
                // Get From Database

                products = context.Products.Take(5)
                    .Where(p => p.Status == true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return products;
        }

		public IEnumerable<Product> GetProductListActive()
		{
			IEnumerable<Product> products = null;

			try
			{
				var context = new BirdMealContext();
				// Get From Database

				products = context.Products.Where(p => p.Status == true);

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			return products;
		}

		public bool AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            try
            {
                using (var context = new BirdMealContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
                return false;
            }
        }


        public bool UpdateProduct(Product product)
        {
            try
            {
                using (var context = new BirdMealContext())
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the product: {ex.Message}");
                return false;
            }
        }

        public Product GetProductById(int productId)
        {
            Product p = null;

            try
            {

                var context = new BirdMealContext();
                p = context.Products.SingleOrDefault(f => f.ProductId == productId); ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return p;
        }

        public bool DeleteProductById(int productId)
        {
            Product p = null;

            try
            {
                var context = new BirdMealContext();
                p = GetProductById(productId);
                p.Status = false;
                context.Update(p);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
        }

    }


}
