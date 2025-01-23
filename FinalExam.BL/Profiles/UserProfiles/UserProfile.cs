using AutoMapper;
using FinalExam.BL.DTOs;
using Microsoft.AspNetCore.Identity;

namespace FinalExam.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserLoginDTO, IdentityUser>().ReverseMap();
        CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
    }
}
