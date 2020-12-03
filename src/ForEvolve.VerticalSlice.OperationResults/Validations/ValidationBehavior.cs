using FluentValidation;
using ForEvolve.OperationResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ForEvolve.OperationResults.Validations
{
    /// <summary>
    /// This behavior runs all validators and returns the error as an 
    /// <see cref="IOperationResult"/> if validation fails.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<IOperationResult>
        where TResponse : IOperationResult
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IValidationFailureMapper _validationFailureMapper;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IValidationFailureMapper validationFailureMapper)
        {
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
            _validationFailureMapper = validationFailureMapper ?? throw new ArgumentNullException(nameof(validationFailureMapper));
        }

        /// <inheritdoc />
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Validate
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(r => r.Errors);
            if (failures.Any())
            {
                // Map errors to output
                var messages = failures
                    .Select(validationFailure => _validationFailureMapper.Map(validationFailure))
                    .ToArray();

                // Try to return the result
                var castedResult = OperationResult
                    .Failure(messages)
                    .ConvertTo<TResponse>();
                if (castedResult != null)
                {
                    return castedResult;
                }
            }
            return await next();
        }
    }
}

