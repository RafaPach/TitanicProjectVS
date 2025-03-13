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
            var passengers = await _passengerRepository.GetPassengersAsync(request.Survived, cancellationToken);
            request.Passengers = passengers.Select(p => p.ToPassengerDto()).ToList();

            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            return request.Passengers;

        }

    }
}
