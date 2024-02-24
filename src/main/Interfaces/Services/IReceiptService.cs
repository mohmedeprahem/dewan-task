using main.DTOs;

namespace main.Interfaces.Services
{
    public interface IReceiptService
    {
        Task<Dictionary<string, List<string>>> CreateReceiptAsync(
            CreateReceiptRequestDto requestDto
        );
    }
}
