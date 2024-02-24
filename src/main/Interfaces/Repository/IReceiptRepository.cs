using main.Models;

namespace main.Interfaces.Repository
{
    public interface IReceiptRepository
    {
        Task CreateReceiptAsync(Receipt receipt);

        Task<List<Receipt>> GetAllReceiptsAsync();
    }
}
