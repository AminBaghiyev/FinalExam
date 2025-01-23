using AutoMapper;
using FinalExam.BL.DTOs;
using FinalExam.Core.Models;

namespace FinalExam.BL.Profiles;

public class ProfessionProfile : Profile
{
    public ProfessionProfile()
    {
        CreateMap<ProfessionCreateDTO, Profession>().ReverseMap();
        CreateMap<ProfessionUpdateDTO, Profession>().ReverseMap();
        CreateMap<ProfessionListItemDTO, Profession>().ReverseMap();
    }
}
