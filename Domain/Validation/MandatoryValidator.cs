using FluentValidation;

namespace FluentValidationKata.Domain.Validation
{
    public static class MandatoryValidator
    {
        public static IRuleBuilderOptions<T, string> IsMandatory<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty();
        }
    }
}
