using SimpleCal.Models;
namespace SimpleCalTests;
public class CounterTests
{
  [Fact]
  public void AddingTwoCounters_ShouldReturnCorrectSum()
  {
    // Arrange
    ICounter counter1 = new Counter(5);
    ICounter counter2 = new Counter(10);

    // Act
    ICounter result = counter1.Add(counter2);

    // Assert
    Assert.Equal(15, result.Value);
  }

  [Fact]
  public void Counter_ShouldStoreValueCorrectly()
  {
    // Arrange
    var counter = new Counter(7);

    // Assert
    Assert.Equal(7, counter.Value);
  }
}
