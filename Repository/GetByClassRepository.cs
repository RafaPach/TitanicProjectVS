using DeveloperPathways.Data;
using DeveloperPathways.Domain;
using DeveloperPathways.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Repository
{
    public class GetByClassRepository : IGetByClassRepository
    {
        private readonly TitanicContext _context;
        public GetByClassRepository(TitanicContext context)
        {
            _context = context;
        }

        public async Task<List<Passenger>> GetAllPassengersAsync(CancellationToken cancellationToken)
        {
            return await _context.Passengers.ToListAsync(cancellationToken);
        }

    }
}
