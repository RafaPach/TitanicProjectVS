using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Application.Queries
{
    public class GetByClassHandler : IRequestHandler<GetByClassQuery, FinalClassBreakDown>
    {
        private readonly TitanicContext _context;

        public GetByClassHandler (TitanicContext context)
        {
            _context = context;
        }
        public async Task<FinalClassBreakDown> Handle(GetByClassQuery request, CancellationToken cancellationToken)
        {
            return new FinalClassBreakDown
            {
                ClassBreakdown = (await _context.Passengers
                    .ToListAsync(cancellationToken))
                    .ToClassAggregdationDto()
            };
        }
    }
}
