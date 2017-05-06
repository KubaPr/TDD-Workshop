using FluentAssertions.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace RomanNumeralsConverter.Tests
{
  internal class RomanNumeralValidatorTests
  {
    private RomanNumeralValidator _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = MockRepository.GenerateMock<RomanNumeralValidator>();
    }

    [Test]
    public void Should_ValidationResultBeValid_WhenGivenValidRomanNumeral()
    {
      _subject.Validate("I").IsValid.IsSameOrEqualTo(ValidationResult.CreateValidValidationResult().IsValid);
    }

    [Test]
    public void Should_ValidationResultBeInvalid_WhenGivenInvalidRomanNumeral()
    {
      _subject.Validate("!").IsValid.IsSameOrEqualTo(ValidationResult.CreateInvalidValidationResult("Dummy error message").IsValid);
    }
  }
}
