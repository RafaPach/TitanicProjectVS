//using FluentValidation;
//using MediatR;
//using Microsoft.Extensions.Logging;

//namespace DeveloperPathways.Application.Common.Behaviors
//{
//    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//        where TRequest : IRequest<TResponse>
//    {
//        private readonly IEnumerable<IValidator<TRequest>> _validators;
//        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

//        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
//        {
//            _validators = validators;
//            _logger = logger;
//        }

//        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//        {
//            if (_validators.Any())
//            {
//                _logger.LogInformation("Running validation on {RequestType}", typeof(TRequest).Name);

//                var context = new ValidationContext<TRequest>(request);

//                var validationResults = await Task.WhenAll(
//                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
//                );

//                var failures = validationResults
//                    .SelectMany(r => r.Errors)
//                    .Where(f => f != null)
//                    .ToList();

//                if (failures.Count != 0)
//                {
//                    _logger.LogWarning("Validation failures: {Failures}", failures);
//                    throw new ValidationException(failures);
//                }
//            }

//            // ✅ If validation passed, continue to next behavior/handler
//            return await next();
//        }
//    }
//}
