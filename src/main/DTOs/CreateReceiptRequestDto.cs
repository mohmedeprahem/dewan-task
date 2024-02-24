using System.ComponentModel.DataAnnotations;
using main.Models;

namespace main.DTOs
{
    public class CreateReceiptRequestDto
    {
        [Required(ErrorMessage = "There is no items")]
        public List<ReceiptItemDto> Items { get; set; }

        [Required(ErrorMessage = "There is no total price")]
        [Range(0, double.MaxValue, ErrorMessage = "Total price cannot be negative")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "Please Enter paid amount")]
        [Range(0, double.MaxValue, ErrorMessage = "Paid amount cannot be negative")]
        public double PaidAmount { get; set; }
    }
}
