using FluentAssertions;
using NUnit.Framework;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter.Tests.ValidationRulesTests
{
  internal class VorLorDNotRepeatedValidatorTests
  {
    private VorLorDNotRepeatedValidator _subject;

    [SetUp]
    public void SetUp()
    {
      _subject = new VorLorDNotRepeatedValidator();
    }

    [TestCase("XXXVV")]
    public void Should_ReturnVorLorDRepeatedMoreThanOnceError_When_VorLorDRepeatedMoreThanOnce(string romanNumeral)
    {
      const string errorMessage = "Input is invalid - V, L or D repeated more than once";

      var result = _subject.Validate(romanNumeral);

      result.ErrorMessage.Should().Contain(errorMessage);
    }
  }
}