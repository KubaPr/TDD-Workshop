namespace RomanNumeralsConverter
{
  public class RomanToArabicConverterManager
  {
    private readonly IRomanToArabicConverter _romanToArabicConverter;
    private readonly IRomanNumeralValidationManager _romanNumeralValidationManager;

    public RomanToArabicConverterManager(IRomanToArabicConverter romanToArabicConverter, IRomanNumeralValidationManager romanNumeralValidationManager)
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
