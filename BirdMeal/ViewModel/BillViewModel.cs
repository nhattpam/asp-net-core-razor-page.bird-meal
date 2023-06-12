using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BillViewModel
    {
        public int BillId { get; set; }
        public int? OrderDetailId { get; set; }
        public int? MealProductId { get; set; }

        public virtual MealProductViewModel? MealProduct { get; set; }
        public virtual OrderDetailViewModel? OrderDetail { get; set; }
    }
}
