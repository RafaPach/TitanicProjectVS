using DeveloperPathways.Mappers;
using DeveloperPathways.Dtos;
using MediatR;
using DeveloperPathways.Interface;
using FluentValidation;
using FluentValidation.Results;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetAllPassengersHandler : IRequestHandler<GetAllPassengersQuery, List<PassengerDto>>    
    {

        private readonly IPassengerRepository _passengerRepository;
        private readonly IValidator<GetAllPassengersQuery> _validator;
        private readonly ILogger<GetAllPassengersHandler> _logger;

        public GetAllPassengersHandler(IPassengerRepository passengerrepository, IValidator<GetAllPassengersQuery> validator, ILogger<GetAllPassengersHandler> logger)
        {
            _passengerRepository = passengerrepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<List<PassengerDto>> Handle(GetAllPassengersQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            var passengers = await _passengerRepository.GetPassengersAsync(request.Survived, cancellationToken);

            return passengers.Select(p => p.ToPassengerDto()).ToList();
        }

//FluentValidation is supposed to validate input, not results
// If your goal is to validate the query input, like:
//Survived must be true, false, or null (which it already is because it’s a nullable bool).
//Anything else the user is passing in through GetAllPassengersQuery.
//But you are currently validating the retrieved data from the database, which is not typically done in FluentValidation—unless you're validating commands before writing to the database.

    }
}
