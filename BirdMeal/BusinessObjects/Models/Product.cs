using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Product
    {
        public Product()
        {
            MealProducts = new HashSet<MealProduct>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public double? Weight { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<MealProduct> MealProducts { get; set; }
    }
}
