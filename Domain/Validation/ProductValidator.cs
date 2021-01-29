using FluentValidation;

namespace FluentValidationKata.Domain.Validation
{
    class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Reference).IsMandatory();

            RuleFor(product => product.Language).IsMandatory();
        }
    }
}
