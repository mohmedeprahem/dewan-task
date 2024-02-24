namespace main.DTOs
{
    public class ReceiptResponseDto
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double PaidAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
