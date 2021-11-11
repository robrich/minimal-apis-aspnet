namespace Site.Tests;

public class WeatherIntegrationTests
{
    [Fact]
    public async Task Gets5Forecasts()
    {
        // arrange
        await using var application = new SiteApp();
        using var client = application.CreateClient();

        // act
        using var res = await client.GetAsync("/api/WeatherForecast");
        var body = await res.Content.ReadAsStringAsync();
        List<WeatherForecast>? weatherForecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(body);

        // assert
        using (new AssertionScope())
        {
            weatherForecasts.Should().NotBeNull();
            weatherForecasts.Should().HaveCount(5);
        }
    }

}
