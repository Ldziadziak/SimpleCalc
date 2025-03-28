namespace SimpleCal.Models;
public interface ICounter
{
  int Value { get; }
  ICounter Add(ICounter other);
}