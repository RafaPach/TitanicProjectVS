using DeveloperPathways.Domain;

namespace DeveloperPathways.Interface
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetPassengersAsync(bool? survived, CancellationToken cancellationToken);

        Task<Passenger> GetPassengerByIdAsync(int? id, CancellationToken cancellationToken);

    }
}
