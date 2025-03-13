using DeveloperPathways.Models;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetSurvival
{
    public class GetSurvivalsQuery : IRequest<FinalSurvivalRate>
    {
    }
}