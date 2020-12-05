
namespace FluentValidation
{
    using ForEvolve.Validations.Validators;
    using System;

    public static class ForEvolveVerticalSliceValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> Uri<T>(this IRuleBuilder<T, string> ruleBuilder, UriKind uriKind = UriKind.RelativeOrAbsolute)
        {
            return ruleBuilder.SetValidator(new UriValidator(uriKind));
        }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    using ForEvolve.Validations;
    using MediatR;

    public static class ForEvolveVerticalSliceValidationExtensions
    {
        public static IServiceCollection AddThrowValidationExceptionBehavior(this IServiceCollection services)
        {
            return services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ThrowValidationExceptionBehavior<,>));
        }
    }
}