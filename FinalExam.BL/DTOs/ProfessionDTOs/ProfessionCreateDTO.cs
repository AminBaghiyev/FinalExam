using FluentValidation;

namespace FinalExam.BL.DTOs;

public record ProfessionCreateDTO
{
    public string Title { get; set; }
}

public class ProfessionCreateDTOValidator : AbstractValidator<ProfessionCreateDTO>
{
    public ProfessionCreateDTOValidator()
    {
        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title can't be empty!")
            .MinimumLength(5).WithMessage("Title must contain at least 5 symbols!")
            .MaximumLength(50).WithMessage("Title can contain up to 50 symbols!");
    }
}