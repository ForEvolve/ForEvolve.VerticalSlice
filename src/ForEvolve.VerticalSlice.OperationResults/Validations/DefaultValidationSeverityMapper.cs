using FluentValidation;

namespace ForEvolve.OperationResults.Validations
{
    public class DefaultValidationSeverityMapper : IValidationSeverityMapper
    {
        public OperationMessageLevel Map(Severity severity) => severity switch
        {
            Severity.Warning => OperationMessageLevel.Warning,
            Severity.Info => OperationMessageLevel.Information,
            _ => OperationMessageLevel.Error,
        };
    }
}

