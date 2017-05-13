using Ninject.Modules;
using RomanNumeralsConverter.ValidationRules;

namespace RomanNumeralsConverter
{
  public class Bindings : NinjectModule
  {
    public override void Load()
    {
      Bind<IRomanNumeralValidator>().To<AllCharactersValidator>();
      Bind<IRomanNumeralValidator>().To<InputGivenValidator>();
      Bind<IRomanNumeralValidator>().To<NoThreeSameNumeralsOtherThanMInARowValidator>();
      Bind<IRomanNumeralValidator>().To<SmallerValueBeforeLargerValueValidator>();
      Bind<IRomanNumeralValidator>().To<VorLorDNotRepeatedValidator>();
    }
  }
}
