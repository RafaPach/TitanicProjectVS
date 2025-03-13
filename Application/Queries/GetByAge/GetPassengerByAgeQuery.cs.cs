using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetByAge
{
    public class GetPassengersByAgeQuery : IRequest<List<PassengerDto>>
    {
        public List<PassengerDto> Passengers { get; set; }
    }
}