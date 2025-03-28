using Microsoft.Extensions.DependencyInjection;
using SimpleCal.Calculators;
using SimpleCal.Models;
using SimpleCal.Services;
using SimpleCal.Validators;

namespace SimpleCal
{
  internal static class Program
  {
    static void Main(string[] args)
    {
      var serviceProvider = new ServiceCollection()
          .AddSingleton<ILogger, LoggerService>()
          .AddSingleton<ConfigService>()
          .AddSingleton<InputValidator>()
          .BuildServiceProvider();

      var logger = serviceProvider.GetRequiredService<ILogger>();
      var validator = serviceProvider.GetRequiredService<InputValidator>();

      if (args.Length != 1)
      {
        Console.WriteLine("Enter an expression in the format: number operator number, e.g., \"1 + 12\"");
        return;
      }

      string input = args[0];

      logger.LogInput(input);

      if (validator.Validate(input))
      {
        string[] parts = input.Split(' ');

        if (parts.Length != 3)
        {
          Console.WriteLine("Invalid format. Use the format: number operator number");
          return;
        }

        if (!int.TryParse(parts[0], out int left) || !int.TryParse(parts[2], out int right))
        {
          Console.WriteLine("Error: Invalid numbers.");
          return;
        }

        ICounter a = new Counter(left);
        ICounter b = new Counter(right);

        try
        {
          ICounter result = Calculator.PerformOperation(a, b, parts[1]);
          logger.LogResult(result.Value);
        }
        catch (InvalidOperationException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
      else
      {
        Console.WriteLine("Invalid input format. Please enter a valid expression.");
      }
    }
  }
}
