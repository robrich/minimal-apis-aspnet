using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

{
    // TODO: swap with your data access / config read / api call
    var text = File.ReadAllText("interestingConfig.json");
    var json = JsonSerializer.Deserialize<InterestingConfig>(text);
    ArgumentNullException.ThrowIfNull(json);
    builder.Services.AddSingleton<InterestingConfig>(json);
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/", (InterestingConfig config) => config);

app.MapHealthChecks("/health");

app.Map("/error", () => Results.Problem());
app.Map("/{*url}", () => Results.NotFound(new {message="Not Found", status=404}));

app.Run();

public record class InterestingConfig(string thanks, string name, string email, string username, string largePic, string mediumPic, string thumbnailPic);

public partial class Program { }
