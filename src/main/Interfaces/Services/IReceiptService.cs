using main.DTOs;
using main.Models;

namespace main.Interfaces.Services
{
    public interface IReceiptService
    {
        Task<Dictionary<string, List<string>>> CreateReceiptAsync(
            CreateReceiptRequestDto requestDto
        );

        Task<List<Receipt>> GetAllReceiptsAsync();
    }
}
