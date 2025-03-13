using DeveloperPathways.Data;
using DeveloperPathways.Domain;
using DeveloperPathways.Interface;
using DeveloperPathways.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Repository
{
    public class GetByAgeRepository : IGetByAgeRepository
    {
        private readonly TitanicContext _context;

        public GetByAgeRepository(TitanicContext context)
        {
            _context = context;
        }

        public async Task<List<Passenger>> GetByAgeAsync(CancellationToken cancellationToken)
        {
            return await _context.Passengers
               .Where(p => p.Age.HasValue)          
               .OrderBy(p => p.Age)                
               .ToListAsync(cancellationToken);     
        }
    }
}
