using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", ([FromQuery]string? name) => new {message = $"Hello {name ?? "world"}"});
app.Run();
