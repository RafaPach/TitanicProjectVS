using DeveloperPathways.Domain;

namespace DeveloperPathways.Interface
{
    public interface IGetByAgeRepository
    {
        Task<List<Passenger>> GetByAgeAsync( CancellationToken cancellationToken);
    }

}
