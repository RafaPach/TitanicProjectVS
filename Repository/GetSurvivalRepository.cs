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

        public async Task<List<Passenger>> GetAllPassengersAsync(CancellationToken cancellationToken)
        {
            return await _context.Passengers
                .AsNoTracking()
                .Where(p => p.Survived != null)
                .ToListAsync(cancellationToken);
        }
    }
}
