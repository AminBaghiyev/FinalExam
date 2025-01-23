using AutoMapper;
using FinalExam.BL.DTOs;
using FinalExam.Core.Models;

namespace FinalExam.BL.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerCreateDTO, Customer>().ReverseMap();
        CreateMap<CustomerUpdateDTO, Customer>().ReverseMap();
        CreateMap<CustomerListItemDTO, Customer>()
            .ReverseMap()
            .ForMember(dest => dest.ProfessionTitle, options => options.MapFrom(src => src.Profession.Title));

        CreateMap<CustomerViewItemDTO, Customer>()
            .ReverseMap()
            .ForMember(dest => dest.ProfessionTitle, options => options.MapFrom(src => src.Profession.Title));
    }
}
