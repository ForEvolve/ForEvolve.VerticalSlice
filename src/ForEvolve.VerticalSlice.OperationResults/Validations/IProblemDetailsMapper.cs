using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ForEvolve.OperationResults.Validations
{
    public interface IProblemDetailsMapper
    {
        ProblemDetails Map(ValidationFailure validationFailure);
    }
}

