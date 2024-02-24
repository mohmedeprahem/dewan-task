using AutoMapper;
using main.DTOs;
using main.Interfaces.Repository;
using main.Interfaces.Services;
using main.Models;

namespace main.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ReceiptService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Dictionary<string, List<string>>> CreateReceiptAsync(
            CreateReceiptRequestDto requestDto
        )
        {
            Receipt receipt = new Receipt()
            {
                TotalPrice = requestDto.TotalPrice,
                PaidAmount = requestDto.PaidAmount,
            };
            Dictionary<string, List<string>> errorMessages = new Dictionary<string, List<string>>();
            try
            {
                await unitOfWork.BeginTransactionAsync();

                // Create receipt
                await unitOfWork.ReceiptRepository.CreateReceiptAsync(receipt);
                await unitOfWork.SaveChangesAsync();

                foreach (var item in requestDto.Items)
                {
                    Item? itemDetails = await unitOfWork.ItemRepository.GetItemByIdAsync(item.Id);

                    if (itemDetails == null)
                    {
                        if (!errorMessages.ContainsKey($"Item-{item.Id}"))
                        {
                            errorMessages[$"Item-{item.Id}"] = new List<string>();
                        }
                        errorMessages[$"Item-{item.Id}"].Add(
                            $"Item '{item.Title}' with ID '{item.Id}' not found."
                        );
                    }
                    else if (itemDetails.Quantity == 0)
                    {
                        if (!errorMessages.ContainsKey($"Item-{item.Id}"))
                        {
                            errorMessages[$"Item-{item.Id}"] = new List<string>();
                        }
                        errorMessages[$"Item-{item.Id}"].Add(
                            $"Item '{item.Title}' is out of stock."
                        );
                    }
                    else if (itemDetails.Quantity < item.Quantity)
                    {
                        if (!errorMessages.ContainsKey($"Item-{item.Id}"))
                        {
                            errorMessages[$"Item-{item.Id}"] = new List<string>();
                        }
                        errorMessages[$"Item-{item.Id}"].Add(
                            $"There is only '{itemDetails.Quantity}' Quantity of '{item.Title}'."
                        );
                    }
                    else
                    {
                        itemDetails.Quantity -= item.Quantity;
                        unitOfWork.ItemRepository.UpdateItemAsync(itemDetails);
                        await unitOfWork
                            .ItemRepository
                            .AddItemToReceiptAsync(itemDetails.Id, receipt.Id);
                    }
                }

                if (errorMessages.Count == 0)
                {
                    await unitOfWork.SaveChangesAsync();
                    await unitOfWork.CommitAsync();
                }
                else
                {
                    await unitOfWork.RollbackAsync();
                }

                return errorMessages;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
