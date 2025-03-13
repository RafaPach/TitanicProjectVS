using DeveloperPathways.Dtos;
using FluentValidation;

namespace DeveloperPathways.Application.Queries.GetByAge
{
    public class GetPassengerByAgeQueryValidator : AbstractValidator<GetPassengersByAgeQuery>
    {
        public GetPassengerByAgeQueryValidator()
        {
            RuleFor(x => x.Passengers).Must(AgeOrderCheck);
        }


        // method below should be part of the validator class, but it shouldn't directly fetch data from the repository or database.
        // Validators typically work with the data provided in the request, not by fetching additional data.
        private bool AgeOrderCheck(List<PassengerDto> passenger)
        {
            if(passenger == null || passenger.Count < 1)
            {
                return true;
            }

            return passenger[1].Age > passenger[100].Age;
        }
    }
}
