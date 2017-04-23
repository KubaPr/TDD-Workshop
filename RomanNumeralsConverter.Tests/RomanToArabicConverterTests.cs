using FluentAssertions;
using NUnit.Framework;

namespace RomanNumeralsConverter.Tests
{
  internal class RomanToArabicConverterTests
  {
    private RomanToArabicConverter _romanToArabicConverter;

    [SetUp]
    public void SetUp()
    {
      _romanToArabicConverter = new RomanToArabicConverter();
    }

    [TestCase("I", 1)]
    [TestCase("V", 5)]
    [TestCase("X", 10)]
    [TestCase("L", 50)]
    [TestCase("C", 100)]
    [TestCase("D", 500)]
    [TestCase("M", 1000)]
    public void Should_ReturnExpectedArabic_When_GivenSingleConstantRoman(string romanNumber, int expectedArabicNumber)
    {
      var convertedNumber = _romanToArabicConverter.ConvertToArabic(romanNumber);
      convertedNumber.Should().Be(expectedArabicNumber);
    }

    [TestCase("XI", 11)]
    [TestCase("DCLXVI", 666)]
    public void Should_AddNumeralValueToTotal_When_NumeralValueIsGreaterOrEqualToNextNumeralValue(string romanNumber, int expectedArabicNumber)
    {
      var convertedNumber = _romanToArabicConverter.ConvertToArabic(romanNumber);
      convertedNumber.Should().Be(expectedArabicNumber);
    }

    [TestCase("XL", 40)]
    [TestCase("IV", 4)]
    public void Should_SubstractNumeralValueFromTotal_When_NumeralValueIsLessThanNextNumeralValue(string romanNumber, int expectedArabicNumber)
    {
      var convertedNumber = _romanToArabicConverter.ConvertToArabic(romanNumber);
      convertedNumber.Should().Be(expectedArabicNumber);
    }

  }
}