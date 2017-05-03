namespace RomanNumeralsConverter
{
  public class ValidationResult
  {
    public bool IsValid;

    public string ErrorMessage { get; private set; }

    private ValidationResult()
    {
      IsValid = true;
    }

    private ValidationResult(string errorMessage)
    {
      ErrorMessage = errorMessage;
      IsValid = false;
    }

    public static ValidationResult CreateValidValidationResult()
    {
      return new ValidationResult();
    }

    public static ValidationResult CreateInvalidValidationResult(string errorMessage)
    {
      return new ValidationResult(errorMessage);
    }
  }
}
