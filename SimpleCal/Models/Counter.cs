using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SimpleCalTests")]

namespace SimpleCal.Models;

internal class Counter : ICounter
{
  public int Value { get; }

  public Counter(int value)
  {
    Value = value;
  }

  public ICounter Add(ICounter other)
  {
    return new Counter(Value + other.Value);
  }

  public static Counter operator +(Counter a, Counter b)
  {
    return new Counter(a.Value + b.Value);
  }
}
