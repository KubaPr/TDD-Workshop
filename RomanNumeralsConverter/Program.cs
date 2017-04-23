using System;

namespace RomanNumeralsConverter
{
  internal class Program
  {
    private static RomanNumeralValidator _validator;
    private static RomanToArabicConverter _romanToArabicConverter;

    private static void Main(string[] args)
    {
      _validator = new RomanNumeralValidator();
      _romanToArabicConverter = new RomanToArabicConverter();

      while (true)
      {
        Console.WriteLine("Write the Roman Numeral to Convert");
        var userInput = Console.ReadLine();

        var validationResults = _validator.Validate(userInput);

        if (validationResults.IsValid)
        {
          var result = _romanToArabicConverter.ConvertToArabic(userInput);
          Console.WriteLine(result.ToString());
        }
        else
        {
          foreach (var result in validationResults.Messages)
          {
            Console.WriteLine(result);
          }
        }
      }
    }
  }
}
