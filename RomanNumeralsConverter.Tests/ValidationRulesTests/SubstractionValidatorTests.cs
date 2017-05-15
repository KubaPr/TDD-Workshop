using FluentAssertions;
using NUnit.Framework;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter.Tests.ValidationRulesTests
{
  internal class SubstractionValidatorTests
  {
    private SubstractionValidator _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new SubstractionValidator();
    }

    [TestCase("IL")]
    public void Should_ReturnSubtrahendIsLessThanOneTenthOfTheMinuendError_When_SubtrahendIsLessThanOneTenthOfTheMinuend(string romanNumeral) //TODO: to split into separate tests (edge cases), name is awful
    {
      const string errorMessage = "Input is invalid - subtrahend is less then one tenth of the minuend";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }

    [TestCase("VX")]
    public void Should_ReturnSmallerValueFirstDigitDivisibleBy5Error_When_SubstractedValueIsVLorD(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - substracted value is either V, L or D";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }

    [TestCase("VIX")]
    [TestCase("IXC")]
    [TestCase("XCX")]
    public void Should_ReturnBiggerNumeralAfterSmallerNumeralError_When_BiggerNumeralAfterSmallerNumeral(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - the value must never increase from one letter to the next unless substracting";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }
  }
}