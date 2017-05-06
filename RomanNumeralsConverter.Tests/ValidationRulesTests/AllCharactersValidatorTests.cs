using FluentAssertions;
using NUnit.Framework;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter.Tests.ValidationRulesTests
{
  internal class AllCharactersValidatorTests
  {
    private AllCharactersValidator _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new AllCharactersValidator();
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

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }
  }
}