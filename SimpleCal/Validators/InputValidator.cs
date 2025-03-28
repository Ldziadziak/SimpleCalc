using SimpleCal.Services;
using System.Text.RegularExpressions;

namespace SimpleCal.Validators
{
  public class InputValidator
  {
    private readonly string _expressionPattern;

    public InputValidator(ConfigService configService)
    {
      _expressionPattern = configService.GetExpressionPattern();
    }

    public bool Validate(string input)
    {
      return Regex.IsMatch(input, _expressionPattern);
    }
  }
}
