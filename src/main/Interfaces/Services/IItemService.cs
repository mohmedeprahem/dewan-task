using main.DTOs;
using main.Models;

namespace main.Interfaces.Services
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(CreateItemRequestDto createItemDto);
        Task<List<Item>> GetAllItemsAsync();
    }
}
