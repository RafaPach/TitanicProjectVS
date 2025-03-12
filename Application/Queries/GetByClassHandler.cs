using DeveloperPathways.Data;
using DeveloperPathways.Dtos;
using DeveloperPathways.Interface;
using DeveloperPathways.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Application.Queries
{
    public class GetByClassHandler : IRequestHandler<GetByClassQuery, FinalClassBreakDown>
    {
        private readonly IGetByClassRepository _getByClassRepository;

        public GetByClassHandler(IGetByClassRepository getByClassRepository)
        {
            _getByClassRepository = getByClassRepository;
        }
        public async Task<FinalClassBreakDown> Handle(GetByClassQuery request, CancellationToken cancellationToken)
        {
           var passenger = await _getByClassRepository.GetAllPassengersAsync(cancellationToken);


            return new FinalClassBreakDown
            {
                ClassBreakdown = passenger.ToClassAggregdationDto()
            };
        }
    }
}
