using FluentAssertions;
using NUnit.Framework;

namespace RomanNumeralsConverter.Tests
{
  class ValidationResultTests
  {
    private ValidationResult _validationResult;

    [Test]
    public void Should_ValidationResultBeInvalid_When_ContainsAtLeastOneErrorMessage()
    {
      _validationResult = ValidationResult.CreateInvalidValidationResult("TestErrorMessage");

      _validationResult.IsValid.Should().BeFalse();
    }

    [Test]
    public void Should_ValidationResultBeValid_When_ContainsNoErrorMessages()
    {
      _validationResult = ValidationResult.CreateValidValidationResult();

      _validationResult.IsValid.Should().BeTrue();
    }
  }
}
