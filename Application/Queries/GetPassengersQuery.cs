using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries
{
    public class GetPassengersQuery : IRequest<List<PassengerDto>>
    {
        public bool? Survived { get; set; }
    }

    public class GetPassengerByIdQuery(int id) : IRequest<PassengerDto>
    {
        public int? Id { get; set; } = id;
    }

}
