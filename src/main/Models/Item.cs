using System.ComponentModel.DataAnnotations;

namespace main.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
