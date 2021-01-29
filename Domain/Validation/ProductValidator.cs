using FluentValidation;

namespace FluentValidationKata.Domain.Validation
{
    class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Reference).IsMandatory();

            RuleFor(product => product.Language).IsMandatory();

            RuleFor(product => product.CategoryId).IsMandatory();

            RuleFor(product => product.SellerId).IsMandatory();

            RuleFor(product => product.Gtin).IsMandatory();
        }
    }
}
