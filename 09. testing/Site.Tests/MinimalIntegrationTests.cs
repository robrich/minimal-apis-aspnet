namespace Site.Tests;

public class MinimalIntegrationTests
{
    private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task Get_SaysHello()
    {
        // arrange
        await using var application = new SiteApp();
        using HttpClient client = application.CreateClient();

        // act
        using var res = await client.GetAsync("/api/minimal?name=test");
        var body = await res.Content.ReadAsStringAsync();
        MinimalModel? model = JsonSerializer.Deserialize<MinimalModel>(body, jsonOptions);

        // assert
        model.ShouldNotBeNull();
        ArgumentNullException.ThrowIfNull(model);
        model.Id.ShouldBe(3);
        model.Message.ShouldBe("Hello test");
    }

    [Fact]
    public async Task Post_SaysHello()
    {
        // arrange
        MinimalModel expected = new MinimalModel
        {
            Id = 5,
            Message = "Posted content"
        };

        await using var application = new SiteApp();
        using var client = application.CreateClient();

        // act
        var reqBody = new StringContent(JsonSerializer.Serialize(expected), Encoding.UTF8, "application/json");
        using var res = await client.PostAsync("/api/minimal/foo/5", reqBody);
        var body = await res.Content.ReadAsStringAsync();
        MinimalModel? model = JsonSerializer.Deserialize<MinimalModel>(body, jsonOptions);

        // assert
        model.ShouldNotBeNull();
        ArgumentNullException.ThrowIfNull(model);
        model.Message.ShouldBe("Hello foo and 5");
        model.Data.ShouldBeEquivalentTo(expected);
    }

}
