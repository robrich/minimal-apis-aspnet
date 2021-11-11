namespace Site.APIs;

public class Minimal
{

    public void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);
        app.MapGet("/api/minimal", Get);
        app.MapPost("/api/minimal/{one}/{two}", Post);
        app.MapPut("/api/minimal", Put);
    }

    public MinimalModel Get([FromQuery]string name, IHelloService helloService)
    {
        return new MinimalModel { Id = 3, Message = helloService.Greet(name) };
    }

    public MinimalModel Post([FromRoute]string? one, [FromRoute]int two, [FromBody]MinimalModel data, IHelloService helloService)
    {
        return new MinimalModel {
            Message = helloService.Greet($"{one} and {two}"),
            Data = data
        };
    }

    public IResult Put([FromBody]MinimalModel? data)
    {
        if (data != null) {
            return Results.Ok();
        } else {
            return Results.NotFound();
        }
    }

}
