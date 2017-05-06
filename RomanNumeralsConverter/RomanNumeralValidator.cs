using System;
using System.Collections.Generic;
using System.Linq;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter
{
  public class RomanNumeralValidator : IRomanNumeralValidator
  {
    private readonly IRomanNumeralValidator _inputGivenValidator;
    private readonly IRomanNumeralValidator _allCharactersValidator;
    private readonly IRomanNumeralValidator _noThreeSameNumeralsOtherThanMinARowValidator;
    private readonly IRomanNumeralValidator _smallerValueBeforeLargerValueValidator;
    private readonly IRomanNumeralValidator _vorLorDNotRepeatedValidator;

    public RomanNumeralValidator()
    {
      _inputGivenValidator = new InputGivenValidator();
      _allCharactersValidator = new AllCharactersValidator();
      _noThreeSameNumeralsOtherThanMinARowValidator = new NoThreeSameNumeralsOtherThanMInARowValidator();
      _smallerValueBeforeLargerValueValidator = new SmallerValueBeforeLargerValueValidator();
      _vorLorDNotRepeatedValidator = new VorLorDNotRepeatedValidator();
    }

    public ValidationResult Validate(string input)
    {
      var results = new List<ValidationResult>();

      if (!_inputGivenValidator.Validate(input).IsValid)
      {
        return _inputGivenValidator.Validate(input);
      }
      if (!_allCharactersValidator.Validate(input).IsValid)
      {
        return _allCharactersValidator.Validate(input);
      }

      if (!_noThreeSameNumeralsOtherThanMinARowValidator.Validate(input).IsValid)
      {
        results.Add(_noThreeSameNumeralsOtherThanMinARowValidator.Validate(input));
      }
      if (!_smallerValueBeforeLargerValueValidator.Validate(input).IsValid)
      {
        results.Add(_smallerValueBeforeLargerValueValidator.Validate(input));
      }
      if (!_vorLorDNotRepeatedValidator.Validate(input).IsValid)
      {
        results.Add(_vorLorDNotRepeatedValidator.Validate(input));
      }

      if (results.All(r => r.IsValid)) return ValidationResult.CreateValidValidationResult();

      var aggregatedErrorMessage = results.Aggregate("", (current, res) => current + res.ErrorMessage + Environment.NewLine);

      return ValidationResult.CreateInvalidValidationResult(aggregatedErrorMessage);
    }
  }
}