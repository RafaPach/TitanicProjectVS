using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperPathways.Application.Queries
{
    public class GetPassengersByAgeHandler : IRequestHandler<GetPassengersByAgeQuery, List<PassengerDto>>
    {
        private readonly TitanicContext _context;

        public GetPassengersByAgeHandler(TitanicContext context)
        {
            _context = context;
        }

        public async Task<List<PassengerDto>> Handle(GetPassengersByAgeQuery request, CancellationToken cancellationToken)
        {
            return await _context.Passengers
               .Where(p => p.Age.HasValue)
               .OrderBy(p => p.Age)
               .Select(p => p.ToPassengerDto())
               .ToListAsync(cancellationToken);
        }
    }
}
