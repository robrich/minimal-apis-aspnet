var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Site v1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.MapGet("/api/minimal", ([FromQuery]string? name) => new {message = $"Hello {name ?? "world"}"});
app.MapPost("/api/minimal/{one}/{two}", (string? one, int two, [FromBody]object data) =>
    new {message = $"Hello {one} and {two}", data});
app.MapPut("/api/minimal", ([FromBody]object data) => {
    if (data != null) {
        return Results.Ok();
    } else {
        return Results.NotFound();
    }
});

app.Run();
