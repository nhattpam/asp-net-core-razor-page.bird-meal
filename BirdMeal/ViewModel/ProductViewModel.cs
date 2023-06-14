using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            MealProducts = new HashSet<MealProductViewModel>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string? ProductName { get; set; }
		public string? Image { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive value.")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Status is required.")]
        public bool? Status { get; set; }
        [Required(ErrorMessage = "Weight is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Weight must be a positive value.")]
        public double? Weight { get; set; }

        public virtual ICollection<MealProductViewModel> MealProducts { get; set; }
    }
}
