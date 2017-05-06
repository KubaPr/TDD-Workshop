using System.Linq;

namespace RomanNumeralsConverter.ValidationRules
{
  public class SmallerValueBeforeLargerValueValidator : IRomanNumeralValidator
  {
    public ValidationResult Validate(string romanNumeral)
    {
      if (romanNumeral.Length == 1) return ValidationResult.CreateValidValidationResult();

      var biggestValueSoFar = ConstantRomanSymbols.ArabicValuesByRomanSymbols.Values.Max();

      for (var i = 0; i < romanNumeral.Length; i++)
      {
        var currentCharArabicValue = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i]];
        var nextCharArabicValue = 0;
        bool endOfNumeral = i == romanNumeral.Length - 1;

        if (!endOfNumeral) nextCharArabicValue = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i + 1]];

        if (!endOfNumeral)
        {
          if (currentCharArabicValue < nextCharArabicValue)
          {
            if (GetFirstDigit(currentCharArabicValue) % 5 == 0)
            {
              return ValidationResult.CreateInvalidValidationResult("Input is invalid - smaller value to the left and is either V, L or D");
            }

            if (currentCharArabicValue < nextCharArabicValue / 10)
            {
              return ValidationResult.CreateInvalidValidationResult("Input is invalid - smaller value to the left and is less then one tenth of the next numeral value found");
            }

            currentCharArabicValue = nextCharArabicValue - currentCharArabicValue;
            i++;
          }
        }

        if (currentCharArabicValue > biggestValueSoFar)
        {
          return ValidationResult.CreateInvalidValidationResult("Input is invalid - the value must never increase from one letter to the next unless substracting");
        }

        biggestValueSoFar = currentCharArabicValue;
      }
      return ValidationResult.CreateValidValidationResult();
    }

    private int GetFirstDigit(int number)
    {
      while (number >= 10)
      {
        number /= 10;
      }
      return number;
    }
  }
}