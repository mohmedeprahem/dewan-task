using main.Data;
using main.Interfaces.Repository;
using main.Models;
using Microsoft.EntityFrameworkCore;

namespace main.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AppDbContext context;

        public ReceiptRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CreateReceiptAsync(Receipt receipt)
        {
            await context.Receipts.AddAsync(receipt);
        }

        public async Task<List<Receipt>> GetAllReceiptsAsync()
        {
            return await context.Receipts.ToListAsync();
        }
    }
}
