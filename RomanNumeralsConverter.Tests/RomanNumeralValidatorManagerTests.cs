using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;

namespace RomanNumeralsConverter.Tests
{
  internal class RomanNumeralValidatorManagerTests
  {
    [Test]
    public void Should_AllValidationsBeCalled_When_NoCriticalValidations()
    {
      const string validInput = "test";
      var stubbedNonCriticalValidation = GenerateNonCriticalValidationRule();
      var stubbedAnotherNonCriticalValidation = GenerateNonCriticalValidationRule();

      var stubbedNonCriticalValidationRules = new[]
      {
        stubbedNonCriticalValidation, stubbedAnotherNonCriticalValidation
      };

      var subject = new RomanNumeralValidationManager(stubbedNonCriticalValidationRules);
      subject.Validate(validInput);

      foreach (var rule in stubbedNonCriticalValidationRules)
      {
        rule.AssertWasCalled(x => x.Validate(validInput));
      }
    }

    [Test]
    public void Should_ReturnTheResultOfTheCriticalValidation_When_CriticalValidationResultIsInvalid()
    {
      const string invalidInput = "test";
      var stubbedNonCriticalValidation = GenerateNonCriticalValidationRule();
      var stubbedCriticalValidation = GenerateCriticalValidationRule();

      var stubbedValidationRules = new[]
      {
        stubbedNonCriticalValidation, stubbedCriticalValidation
      };

      var subject = new RomanNumeralValidationManager(stubbedValidationRules);
      var result = subject.Validate(invalidInput);

      result.ShouldBeEquivalentTo(stubbedCriticalValidation.Validate(invalidInput));
    }

    [Test]
    public void Should_ReturnTheMessagesOfInvalidResults_When_OnlyNonCriticalValidationsResultsAreInvalid() //name?
    {
      const string invalidInput = "test";
      var stubbedNonCriticalValidation = GenerateNonCriticalValidationRule();
      var stubbedAnotherNonCriticalValidation = GenerateNonCriticalValidationRule();

      var stubbedValidationRules = new[]
      {
        stubbedNonCriticalValidation, stubbedAnotherNonCriticalValidation
      };

      var subject = new RomanNumeralValidationManager(stubbedValidationRules);
      var result = subject.Validate(invalidInput);

      foreach (var rule in stubbedValidationRules)
      {
        result.ErrorMessage.Should().Contain(rule.Validate(invalidInput).ErrorMessage); //are those two assertions per test? or not in this case?
      }
    }

    private static IRomanNumeralValidator GenerateNonCriticalValidationRule()
    {
      var stubbedNonCriticalValidation = MockRepository.GenerateStub<IRomanNumeralValidator>();
      stubbedNonCriticalValidation.Stub(x => x.ShouldStopOnError).Return(false);
      stubbedNonCriticalValidation.Stub(x => x.Validate("test")).Return(ValidationResult.CreateInvalidValidationResult("Dummy non-critical error message"));
      return stubbedNonCriticalValidation;
    }

    private static IRomanNumeralValidator GenerateCriticalValidationRule()
    {
      var stubbedCriticalValidation = MockRepository.GenerateStub<IRomanNumeralValidator>();
      stubbedCriticalValidation.Stub(x => x.ShouldStopOnError).Return(true);
      stubbedCriticalValidation.Stub(x => x.Validate("test")).Return(ValidationResult.CreateInvalidValidationResult("Dummy critical error message"));
      return stubbedCriticalValidation;
    }
  }
}
