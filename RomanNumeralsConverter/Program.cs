using System;
using System.Reflection;
using Ninject;

namespace RomanNumeralsConverter
{
  public class Program
  {
    private static void Main(string[] args)
    {
      var kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());

      var romanToArabicConverterManager = kernel.Get<RomanToArabicConverterManager>();

      while (true)
      {
        Console.WriteLine("Write the Roman Numeral to Convert");
        var userInput = Console.ReadLine();

        var result = romanToArabicConverterManager.TryConvertingRomanToArabic(userInput);

        Console.WriteLine(result);
      }
    }
  }
}
