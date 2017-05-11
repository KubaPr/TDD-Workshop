namespace RomanNumeralsConverter.ValidationRules
{
  public class InputGivenValidator : IRomanNumeralValidator
  {
    public bool ShouldStopOnError { get; }

    public InputGivenValidator()
    {
      ShouldStopOnError = true;
    }

    public ValidationResult Validate(string romanNumeral)
    {
      if (string.IsNullOrEmpty(romanNumeral))
      {
        return ValidationResult.CreateInvalidValidationResult("Input not given");
      }

      return ValidationResult.CreateValidValidationResult();
    }
  }
}