using BusinessObjects.Models;
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
	}


}
