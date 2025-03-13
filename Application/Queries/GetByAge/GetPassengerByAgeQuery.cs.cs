using DeveloperPathways.Dtos;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetByAge
{
    public class GetPassengersByAgeQuery : IRequest<List<PassengerDto>>
    {
        //public int? MinAge { get; set; }
        //public int? MaxAge { get; set; }

        //public GetPassengersByAgeQuery(int? minAge, int? maxAge)
        //{
        //    MinAge = minAge;
        //    MaxAge = maxAge;
        //}
    }
}