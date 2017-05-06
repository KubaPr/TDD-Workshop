using FluentAssertions;
using NUnit.Framework;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter.Tests.ValidationRulesTests
{
  internal class InputGivenValidatorTests
  {
    private InputGivenValidator _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new InputGivenValidator();
    }

    [TestCase(null)]
    public void Should_ReturnNullInputValidationError_When_InputIsNull(string romanNumeral)
    {
      const string errorMessage = "Input not given";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }

    [TestCase("")]
    public void Should_ReturnNullInputValidationError_When_InputIsEmpty(string romanNumeral)
    {
      const string errorMessage = "Input not given";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }
  }
}