using System;
using FluentAssertions;
using NUnit.Framework;

namespace RomanNumeralsConverter.Tests
{
  internal class RomanNumeralValidatorTests
  {
    private RomanNumeralValidator _validator;

    [SetUp]
    public void SetUp()
    {
      _validator = new RomanNumeralValidator();
    }

    //TODO: tests with numerical values - how to test this? Reading lines from console returns string
    [Test]
    [TestCase("A")]
    [TestCase("XP")]
    [TestCase(" ")]
    [TestCase("%")]
    public void Should_ReturnNotValidRomanNumeralError_When_InputHasCharactersOtherThanValidRomanNumerals(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - one or more input characters are not a valid Roman numeral";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase(null)]
    public void Should_ReturnNullInputValidationError_When_InputIsNull(string romanNumeral)
    {
      const string errorMessage = "Input not given";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase("")]
    public void Should_ReturnNullInputValidationError_When_InputIsEmpty(string romanNumeral)
    {
      const string errorMessage = "Input not given";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase("XXXX")]
    public void Should_ReturnThreeNumeralsInARowError_When_MoreThanThreeNumeralsOtherThanMInARow(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - more than three numerals other than M in a row";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase("IL")]
    public void Should_ReturnSmallerIsLessThanOneTenthOfTheLargerError_When_SmallerIsLessThanOneTenthOfTheLarger(string romanNumeral) //TODO: to split into separate tests (edge cases), name is awful
    {
      const string errorMessage = "Input is invalid - smaller value to the left and is less then one tenth of the next numeral value found";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase("VX")]
    public void Should_ReturnSmallerValueFirstDigitDivisibleBy5Error_When_SmallerValueBeforeLarger_AndConvertedSmallerValueFirstDigitDivisibleBy5(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - smaller value to the left and is either V, L or D";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase("XXXVV")]
    public void Should_ReturnVorLorDRepeatedMoreThanOnceError_When_VorLorDRepeatedMoreThanOnce(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - V, L or D repeated more than once";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }

    [TestCase("VIX")]
    [TestCase("IXC")]
    [TestCase("XCX")]
    public void Should_ReturnBiggerNumeralAfterSmallerNumeralError_When_BiggerNumeralAfterSmallerNumeral(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - the value must never increase from one letter to the next unless substracting";

      var result = _validator.Validate(romanNumeral);

      result.Messages.Should().Contain(errorMessage);
    }
  }
}
