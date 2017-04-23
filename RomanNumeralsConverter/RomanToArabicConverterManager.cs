using System;
using System.Linq;

namespace RomanNumeralsConverter
{
  public class RomanToArabicConverterManager : IRomanToArabicConverterManager
  {
    private readonly IRomanToArabicConverter _romanToArabicConverter;
    private readonly IRomanNumeralValidator _romanNumeralValidator;

    public RomanToArabicConverterManager(IRomanToArabicConverter romanToArabicConverter, IRomanNumeralValidator romanNumeralValidator)
    {
      _romanToArabicConverter = romanToArabicConverter;
      _romanNumeralValidator = romanNumeralValidator;
    }

    public string TryConvertingRomanToArabic(string input)
    {
      var validationResult = _romanNumeralValidator.Validate(input);
      var result = "";

      if (validationResult.IsValid)
      {
        var convertToArabic = _romanToArabicConverter.ConvertToArabic(input);
        result = convertToArabic.ToString();
      }
      else
      {
        result = validationResult.Messages.Aggregate(result, (current, message) => current + Environment.NewLine + message);
      }
      return result;
    }
  }
}
