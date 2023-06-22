using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public string? MealId { get; set; }

        public virtual Meal? Meal { get; set; }
        public virtual Order? Order { get; set; }
    }
}
