namespace RomanNumeralsConverter
{
  public class RomanToArabicConverterManager
  {
    private readonly RomanToArabicConverter _romanToArabicConverter;
    private readonly RomanNumeralValidationManager _romanNumeralValidationManager;

    public RomanToArabicConverterManager(RomanToArabicConverter romanToArabicConverter, RomanNumeralValidationManager romanNumeralValidationManager)
    {
      _romanToArabicConverter = romanToArabicConverter;
      _romanNumeralValidationManager = romanNumeralValidationManager;
    }

    public string TryConvertingRomanToArabic(string userInput)
    {
      var input = userInput.ToUpper();
      var validationResult = _romanNumeralValidationManager.Validate(input);

      if (!validationResult.IsValid)
      {
        return validationResult.ErrorMessage;
      }

      return _romanToArabicConverter.ConvertToArabic(input).ToString();
    }
  }
}
