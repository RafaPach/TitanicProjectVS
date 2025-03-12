using DeveloperPathways.Domain;
using DeveloperPathways.Models;

namespace DeveloperPathways.Interface
{
    public interface IGetSurivalRepository
    {
        Task<int> GetTotalMalesAsync(CancellationToken cancellationToken);
        Task<int> GetTotalFemalesAsync(CancellationToken cancellationToken);
        Task<List<IGrouping<SurvivalGroupKeys, Passenger>>> GetFinalData(CancellationToken cancellationToken);
    }
}
