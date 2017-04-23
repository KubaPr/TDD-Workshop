namespace RomanNumeralsConverter
{
  public class RomanToArabicConverter : IRomanToArabicConverter
  {
    public int ConvertToArabic(string romanNumeral)
    {
      var total = 0;

      for (var i = 0; i < romanNumeral.Length; i++)
      {
        var charConverted = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i]];
        var nextCharConverted = 0;

        if (i < romanNumeral.Length - 1)
        {
          nextCharConverted = ConstantRomanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i + 1]];
        }

        if (charConverted >= nextCharConverted)
        {
          total += charConverted;
        }
        else
        {
          total -= charConverted;
        }
      }
      return total;
    }
  }
}
