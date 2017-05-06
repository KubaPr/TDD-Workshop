namespace RomanNumeralsConverter.ValidationRules
{
  public class VorLorDNotRepeatedValidator : IRomanNumeralValidator
  {
    public ValidationResult Validate(string romanNumeral)
    {
      var vCount = 0;
      var lCount = 0;
      var dCount = 0;

      foreach (var character in romanNumeral)
      {
        switch (character)
        {
          case 'V':
            vCount += 1;
            break;
          case 'L':
            lCount += 1;
            break;
          case 'D':
            dCount += 1;
            break;
        }
      }
      if (vCount > 1 || lCount > 1 || dCount > 1)
      {
        return ValidationResult.CreateInvalidValidationResult("Input is invalid - V, L or D repeated more than once");
      }
      return ValidationResult.CreateValidValidationResult();
    }
  }
}