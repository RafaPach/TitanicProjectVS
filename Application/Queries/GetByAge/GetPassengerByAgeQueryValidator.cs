using FluentValidation;

namespace DeveloperPathways.Application.Queries.GetByAge
{
    public class GetPassengersByAgeQueryValidator : AbstractValidator<GetPassengersByAgeQuery>
    {
        public GetPassengersByAgeQueryValidator()
        {
            //RuleFor(x => x.MinAge)
            //    .GreaterThanOrEqualTo(0)
            //    .WithMessage("MinAge must be greater than or equal to 0.");

            //RuleFor(x => x.MaxAge)
            //    .GreaterThanOrEqualTo(x => x.MinAge ?? 0)
            //    .When(x => x.MaxAge.HasValue)
            //    .WithMessage("MaxAge must be greater than or equal to MinAge.");
        }
    }
}
