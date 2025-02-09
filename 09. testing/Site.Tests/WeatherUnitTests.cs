namespace Site.Tests;

public class WeatherUnitTests
{
    [Fact]
    public void Gets5Forecasts()
    {
        /*
        // arrange
        var logger = Substitute.For<ILogger<WeatherForecastController>>();
        WeatherForecastController controller = new WeatherForecastController(logger);
        */
        // use AutoFixture https://www.nuget.org/packages/AutoFixture.AutoNSubstitute
        var ioc = new Fixture().Customize(new AutoNSubstituteCustomization());
        //WeatherForecastController controller = ioc.Create<WeatherForecastController>();
        WeatherForecastController controller = ioc.Build<WeatherForecastController>().OmitAutoProperties().Create();

        // act
        IEnumerable<WeatherForecast> weatherForecasts = controller.Get();

        // assert
        weatherForecasts.ShouldNotBeNull();
        weatherForecasts.Count().ShouldBe(5);
    }

}
