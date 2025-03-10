using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries
{
    public class GetPassengersQuery : IRequest<List<PassengerDto>>
    {
        public bool? Survived { get; set; }
    }

}
