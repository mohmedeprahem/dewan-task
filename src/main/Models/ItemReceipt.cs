namespace main.Models
{
    public class ItemReceipt
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
    }
}
