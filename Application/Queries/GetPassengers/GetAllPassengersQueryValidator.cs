using DeveloperPathways.Dtos;
using FluentValidation;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetAllPassengersQueryValidator : AbstractValidator<GetAllPassengersQuery>
    {
        public GetAllPassengersQueryValidator()
        {
            RuleFor(x => x.Survived)
                .Must(s => s == true || s == false || s == null)
                .WithMessage("Survived must be true, false, or null.");
        }

    }
}
