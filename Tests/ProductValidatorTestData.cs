using FluentValidationKata.Domain;
using Xunit;

namespace FluentValidationKata.Tests
{
    public class ProductValidatorTestData
    {
        public static TheoryData<InvalidProductParameter> InvalidParameters => new TheoryData<InvalidProductParameter>
        {
            new  InvalidProductParameter //#1 reference
                {
                Product = new Product
                {
                    Reference = ""
                },
                FieldName = "Reference"
            },
            new InvalidProductParameter //#2 language
                {
                Product = new Product
                {
                    Language = ""
                },
                FieldName = "Language"
            },
            new InvalidProductParameter //#3 category id
                {
                Product = new Product
                {
                    CategoryId = ""
                },
                FieldName = "CategoryId"
            },
            new InvalidProductParameter //#4 seller id
                {
                Product = new Product
                {
                    SellerId = ""
                },
                FieldName = "SellerId"
            },
            new InvalidProductParameter //#5 gtin
                {
                Product = new Product
                {
                    Gtin = ""
                },
                FieldName = "Gtin"
            }
        };
    }

    public class InvalidProductParameter
    {
        public Product Product { get; set; }

        public string FieldName { get; set; }
    }
}
