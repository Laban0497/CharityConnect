using CharityConnect.Application.DTOs.Help;
using FluentValidation;

namespace CharityConnect.Application.Validators
{
    public class HelpRequestDTOValidator : AbstractValidator<HelpRequestDTO>
    {
        public HelpRequestDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("Description must be at least 10 characters.");
        }
    }
}
