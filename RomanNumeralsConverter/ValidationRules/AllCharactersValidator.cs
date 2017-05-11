namespace RomanNumeralsConverter.ValidationRules
{
  public class AllCharactersValidator : IRomanNumeralValidator
  {
    public bool ShouldStopOnError { get; }

    public AllCharactersValidator()
    {
      ShouldStopOnError = true;
    }

    public ValidationResult Validate(string romanNumeral)
    {
      foreach (var character in romanNumeral)
      {
        if (!ConstantRomanSymbols.ArabicValuesByRomanSymbols.ContainsKey(character)) return ValidationResult.CreateInvalidValidationResult("Input is invalid - one or more input characters are not a valid Roman numeral");
      }

      return ValidationResult.CreateValidValidationResult();
    }
  }
}