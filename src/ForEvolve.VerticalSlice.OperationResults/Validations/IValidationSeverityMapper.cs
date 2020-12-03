using FluentValidation;

namespace ForEvolve.OperationResults.Validations
{
    public interface IValidationSeverityMapper
    {
        OperationMessageLevel Map(Severity severity);
    }
}

