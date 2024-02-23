using main.Data;
using main.Interfaces.Repository;
using main.Models;

namespace main.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            await _context.Items.AddAsync(item);

            await _context.SaveChangesAsync();

            return item;
        }
    }
}
