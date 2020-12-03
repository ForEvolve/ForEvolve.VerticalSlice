using FluentValidation.Results;
using ForEvolve.OperationResults.AspNetCore;
using System;

namespace ForEvolve.OperationResults.Validations
{
    public class ValidationFailureMessageMapper : IValidationFailureMapper
    {
        private readonly IValidationSeverityMapper _severityMapper;
        private readonly IProblemDetailsMapper _problemDetailsMapper;
        public ValidationFailureMessageMapper(IValidationSeverityMapper severityMapper, IProblemDetailsMapper problemDetailsMapper)
        {
            _severityMapper = severityMapper ?? throw new ArgumentNullException(nameof(severityMapper));
            _problemDetailsMapper = problemDetailsMapper ?? throw new ArgumentNullException(nameof(problemDetailsMapper));
        }

        public IMessage Map(ValidationFailure validationFailure)
        {
            var severity = _severityMapper.Map(validationFailure.Severity);
            var details = _problemDetailsMapper.Map(validationFailure);
            return new ProblemDetailsMessage(details, severity);
        }
    }
}

