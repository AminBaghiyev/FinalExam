using FinalExam.BL.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace FinalExam.BL.DTOs;

public record CustomerUpdateDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile? ProfilePhoto { get; set; }
    public string ProfilePhotoPath { get; set; }
    public string Comment { get; set; }
    public int ProfessionId { get; set; }
}


public class CustomerUpdateDTOValidator : AbstractValidator<CustomerUpdateDTO>
{
    public CustomerUpdateDTOValidator()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero!");

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
            .Must(e => e is null || e.CheckType("image")).WithMessage("File type must be image!");

        RuleFor(e => e.ProfessionId)
            .GreaterThan(0).WithMessage("Id must be greater than zero!");
    }
}