using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealProducts = new HashSet<MealProduct>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string MealId { get; set; } = null!;
        public string? Description { get; set; }
        public string? RoutingTime { get; set; }
        public double? TotalCost { get; set; }

        public virtual ICollection<MealProduct> MealProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
