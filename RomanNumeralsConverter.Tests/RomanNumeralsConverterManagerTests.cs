using NUnit.Framework;
using Rhino.Mocks;

namespace RomanNumeralsConverter.Tests
{
  internal class RomanNumeralsConverterManagerTests
  {
    private RomanNumeralValidator _romanNumeralValidator;

    [SetUp]
    public void SetUp()
    {
      _romanNumeralValidator = new RomanNumeralValidator();
    }

    [TestCase("V")]
    public void Should_ConvertRomanNumeralToArabic_When_ValidationIsSuccessful(string validRomanNumeral) //is the name good? Would the name like Should_CallConvertToArabic_When... be good?
    {
      var romanNumeralsConverterMock = MockRepository.GenerateMock<IRomanToArabicConverter>();
      var romanToArabicConverterManager = new RomanToArabicConverterManager(romanNumeralsConverterMock, _romanNumeralValidator);

      romanToArabicConverterManager.TryConvertingRomanToArabic(validRomanNumeral);

      romanNumeralsConverterMock.AssertWasCalled(c => c.ConvertToArabic(validRomanNumeral));
    }

    [TestCase("VV")]
    public void Should_NotConvertRomanNumeralToArabic_When_ValidationIsUnsuccessful(string invalidRomanNumeral)
    {
      var romanNumeralsConverterMock = MockRepository.GenerateMock<IRomanToArabicConverter>();
      var romanToArabicConverterManager = new RomanToArabicConverterManager(romanNumeralsConverterMock, _romanNumeralValidator);

      romanToArabicConverterManager.TryConvertingRomanToArabic(invalidRomanNumeral);

      romanNumeralsConverterMock.AssertWasNotCalled(c => c.ConvertToArabic(invalidRomanNumeral));
    }

    [TestCase("VV")]
    public void Should_ReturnValidationErrors_When_ValidationIsUnsuccessful(string invalidRomanNumeral)
    {
      var romanNumeralsConverterMock = MockRepository.GenerateMock<IRomanToArabicConverter>();
      var romanToArabicConverterManager = new RomanToArabicConverterManager(romanNumeralsConverterMock, _romanNumeralValidator);

      romanToArabicConverterManager.TryConvertingRomanToArabic(invalidRomanNumeral);

      romanNumeralsConverterMock.AssertWasNotCalled(c => c.ConvertToArabic(invalidRomanNumeral));
    }
  }
}
