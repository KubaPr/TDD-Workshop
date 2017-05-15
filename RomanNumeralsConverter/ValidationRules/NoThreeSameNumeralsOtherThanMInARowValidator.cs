namespace RomanNumeralsConverter.ValidationRules
{
  public class NoThreeSameNumeralsOtherThanMInARowValidator : IRomanNumeralValidator
  {
    public bool ShouldStopOnError { get; }

    public NoThreeSameNumeralsOtherThanMInARowValidator()
    {
      ShouldStopOnError = false;
    }
    public ValidationResult Validate(string romanNumeral)
    {
      foreach (var character in ConstantRomanSymbols.ArabicValuesByRomanSymbols.Keys)
      {
        var numeralFourTimesInARow = new string(character, 4);
        if (romanNumeral.Contains(numeralFourTimesInARow) && character != 'M')
        {
          return ValidationResult.CreateInvalidValidationResult("Input is invalid - more than three numerals other than M in a row");
        }
      }

      return ValidationResult.CreateValidValidationResult();
    }
  }
}