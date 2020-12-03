using FluentValidation.Results;

namespace ForEvolve.OperationResults.Validations
{
    public interface IValidationFailureMapper
    {
        IMessage Map(ValidationFailure validationFailure);
    }
}

