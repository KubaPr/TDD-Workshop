using Ninject.Modules;

namespace RomanNumeralsConverter
{
  public class Bindings : NinjectModule
  {
    public override void Load()
    {
      Bind<IRomanToArabicConverterManager>().To<RomanToArabicConverterManager>();
      Bind<IRomanToArabicConverter>().To<RomanToArabicConverter>();
      Bind<IRomanNumeralValidator>().To<RomanNumeralValidator>();
    }
  }
}
