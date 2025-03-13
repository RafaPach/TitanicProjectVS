using DeveloperPathways.Dtos;
using DeveloperPathways.Interface;
using DeveloperPathways.Mappers;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetByAge
{
    public class GetPassengersByAgeHandler : IRequestHandler<GetPassengersByAgeQuery, List<PassengerDto>>
    {
        private readonly IGetByAgeRepository _getByAgeRepository;
        private readonly IValidator<GetPassengersByAgeQuery> _validator;
        private readonly ILogger<GetPassengersByAgeHandler> _logger;

        public GetPassengersByAgeHandler(IGetByAgeRepository getByAgeRepository, IValidator<GetPassengersByAgeQuery> validator, ILogger<GetPassengersByAgeHandler> logger)
        {
            _getByAgeRepository = getByAgeRepository;
            _validator = validator;
            _logger = logger;
        }

        public async Task<List<PassengerDto>> Handle(GetPassengersByAgeQuery request, CancellationToken cancellationToken)
        {
            var passenger = await _getByAgeRepository.GetByAgeAsync(cancellationToken);

            request.Passengers = passenger.Select(p => p.ToPassengerDto()).ToList();

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