using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries
{
    public class GetPassengersByAgeQuery : IRequest<List<PassengerDto>>
    {

    }
}
