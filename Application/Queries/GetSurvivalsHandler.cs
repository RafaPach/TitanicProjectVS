using DeveloperPathways.Data;
using DeveloperPathways.Interface;
using DeveloperPathways.Mappers;
using DeveloperPathways.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPathways.Application.Queries
{
    public class GetSurvivalsHandler : IRequestHandler<GetSurvivalsQuery, FinalSurvivalRate>
    {
        private readonly IGetSurivalRepository _getSurivalRepository;

        public GetSurvivalsHandler(IGetSurivalRepository getSurivalRepository)
        {
            _getSurivalRepository = getSurivalRepository;
        }

        public async Task<FinalSurvivalRate> Handle(GetSurvivalsQuery request, CancellationToken cancellationToken)
        {
            var totalMales = await _getSurivalRepository.GetTotalMalesAsync(cancellationToken);
            var totalFemales = await _getSurivalRepository.GetTotalFemalesAsync(cancellationToken);

            var data = await _getSurivalRepository.GetFinalData(cancellationToken);

            var result = data.ToSurvivalStatsDto(totalMales, totalFemales);

            return new FinalSurvivalRate
            {
                SurvivalRates = result
            };
        }

    }
}
