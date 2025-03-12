using DeveloperPathways.Interface;
using DeveloperPathways.Data;
using DeveloperPathways.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly TitanicContext _context;

        public PassengerRepository(TitanicContext context)
        {
            _context = context;
        }

        public async Task<List<Passenger>> GetPassengersAsync(bool? survived, CancellationToken cancellationToken)
        {
            var passengers = _context.Passengers.AsQueryable();

            if (survived.HasValue)
                passengers = passengers.Where(p => p.Survived == survived.Value);

            return await passengers.ToListAsync(cancellationToken);
        }

        public async Task<Passenger?> GetPassengerByIdAsync(int? id, CancellationToken cancellationToken)
        {
            return await _context.Passengers
                .FirstOrDefaultAsync(p => p.PassengerId == id, cancellationToken);
        }
    }
}
