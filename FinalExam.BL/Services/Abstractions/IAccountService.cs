using FinalExam.BL.DTOs;

namespace FinalExam.BL.Services.Abstractions;

public interface IAccountService
{
    Task RegisterAsync(UserRegisterDTO dto);
    Task LoginAsync(UserLoginDTO dto);
    Task LogoutAsync();
}
