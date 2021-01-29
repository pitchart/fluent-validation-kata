using FluentValidation.TestHelper;
using FluentValidationKata.Domain;
using FluentValidationKata.Domain.Validation;
using Xunit;

namespace FluentValidationKata.Tests
{
    public class ProductValidatorTest
    {
        private readonly ProductValidator _productValidator;

        public ProductValidatorTest()
        {
            _productValidator = new ProductValidator();
        }

        [Theory]
        [MemberData(nameof(ProductValidatorTestData.InvalidParameters), MemberType = typeof(ProductValidatorTestData))]
        public void should_fail_with_blank_value_for_mandatory_properties(InvalidProductParameter data)
        {
            // Act
            var result = _productValidator.TestValidate(data.Product);

            // Assert
            result.ShouldHaveValidationErrorFor(data.FieldName);
        }

        [Fact]
        public void should_pass_with_correct_parameters()
        {
            // Arrange
            var product = new Product
            {
                Reference = "reference",
                Language = "reference",
                CategoryId = "010101",
                SellerId = "4364",
                Gtin = "gtin"
            };

            // Act
            var result = _productValidator.TestValidate(product);
            
            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
