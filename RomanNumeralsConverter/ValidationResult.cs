using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralsConverter
{
  public class ValidationResult
  {
    public bool IsValid => !Messages.Any();

    public List<string> Messages { get; set; }

    public ValidationResult()
    {
      Messages = new List<string>();
    }
  }
}
