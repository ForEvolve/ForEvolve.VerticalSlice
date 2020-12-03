using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ForEvolve.OperationResults.Validations
{
    public class SimpleProblemDetailsMapper : IProblemDetailsMapper
    {
        public ProblemDetails Map(ValidationFailure validationFailure)
        {
            var details = new ProblemDetails
            {
                Title = validationFailure.ErrorCode,
                Detail = validationFailure.ErrorMessage,
            };
            details.Extensions["propertyName"] = validationFailure.PropertyName;
            return details;
        }
    }
}

