using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsConverter
{
  public class RomanNumeralValidationManager : IRomanNumeralValidationManager
  {
    private readonly IRomanNumeralValidator[] _validationRules;

    public RomanNumeralValidationManager(IRomanNumeralValidator[] validationRules)
    {
      _validationRules = validationRules;
    }

    public ValidationResult Validate(string input)
    {
      var results = new List<ValidationResult>();

      foreach (var rule in _validationRules)
      {
        var validationResult = rule.Validate(input);

        if (rule.ShouldStopOnError)
        {
          if (!validationResult.IsValid) return validationResult;
        }
        else
        {
          results.Add(validationResult);
        }
      }

      if (results.All(r => r.IsValid)) return ValidationResult.CreateValidValidationResult();

      return ValidationResult.CreateInvalidValidationResult(AggregateErrorMessages(results));
    }

    private static string AggregateErrorMessages(IEnumerable<ValidationResult> results)
    {
      var aggregatedErrorMessage = results.Aggregate("", (current, res) => current + res.ErrorMessage + Environment.NewLine);
      return aggregatedErrorMessage;
    }
  }
}