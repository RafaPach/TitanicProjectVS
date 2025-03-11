using DeveloperPathways.Data;
using DeveloperPathways.Mappers;
using DeveloperPathways.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Application.Queries
{
    public class GetSurvivalsHandler : IRequestHandler<GetSurvivalsQuery, FinalSurvivalRate>
    {
        private readonly TitanicContext _context;

        public GetSurvivalsHandler (TitanicContext context)
        {
            _context = context;
        }

        public async Task<FinalSurvivalRate> Handle(GetSurvivalsQuery request, CancellationToken cancellationToken)
        {
            var totalMales = await _context.Passengers.CountAsync(p => p.Sex == "male", cancellationToken);
            var totalFemales = await _context.Passengers.CountAsync(p => p.Sex == "female", cancellationToken);

            var data = await _context.Passengers
               .AsNoTracking()
               .GroupBy(p => new { p.Survived, p.Sex })
               .ToListAsync(cancellationToken);

            var result = data.ToSurvivalStatsDto(totalMales, totalFemales);

            return new FinalSurvivalRate
            {
                SurvivalRates = result
            };
        }

    }
}
