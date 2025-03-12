using DeveloperPathways.Domain;
using DeveloperPathways.Dtos;

namespace DeveloperPathways.Interface
{
    public interface IGetByClassRepository
    {
        Task<List<Passenger>> GetAllPassengersAsync(CancellationToken cancellation);
    }
}
