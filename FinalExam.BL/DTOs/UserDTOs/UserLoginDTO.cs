using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FinalExam.BL.DTOs;

public record UserLoginDTO
{
	[Display(Prompt = "Username")]
	public string UserName { get; set; }

	[Display(Prompt = "Password")]
	[DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}

public class UserLoginDTOValidator : AbstractValidator<UserLoginDTO>
{
    public UserLoginDTOValidator()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().WithMessage("Username can't be empty!")
            .MinimumLength(5).WithMessage("Username must contain at least 5 symbols!")
            .MaximumLength(100).WithMessage("Username can contain up to 100 symbols!");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password can't be empty!")
            .MinimumLength(4).WithMessage("Password must contain at least 4 symbols!");
    }
}