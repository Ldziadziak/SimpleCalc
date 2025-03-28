using SimpleCal.Models;

namespace SimpleCal.Calculators
{
  public class Calculator
  {
    public static ICounter PerformOperation(ICounter left, ICounter right, string operation)
    {
      switch (operation)
      {
        case "+":
          return left.Add(right);
        default:
          throw new InvalidOperationException("Unsupported operator.");
      }
    }
  }
}
