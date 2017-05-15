namespace RomanNumeralsConverter
{
  public class ValidationResult
  {
    public bool IsValid;

    public string ErrorMessage { get; private set; }

    private ValidationResult()
    {
    }

    public static ValidationResult CreateValidValidationResult()
    {
      return new ValidationResult()
      {
        IsValid = true
      };
    }

    public static ValidationResult CreateInvalidValidationResult(string errorMessage)
    {
      return new ValidationResult()
      {
        ErrorMessage = errorMessage,
        IsValid = false
      };
    }
  }
}
