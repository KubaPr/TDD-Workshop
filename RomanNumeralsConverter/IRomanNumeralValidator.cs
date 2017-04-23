namespace RomanNumeralsConverter
{
  public interface IRomanNumeralValidator
  {
    ValidationResult Validate(string romanNumeral);
  }
}