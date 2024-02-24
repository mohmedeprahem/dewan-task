using AutoMapper;
using main.DTOs;
using main.Models;

namespace main.Utilities
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<CreateItemRequestDto, Item>();
            CreateMap<CreateReceiptRequestDto, Receipt>();
        }
    }
}
