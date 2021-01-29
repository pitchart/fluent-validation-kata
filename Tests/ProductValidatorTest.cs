using FluentValidation.TestHelper;
using FluentValidationKata.Domain;
using FluentValidationKata.Domain.Validation;
using Xunit;

namespace FluentValidationKata.Tests
{
    public class ProductValidatorTest
    {
        [Theory]
        [MemberData(nameof(ProductValidatorTestData.InvalidParameters), MemberType = typeof(ProductValidatorTestData))]
        public void should_fail_with_blank_value_for_mandatory_properties(Product product, string fieldName)
        {
            var productValidator = new ProductValidator();

            var result = productValidator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(fieldName);
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

        [Fact]
        public void should_fail_with_blank_language()
        {
            var product = new Product
            {
                Language = ""
            };

            var productValidator = new ProductValidator();

            var result = productValidator.TestValidate(product);

            result.ShouldHaveValidationErrorFor(nameof(product.Language));
        }

        [Fact]
        public void should_pass_with_correct_language()
        {
            var product = new Product
            {
                Language = "reference"
            };

            var productValidator = new ProductValidator();

            var result = productValidator.TestValidate(product);

            result.ShouldNotHaveValidationErrorFor(product => product.Language);
        }
    }
}
