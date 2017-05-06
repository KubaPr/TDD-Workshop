namespace RomanNumeralsConverter
{
  public class RomanToArabicConverterManager
  {
    private readonly IRomanToArabicConverter _romanToArabicConverter;
    private readonly IRomanNumeralValidator _romanNumeralValidator;

    public RomanToArabicConverterManager(IRomanToArabicConverter romanToArabicConverter, IRomanNumeralValidator romanNumeralValidator)
    {
      _romanToArabicConverter = romanToArabicConverter;
      _romanNumeralValidator = romanNumeralValidator;
    }

    public string TryConvertingRomanToArabic(string userInput)
    {
      var input = userInput.ToUpper();
      var validationResult = _romanNumeralValidator.Validate(input);

      if (!validationResult.IsValid)
      {
        return validationResult.ErrorMessage;
      }

      return _romanToArabicConverter.ConvertToArabic(input).ToString();
    }
  }
}
