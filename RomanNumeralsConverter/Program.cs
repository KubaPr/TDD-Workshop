using System;

namespace RomanNumeralsConverter
{
  internal class Program
  {
    private static RomanNumeralValidator _validator;
    private static Converter _converter;

    private static void Main(string[] args)
    {
      _validator = new RomanNumeralValidator();
      _converter = new Converter();

      while (true)
      {
        Console.WriteLine("Write the Roman Numeral to Convert");
        var userInput = Console.ReadLine();

        var validationResults = _validator.Validate(userInput);

        if (validationResults.IsValid)
        {
          var result = _converter.ConvertToArabic(userInput);
          Console.WriteLine(result.ToString());
        }

        if (!validationResults.IsValid)
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
