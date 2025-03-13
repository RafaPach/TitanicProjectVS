using FluentValidation;

namespace DeveloperPathways.Application.Queries.GetSurvival
{
    public class GetSurvivalQueryValidator : AbstractValidator<GetSurvivalsQuery>
    {
        public GetSurvivalQueryValidator()
        {
            RuleFor(x => x).NotNull();
        }
    }
}
