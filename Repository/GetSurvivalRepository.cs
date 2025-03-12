using DeveloperPathways.Data;
using DeveloperPathways.Domain;
using DeveloperPathways.Interface;
using DeveloperPathways.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Repository
{
    public class GetSurvivalRepository : IGetSurivalRepository
    {
        private readonly TitanicContext _context;

        public GetSurvivalRepository(TitanicContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalMalesAsync(CancellationToken cancellationToken)
        {
            return await _context.Passengers.CountAsync(p => p.Sex == "male", cancellationToken);
        }

        public async Task<int> GetTotalFemalesAsync(CancellationToken cancellationToken)
        {
            return await _context.Passengers.CountAsync(P => P.Sex == "female", cancellationToken);
        }

        public async Task<List<IGrouping<SurvivalGroupKeys, Passenger>>> GetFinalData(CancellationToken cancellationToken)
        {
            var data = await _context.Passengers
               .AsNoTracking()
               .GroupBy(p => new SurvivalGroupKeys { Survived = p.Survived, Sex = p.Sex })
               .ToListAsync(cancellationToken);

            return data;
        }
    }
}
