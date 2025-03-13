using DeveloperPathways.Dtos;
using FluentValidation;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetAllPassengersQueryValidator : AbstractValidator<GetAllPassengersQuery>
    {
        public GetAllPassengersQueryValidator()
        {
            RuleForEach(query => query.Passengers).SetValidator(new PassengerProperties());
        }

        public class  PassengerProperties : AbstractValidator<PassengerDto>
        {
            public PassengerProperties() {
                RuleFor(x => x.Id).GreaterThan(0);

                RuleFor(x => x.Name).NotNull();

                RuleFor(x => x.Age).NotNull();

                RuleFor(x => x.Sex).NotNull();

                RuleFor(x => x.Fare).GreaterThan(0);

                RuleFor(x => x.Cabin).NotNull();

            }

        } 
    }
}
