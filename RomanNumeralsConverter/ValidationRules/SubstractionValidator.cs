using System.Linq;

namespace RomanNumeralsConverter.ValidationRules
{
  public class SubstractionValidator : IRomanNumeralValidator
  {
    public bool ShouldStopOnError { get; }

    public SubstractionValidator()
    {
      ShouldStopOnError = false;
    }

    public ValidationResult Validate(string romanNumeral)
    {
      var biggestValueSoFar = ConstantRomanSymbols.ArabicValuesByRomanSymbols.Values.Max();

      for (var i = 0; i < romanNumeral.Length; i++)
      {
        if (EndOfNumeral(romanNumeral, i)) continue;

        var currentCharArabicValue = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i]];
        var nextCharArabicValue = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i + 1]];

        if (currentCharArabicValue < nextCharArabicValue)
        {
          if (romanNumeral[i] == 'V' || romanNumeral[i] == 'L' || romanNumeral[i] == 'D')
          {
            return
              ValidationResult.CreateInvalidValidationResult("Input is invalid - substracted value is either V, L or D");
          }

          if (currentCharArabicValue < nextCharArabicValue * 0.1)
          {
            return
              ValidationResult.CreateInvalidValidationResult(
                "Input is invalid - subtrahend is less then one tenth of the minuend");
          }

          var substractionResultValue = nextCharArabicValue - currentCharArabicValue;
          i++;

          if (substractionResultValue > biggestValueSoFar ||
              ValidateAdditionToSubstracted(substractionResultValue, i, romanNumeral))
          {
            return
              ValidationResult.CreateInvalidValidationResult(
                "Input is invalid - the value must never increase from one letter to the next unless substracting");
          }
        }
        else
        {
          biggestValueSoFar = currentCharArabicValue;
        }
      }
      return ValidationResult.CreateValidValidationResult();
    }

    private bool ValidateAdditionToSubstracted(int substractionResult, int i, string romanNumeral)
    {
      if (EndOfNumeral(romanNumeral, i)) return false;
      var firstDigit = GetFirstDigit(substractionResult);
      var addedCharArabicValue = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i + 1]];

      return 
        firstDigit == 4 && addedCharArabicValue >= 0.25 * substractionResult || 
        firstDigit == 9 && addedCharArabicValue >= 0.1 * substractionResult;
    }

    private static bool EndOfNumeral(string romanNumeral, int i)
    {
      return i == romanNumeral.Length - 1;
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