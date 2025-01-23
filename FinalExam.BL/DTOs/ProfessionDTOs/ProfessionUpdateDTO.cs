using FluentValidation;

namespace FinalExam.BL.DTOs;

public record ProfessionUpdateDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class ProfessionUpdateDTOValidator : AbstractValidator<ProfessionUpdateDTO>
{
    public ProfessionUpdateDTOValidator()
    {
        RuleFor(e => e.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero!");

        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title can't be empty!")
            .MinimumLength(5).WithMessage("Title must contain at least 5 symbols!")
            .MaximumLength(50).WithMessage("Title can contain up to 50 symbols!");
    }
}