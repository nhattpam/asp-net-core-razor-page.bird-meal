using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealProducts = new HashSet<MealProduct>();
        }

        public int MealId { get; set; }
        public string? Description { get; set; }
        public string? RoutingTime { get; set; }
        public double? TotalCost { get; set; }

        public virtual ICollection<MealProduct> MealProducts { get; set; }
    }
}
