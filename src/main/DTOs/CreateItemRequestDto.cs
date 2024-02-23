using System.ComponentModel.DataAnnotations;

namespace main.DTOs
{
    public class CreateItemRequestDto
    {
        [Required(ErrorMessage = "Please enter the title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the price")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter the Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
