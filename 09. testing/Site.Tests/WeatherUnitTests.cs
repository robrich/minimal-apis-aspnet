namespace Site.Tests;

public class WeatherUnitTests
{
    [Fact]
    public void Gets5Forecasts()
    {
        // arrange
        /*
        var logger = new Mock<ILogger<WeatherForecastController>>();
        WeatherForecastController controller = new WeatherForecastController(logger.Object);
        */
        // use AutoMocker https://github.com/moq/Moq.AutoMocker
        var mocker = new AutoMocker();
        WeatherForecastController controller = mocker.CreateInstance<WeatherForecastController>();

        // act
        IEnumerable<WeatherForecast> weatherForecasts = controller.Get();

        // assert
        using var scope = new AssertionScope();
        weatherForecasts.Should().NotBeNull();
        weatherForecasts.Should().HaveCount(5);
    }

}
