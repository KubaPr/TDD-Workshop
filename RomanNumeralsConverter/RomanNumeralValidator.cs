using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsConverter
{
  public class RomanNumeralValidator : IRomanNumeralValidator
  {
    public ValidationResult Validate(string romanNumeral)
    {
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

      if (results.All(r => r.IsValid)) return ValidationResult.CreateValidValidationResult();

      var aggregatedErrorMessage = results.Aggregate("", (current, res) => current + res.ErrorMessage + Environment.NewLine);

      return ValidationResult.CreateInvalidValidationResult(aggregatedErrorMessage);
    }

    private ValidationResult InputGiven(string romanNumeral)
    {
      if (string.IsNullOrEmpty(romanNumeral))
      {
        return ValidationResult.CreateInvalidValidationResult("Input not given");
      }

      return ValidationResult.CreateValidValidationResult();
    }

    private ValidationResult AllCharsAreValid(string romanNumeral)
    {
      foreach (var character in romanNumeral)
      {
        if (!ConstantRomanSymbols.ArabicValuesByRomanSymbols.ContainsKey(character)) return ValidationResult.CreateInvalidValidationResult("Input is invalid - one or more input characters are not a valid Roman numeral");
      }

      return ValidationResult.CreateValidValidationResult();
    }

    private ValidationResult NotThreeSameNumeralsOtherThanMInARow(string romanNumeral)
    {
      foreach (var character in ConstantRomanSymbols.ArabicValuesByRomanSymbols.Keys)
      {
        var numeralFourTimesInARow = new string(character, 4);
        if (romanNumeral.Contains(numeralFourTimesInARow) && character != 'M')
        {
          return ValidationResult.CreateInvalidValidationResult("Input is invalid - more than three numerals other than M in a row");
        }
      }

      return ValidationResult.CreateValidValidationResult();
    }

    private ValidationResult SmallerValueNotBeforeLargerValue(string romanNumeral)
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

    private ValidationResult VorLorDNotRepeated(string romanNumeral)
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