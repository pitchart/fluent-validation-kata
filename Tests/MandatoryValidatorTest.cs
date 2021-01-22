using FluentValidation;
using FluentValidation.TestHelper;
using FluentValidationKata.Domain.Validation;
using Xunit;

namespace FluentValidationKata.Tests
{
    public class MandatoryValidatorTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void should_failed_for_incorrect_value(string value)
        {
            var mandatoryFixture = new MandatoryFixture
            {
                Mandatory = value
            };

            var mandatoryValidator = new MandatoryFixtureValidator();

            var result = mandatoryValidator.TestValidate(mandatoryFixture);

            result.ShouldHaveValidationErrorFor(mandatoryFixture => mandatoryFixture.Mandatory);
        }

        [Fact]
        public void should_pass_for_correct_value()
        {
            var mandatoryFixture = new MandatoryFixture
            {
                Mandatory = "mandatory"
            };
            var mandatoryValidator = new MandatoryFixtureValidator();

            var result = mandatoryValidator.TestValidate(mandatoryFixture);

            result.ShouldNotHaveValidationErrorFor(mandatoryFixture => mandatoryFixture.Mandatory);
        }
    }

    public class MandatoryFixture
    {
        public string Mandatory { get; set; }
    }

    public class MandatoryFixtureValidator : AbstractValidator<MandatoryFixture>
    {
        public MandatoryFixtureValidator()
        {
            RuleFor(mandatory => mandatory.Mandatory).IsMandatory();
        }
    }
}
