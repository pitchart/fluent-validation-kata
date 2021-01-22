using FluentValidation.TestHelper;
using FluentValidationKata.Domain;
using FluentValidationKata.Domain.Validation;
using Xunit;

namespace FluentValidationKata.Tests
{
    public class ProductValidatorTest
    {
        [Fact]
        public void should_fail_with_blank_reference()
        {
            var product = new Product
            {
                Reference = ""
            };

            var productValidator = new ProductValidator();

            var result = productValidator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(nameof(product.Reference));
        }

        [Fact]
        public void should_pass_with_correct_reference()
        {
            var product = new Product
            {
                Reference = "reference"
            };

            var productValidator = new ProductValidator();

            var result = productValidator.TestValidate(product);

            result.ShouldNotHaveValidationErrorFor(product => product.Reference);
        }
    }
}
