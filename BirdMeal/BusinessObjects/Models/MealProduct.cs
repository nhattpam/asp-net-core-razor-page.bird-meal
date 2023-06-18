﻿using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class MealProduct
    {
        public MealProduct()
        {
            Bills = new HashSet<Bill>();
        }

        public int MealProductId { get; set; }
        public string? MealId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Meal? Meal { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
