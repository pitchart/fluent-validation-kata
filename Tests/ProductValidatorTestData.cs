using FluentValidationKata.Domain;
using Xunit;

namespace FluentValidationKata.Tests
{
    public class ProductValidatorTestData
    {
        public static TheoryData<dynamic> InvalidParameters => new TheoryData<dynamic>()
        {
            new {
                product = new Product
                {
                    Reference = "reference"
                },
                fieldName = "Reference"
            }
        };
    }
}
