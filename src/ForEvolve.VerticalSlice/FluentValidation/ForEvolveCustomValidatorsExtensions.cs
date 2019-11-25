using ForEvolve.FluentValidation.Validators;
using System;

namespace FluentValidation
{
    public static class ForEvolveCustomValidatorsExtensions
    {
        public static IRuleBuilderOptions<T, string> Uri<T>(this IRuleBuilder<T, string> ruleBuilder, UriKind uriKind = UriKind.RelativeOrAbsolute)
        {
            return ruleBuilder.SetValidator(new UriValidator(uriKind));
        }
    }
}
