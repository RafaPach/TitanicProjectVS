using DeveloperPathways.Domain;  
using DeveloperPathways.Mappers;  
using DeveloperPathways.Dtos;   
using DeveloperPathways.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Application.Queries
{
    public class GetPassengersHandler : IRequestHandler<GetPassengersQuery, List<PassengerDto>>,
    IRequestHandler<GetPassengerByIdQuery, PassengerDto>
    {
        private readonly TitanicContext _context;

        public GetPassengersHandler(TitanicContext context)
        {
            _context = context;
        }

        public async Task<List<PassengerDto>> Handle(GetPassengersQuery request, CancellationToken cancellationToken)
        {
            var passengers = _context.Passengers.AsQueryable();

            if (request.Survived.HasValue)
                passengers = passengers.Where(p => p.Survived == request.Survived.Value);

            return await passengers.Select(passenger => passenger.ToPassengerDto()).ToListAsync(cancellationToken);

        }

        public async Task<PassengerDto> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _context.Passengers
                .Where(p => p.PassengerId == request.Id)
                .Select(p => p.ToPassengerDto())
                .FirstOrDefaultAsync(cancellationToken);

            return passenger;
        }

    }
}
