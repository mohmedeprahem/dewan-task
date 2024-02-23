using System.ComponentModel.DataAnnotations;

namespace main.DTOs
{
    public class CreateItemRequestDto
    {
        [Required(ErrorMessage = "Please enter the title")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter the Quantity")]
        public int Quantity { get; set; }
    }
}
