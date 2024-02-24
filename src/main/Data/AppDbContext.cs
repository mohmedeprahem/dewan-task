using main.Models;
using Microsoft.EntityFrameworkCore;

namespace main.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ItemReceipt> ItemReceipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemReceipt>().HasKey(ir => new { ir.ItemId, ir.ReceiptId });
        }
    }
}
