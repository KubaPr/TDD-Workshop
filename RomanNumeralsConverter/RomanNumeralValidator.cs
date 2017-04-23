using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsConverter
{
  public class RomanNumeralValidator : IRomanNumeralValidator
  {
    public ValidationResult Validate(string romanNumeral)
    {
      var result = new ValidationResult();
      var results = new List<ValidationResult>();

      if (!InputGiven(romanNumeral).IsValid)
      {
        return InputGiven(romanNumeral);
      }
      if (!AllCharsAreValid(romanNumeral).IsValid)
      {
        return AllCharsAreValid(romanNumeral);
      }
      if (!NotThreeSameNumeralsOtherThanMInARow(romanNumeral).IsValid)
      {
        results.Add(NotThreeSameNumeralsOtherThanMInARow(romanNumeral));
      }
      if (!SmallerValueNotBeforeLargerValue(romanNumeral).IsValid)
      {
        results.Add(SmallerValueNotBeforeLargerValue(romanNumeral));
      }
      if (!VorLorDNotRepeated(romanNumeral).IsValid)
      {
        results.Add(VorLorDNotRepeated(romanNumeral));
      }

      foreach (var r in results)
      {
        result.Messages.Add(r.Messages.FirstOrDefault());
      }

      return result;
    }

    private ValidationResult InputGiven(string romanNumeral)
    {
      var result = new ValidationResult();

      if (string.IsNullOrEmpty(romanNumeral))
      {
        result.Messages.Add("Input not given");
      }
      return result;
    }

    private ValidationResult AllCharsAreValid(string romanNumeral)
    {
      var result = new ValidationResult();

      foreach (var character in romanNumeral)
      {
        if (!ConstantRomanSymbols.ArabicValuesByRomanSymbols.ContainsKey(character)) result.Messages.Add("Input is invalid - one or more input characters are not a valid Roman numeral");
      }

      return result;
    }

    private ValidationResult NotThreeSameNumeralsOtherThanMInARow(string romanNumeral)
    {
      var result = new ValidationResult();

      foreach (var character in ConstantRomanSymbols.ArabicValuesByRomanSymbols.Keys)
      {
        var numeralFourTimesInARow = new string(character, 4);
        if (romanNumeral.Contains(numeralFourTimesInARow) && character != 'M')
        {
          result.Messages.Add("Input is invalid - more than three numerals other than M in a row");
          break;
        }
      }

      return result;
    }

    private ValidationResult SmallerValueNotBeforeLargerValue(string romanNumeral)
    {
      var result = new ValidationResult();

      if (romanNumeral.Length == 1) return result;

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
              result.Messages.Add("Input is invalid - smaller value to the left and is either V, L or D");
              return result;
            }

            if (currentCharArabicValue < nextCharArabicValue / 10)
            {
              result.Messages.Add("Input is invalid - smaller value to the left and is less then one tenth of the next numeral value found");
              return result;
            }

            currentCharArabicValue = nextCharArabicValue - currentCharArabicValue;
            i++;
          }
        }

        if (currentCharArabicValue > biggestValueSoFar)
        {
          result.Messages.Add("Input is invalid - the value must never increase from one letter to the next unless substracting");
          return result;
        }

        biggestValueSoFar = currentCharArabicValue;
      }
      return result;
    }

    private int GetFirstDigit(int number)
    {
      while (number >= 10)
      {
        number /= 10;
      }
      return number;
    }

    private ValidationResult VorLorDNotRepeated(string romanNumeral)
    {
      var result = new ValidationResult();

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
        result.Messages.Add("Input is invalid - V, L or D repeated more than once");
      };
      return result;
    }
  }
}