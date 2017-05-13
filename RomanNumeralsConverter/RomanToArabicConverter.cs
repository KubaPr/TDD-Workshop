namespace RomanNumeralsConverter
{
  //Why I used virtual method here:
  /*Reading trough a couple of articles/stackoverflow threads it turned out that 
  in order to test the ConverterManager class which uses this class as a collaborator I need
  to either have the interface or the method ConvertToArabic should be virtual. 
  I don't expect any other implementations of this class so I used virtual method */

  public class RomanToArabicConverter
  {
    public virtual int ConvertToArabic(string romanNumeral)
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
