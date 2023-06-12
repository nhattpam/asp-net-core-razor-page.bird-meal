using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int? OrderDetailId { get; set; }
        public int? MealProductId { get; set; }

        public virtual MealProduct? MealProduct { get; set; }
        public virtual OrderDetail? OrderDetail { get; set; }
    }
}
