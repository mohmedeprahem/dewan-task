using main.Models;

namespace main.Interfaces.Repository
{
    public interface IItemRepository
    {
        Task<Item> CreateItemAsync(Item item);
        Task<List<Item>> GetAllItemsAsync();
    }
}
