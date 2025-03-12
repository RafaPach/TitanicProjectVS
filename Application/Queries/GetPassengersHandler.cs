using DeveloperPathways.Domain;  
using DeveloperPathways.Mappers;  
using DeveloperPathways.Dtos;   
using DeveloperPathways.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DeveloperPathways.Interface;

namespace DeveloperPathways.Application.Queries
{
    public class GetPassengersHandler : IRequestHandler<GetPassengersQuery, List<PassengerDto>>,
    IRequestHandler<GetPassengerByIdQuery, PassengerDto>
    {
        private readonly IPassengerRepository _passengerRepository;

        public GetPassengersHandler(IPassengerRepository passengerrepository)
        {
            _passengerRepository = passengerrepository;
        }

        public async Task<List<PassengerDto>> Handle(GetPassengersQuery request, CancellationToken cancellationToken)
        {
            var passengers = await _passengerRepository.GetPassengersAsync(request.Survived, cancellationToken);

            return passengers.Select(p => p.ToPassengerDto()).ToList();

        }

        public async Task<PassengerDto> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetPassengerByIdAsync(request.Id, cancellationToken);

            return passenger.ToPassengerDto();
        }

    }
}
