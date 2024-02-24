using main.Models;

namespace main.Interfaces.Repository
{
    public interface IItemRepository
    {
        Task<Item> CreateItemAsync(Item item);
        Task<List<Item>> GetAllItemsAsync();
        Task<Item?> GetItemByIdAsync(int id);
        void UpdateItemAsync(Item item);
        Task AddItemToReceiptAsync(int itemId, int ReceiptId);
    }
}
