using FluentAssertions;
using NUnit.Framework;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter.Tests.ValidationRulesTests
{
  internal class NoThreeSameNumeralsOtherThanMInARowValidatorTests
  {
    private NoThreeSameNumeralsOtherThanMInARowValidator _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new NoThreeSameNumeralsOtherThanMInARowValidator();
    }

    [TestCase("XXXX")]
    public void Should_ReturnThreeNumeralsInARowError_When_MoreThanThreeNumeralsOtherThanMInARow(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - more than three numerals other than M in a row";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }
  }
}