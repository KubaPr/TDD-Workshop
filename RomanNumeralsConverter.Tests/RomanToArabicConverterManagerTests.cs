﻿using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Impl;

namespace RomanNumeralsConverter.Tests
{
  internal class RomanToArabicConverterManagerTests
  {
    private RomanNumeralValidationManager _romanNumeralValidationManager;
    private RomanToArabicConverter _romanToArabicConverterMock;
    private RomanToArabicConverterManager _subject;

    [SetUp]
    public void SetUp()
    {
      _romanNumeralValidationManager = MockRepository.GenerateStub<RomanNumeralValidationManager>(new IRomanNumeralValidator[1]);
      _romanToArabicConverterMock = MockRepository.GenerateStub<RomanToArabicConverter>();

      _subject = new RomanToArabicConverterManager(_romanToArabicConverterMock, _romanNumeralValidationManager);
    }

    [TestCase("V")]
    public void Should_ConvertRomanNumeralToArabic_When_ValidationIsSuccessful(string validRomanNumeral) //is the name good? Would the name like Should_CallConvertToArabic_When... be good?
    {
      _romanNumeralValidationManager.Stub(x => x.Validate(validRomanNumeral)).Return(ValidationResult.CreateValidValidationResult());

      _subject.TryConvertingRomanToArabic(validRomanNumeral);

      _romanToArabicConverterMock.AssertWasCalled(c => c.ConvertToArabic(validRomanNumeral));
    }

    [TestCase("VV")]
    public void Should_NotConvertRomanNumeralToArabic_When_ValidationIsUnsuccessful(string invalidRomanNumeral)
    {
      _romanNumeralValidationManager.Stub(x => x.Validate(invalidRomanNumeral)).Return(ValidationResult.CreateInvalidValidationResult("Dummy error message"));

      _subject.TryConvertingRomanToArabic(invalidRomanNumeral);

      _romanToArabicConverterMock.AssertWasNotCalled(c => c.ConvertToArabic(invalidRomanNumeral));
    }

    [TestCase("VV")]
    public void Should_ReturnValidationErrors_When_ValidationIsUnsuccessful(string invalidRomanNumeral)
    {
      _romanNumeralValidationManager.Stub(x => x.Validate(invalidRomanNumeral)).Return(ValidationResult.CreateInvalidValidationResult("Dummy error message"));

      _subject.TryConvertingRomanToArabic(invalidRomanNumeral);

      _romanToArabicConverterMock.AssertWasNotCalled(c => c.ConvertToArabic(invalidRomanNumeral));
    }
  }
}
