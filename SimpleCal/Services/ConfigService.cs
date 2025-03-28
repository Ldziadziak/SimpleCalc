using Microsoft.Extensions.Configuration;

namespace SimpleCal.Services
{
  public class ConfigService
  {
    private readonly IConfiguration _configuration;

    public ConfigService()
    {
      _configuration = new ConfigurationBuilder()
          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .Build();
    }

    public string GetExpressionPattern()
    {
      return _configuration["RegexPatterns:ExpressionPattern"]!;
    }
  }
}
