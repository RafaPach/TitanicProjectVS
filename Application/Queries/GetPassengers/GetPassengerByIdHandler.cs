using DeveloperPathways.Dtos;
using DeveloperPathways.Interface;
using DeveloperPathways.Mappers;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetPassengers
{
    public class GetPassengerByIdHandler : IRequestHandler<GetPassengerByIdQuery, PassengerDto>
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IValidator<GetPassengerByIdQuery> _validator;
        private readonly ILogger<GetPassengerByIdHandler> _logger;

        public GetPassengerByIdHandler(IPassengerRepository passengerRepository, IValidator<GetPassengerByIdQuery> validator, ILogger<GetPassengerByIdHandler> logger)
        {
            _passengerRepository = passengerRepository;
            _validator = validator;
            _logger = logger;
        }
        public async Task<PassengerDto> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetPassengerByIdAsync(request.Id, cancellationToken);

            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Validation failed: {Errors}", validationResult.Errors);
                throw new ValidationException(validationResult.Errors);
            }

            return passenger.ToPassengerDto();

        }

    }
}
