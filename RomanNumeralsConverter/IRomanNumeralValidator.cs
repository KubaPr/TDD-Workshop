namespace RomanNumeralsConverter
{
  public interface IRomanNumeralValidator
  {
    bool ShouldStopOnError { get; }

    ValidationResult Validate(string input);
  }
}