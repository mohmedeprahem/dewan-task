using System.ComponentModel.DataAnnotations;

namespace main.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public double PaidPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Item> Items { get; set; }
    }
}
