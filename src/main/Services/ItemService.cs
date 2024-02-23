using AutoMapper;
using main.DTOs;
using main.Interfaces.Repository;
using main.Interfaces.Services;
using main.Models;

namespace main.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            this.mapper = mapper;
        }

        public Task<Item> CreateItemAsync(CreateItemRequestDto createItemDto)
        {
            Item item = mapper.Map<Item>(createItemDto);

            return _itemRepository.CreateItemAsync(item);
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _itemRepository.GetAllItemsAsync();
        }
    }
}
