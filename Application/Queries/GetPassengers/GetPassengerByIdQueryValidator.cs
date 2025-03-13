using FluentValidation;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetPassengerByIdQueryValidator : AbstractValidator<GetPassengerByIdQuery>
    {
        public GetPassengerByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Passenger ID must be greater than zero.");
        }
    }
}
