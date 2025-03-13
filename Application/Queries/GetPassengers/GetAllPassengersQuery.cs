using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetAllPassengersQuery : IRequest<List<PassengerDto>>
    {
        public bool? Survived { get; set; }
    }

}