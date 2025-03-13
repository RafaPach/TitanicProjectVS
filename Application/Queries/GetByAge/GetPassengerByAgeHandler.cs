

//namespace DeveloperPathways.Application.Queries.GetByAge
//{
//    public class GetPassengersByAgeHandler : IRequestHandler<GetPassengersByAgeQuery, List<PassengerDto>>
//    {
//        private readonly IGetByAgeRepository _getByAgeRepository;
//        private readonly IValidator<GetPassengersByAgeQuery> _validator;
//        private readonly ILogger<GetPassengersByAgeHandler> _logger;

//        public GetPassengersByAgeHandler(
//            IGetByAgeRepository getByAgeRepository,
//            IValidator<GetPassengersByAgeQuery> validator,
//            ILogger<GetPassengersByAgeHandler> logger)
//        {
//            _getByAgeRepository = getByAgeRepository;
//            _validator = validator;
//            _logger = logger;
//        }

//        public async Task<List<PassengerDto>> Handle(GetPassengersByAgeQuery request, CancellationToken cancellationToken)
//        {
//            // Validate the query request input (MinAge, MaxAge)
//            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

//            if (!validationResult.IsValid)
//            {
//                _logger.LogError("Validation failed: {Errors}", validationResult.Errors);
//                throw new ValidationException(validationResult.Errors);
//            }

//            // Fetch data from the repository
//            var passengers = await _getByAgeRepository.GetByAgeAsync(request.MinAge, request.MaxAge, cancellationToken);

//            // Map to DTO and return
//            return passengers.Select(p => p.ToPassengerDto()).ToList();
//        }
//    }
//}


//We DONT NEED MIN AGE OR MAX AGE BECAUSE NOITHING IN INPUT THO


using DeveloperPathways.Dtos;
using DeveloperPathways.Interface;
using DeveloperPathways.Mappers;
using MediatR;

namespace DeveloperPathways.Application.Queries.GetByAge
{
    public class GetPassengersByAgeHandler : IRequestHandler<GetPassengersByAgeQuery, List<PassengerDto>>
    {
        private readonly IGetByAgeRepository _getByAgeRepository;
        private readonly ILogger<GetPassengersByAgeHandler> _logger;

        public GetPassengersByAgeHandler(
            IGetByAgeRepository getByAgeRepository,
            ILogger<GetPassengersByAgeHandler> logger)
        {
            _getByAgeRepository = getByAgeRepository;
            _logger = logger;
        }

        public async Task<List<PassengerDto>> Handle(GetPassengersByAgeQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching passengers ordered by age...");

            var passengers = await _getByAgeRepository.GetByAgeAsync(cancellationToken);

            return passengers.Select(p => p.ToPassengerDto()).ToList();
        }
    }
}
