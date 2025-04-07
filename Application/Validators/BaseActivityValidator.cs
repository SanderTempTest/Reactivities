using Application.Activities.DTOs;
using FluentValidation;

namespace Application.Activities.Validators;

public class BaseActivityValidator<T, TDto> : AbstractValidator<T> where TDto : BaseActivityDTO
{
    public BaseActivityValidator(Func<T, TDto> selector)
    {
        RuleFor(x => selector(x).Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters");

        RuleFor(x => selector(x).Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(x => selector(x).Date)
            .GreaterThan(DateTime.UtcNow).WithMessage("Date must be in te future");

        RuleFor(x => selector(x).Category)
            .NotEmpty().WithMessage("Category is required");

        RuleFor(x => selector(x).City)
            .NotEmpty().WithMessage("City is required");

        RuleFor(x => selector(x).Venue)
            .NotEmpty().WithMessage("Venue is required");

        RuleFor(x => selector(x).Latitude)
            .NotEmpty().WithMessage("Latitude is required")
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90");

        RuleFor(x => selector(x).Longtitude)
            .NotEmpty().WithMessage("Longtitude is required")
            .InclusiveBetween(-180, 180).WithMessage("Longtitude must be between -180 and 180");
    }
}