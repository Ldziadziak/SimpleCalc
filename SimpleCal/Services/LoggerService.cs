namespace SimpleCal.Services
{
  public class LoggerService : ILogger
  {
    public void LogInput(string input)
    {
      Console.WriteLine($"Input: {input}");
    }

    public void LogResult(int result)
    {
      Console.WriteLine($"Result: {result}");
    }
  }
}
