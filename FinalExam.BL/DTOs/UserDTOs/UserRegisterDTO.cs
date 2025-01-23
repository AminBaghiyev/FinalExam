using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace FinalExam.BL.DTOs;

public record UserRegisterDTO
{
    [Display(Prompt = "Username")]
    public string UserName { get; set; }

	[Display(Prompt = "Email")]
	[DataType(DataType.EmailAddress)]
    public string Email { get; set; }

	[Display(Prompt = "Password")]
	[DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Prompt = "Confirm password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}

public class UserRegisterDTOValidator : AbstractValidator<UserRegisterDTO>
{
    public UserRegisterDTOValidator()
    {
        RuleFor(e => e.UserName)
            .NotEmpty().WithMessage("Username can't be empty!")
            .MinimumLength(5).WithMessage("Username must contain at least 5 symbols!")
            .MaximumLength(100).WithMessage("Username can contain up to 100 symbols!");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email can't be empty!")
            .EmailAddress().WithMessage("Email address is invalid!");

        RuleFor(e => e.Password)
            .NotEmpty().WithMessage("Password can't be empty!")
            .MinimumLength(4).WithMessage("Password must contain at least 4 symbols!");

        RuleFor(e => e.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm password can't be empty!")
            .Equal(e => e.Password).WithMessage("Passwords don't match!");
    }
}