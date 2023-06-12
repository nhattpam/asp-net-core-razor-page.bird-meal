﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MealViewModel
    {
        public MealViewModel()
        {
            MealProducts = new HashSet<MealProductViewModel>();
        }

        public int MealId { get; set; }
        public string? Description { get; set; }
        public string? RoutingTime { get; set; }
        public double? TotalCost { get; set; }

        public virtual ICollection<MealProductViewModel> MealProducts { get; set; }
    }
}
