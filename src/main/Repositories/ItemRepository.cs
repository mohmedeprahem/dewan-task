using main.Data;
using main.Interfaces.Repository;
using main.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Item>> GetAllItemsAsync() => await _context.Items.ToListAsync();

        public async Task<Item?> GetItemByIdAsync(int id) => await _context.Items.FindAsync(id);

        public void UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
        }

        public async Task AddItemToReceiptAsync(int itemId, int ReceiptId)
        {
            await _context
                .ItemReceipts
                .AddAsync(new ItemReceipt { ItemId = itemId, ReceiptId = ReceiptId });
        }
    }
}
