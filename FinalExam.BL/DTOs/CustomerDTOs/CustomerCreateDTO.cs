using FinalExam.BL.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FinalExam.BL.DTOs;

public record CustomerCreateDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile ProfilePhoto { get; set; }
    public string Comment { get; set; }
    public int ProfessionId { get; set; }
}

public class CustomerCreateDTOValidator : AbstractValidator<CustomerCreateDTO>
{
    public CustomerCreateDTOValidator()
    {
        RuleFor(e => e.FirstName)
            .NotEmpty().WithMessage("Firstname can't be empty!")
            .MinimumLength(3).WithMessage("Firstname must contain at least 3 symbols!")
            .MaximumLength(50).WithMessage("Firstname can contain up to 50 symbols!");

        RuleFor(e => e.LastName)
            .NotEmpty().WithMessage("Lastname can't be empty!")
            .MinimumLength(6).WithMessage("Lastname must contain at least 6 symbols!")
            .MaximumLength(50).WithMessage("Lastname can contain up to 50 symbols!");

        RuleFor(e => e.Comment)
            .NotEmpty().WithMessage("Comment can't be empty!")
            .MinimumLength(20).WithMessage("Comment must contain at least 20 symbols!")
            .MaximumLength(255).WithMessage("Comment can contain up to 255 symbols!");

        RuleFor(e => e.ProfilePhoto)
            .NotNull().WithMessage("Image can't be null!")
            .Must(e => e is null || e.CheckType("image")).WithMessage("File type must be image!");

        RuleFor(e => e.ProfessionId)
            .GreaterThan(0).WithMessage("Id must be greater than zero!");
    }
}