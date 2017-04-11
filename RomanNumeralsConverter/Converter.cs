namespace RomanNumeralsConverter
{
  public class Converter
  {
    private readonly ConstantRomanSymbols _romanSymbols;

    public Converter()
    {
      _romanSymbols = new ConstantRomanSymbols();
    }

    public int ConvertToArabic(string romanNumeral)
    {
      var total = 0;

      for (var i = 0; i < romanNumeral.Length; i++)
      {
        var charConverted = _romanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i]];
        var nextCharConverted = 0;

        if (i < romanNumeral.Length - 1)
        {
          nextCharConverted = _romanSymbols.ArabicValuesByRomanSymbols[romanNumeral[i + 1]];
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
