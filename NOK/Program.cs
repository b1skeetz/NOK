var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/damirk120404@gmail.com", (string x, string y) =>
{
    if (!ulong.TryParse(x, out var a) || a == 0 ||
        !ulong.TryParse(y, out var b) || b == 0)
        return Results.Text("NaN");

    static ulong Gcd(ulong p, ulong q) => q == 0 ? p : Gcd(q, p % q);
    var lcm = a / Gcd(a, b) * b;

    return Results.Text(lcm.ToString());
});

app.Run();

