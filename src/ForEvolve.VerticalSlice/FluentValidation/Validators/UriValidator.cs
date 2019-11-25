using FluentValidation.Validators;
using System;

namespace ForEvolve.FluentValidation.Validators
{
    public class UriValidator : PropertyValidator
    {
        private readonly UriKind _uriKind;
        public UriValidator(UriKind uriKind)
            : base("{PropertyName} is not a valid path.")
        {
            _uriKind = uriKind;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var path = context.PropertyValue as string;
            if (path == null && context.PropertyValue != null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(path))
            {
                return true;
            }
            return Uri.IsWellFormedUriString(path, _uriKind);
        }
    }
}
