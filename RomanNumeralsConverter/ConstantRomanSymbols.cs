using System.Collections.Generic;

namespace RomanNumeralsConverter
{
  public class ConstantRomanSymbols
  {
    public readonly Dictionary<char, int> ArabicValuesByRomanSymbols = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };
  }
}