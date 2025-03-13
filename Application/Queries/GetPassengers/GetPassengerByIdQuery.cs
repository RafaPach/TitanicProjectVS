using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetPassengerByIdQuery(int id) : IRequest<PassengerDto>
    {
        public int? Id { get; set; } = id;
    }
}
