using Microsoft.AspNetCore.Mvc;

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

app.MapGet("/damirk120404_gmail_com", async ctx =>
{
    var q = ctx.Request.Query;
 
    if (!ulong.TryParse(q["x"], out var a) || a == 0 ||
        !ulong.TryParse(q["y"], out var b) || b == 0)
    {
        ctx.Response.ContentType = "text/plain";
        await ctx.Response.WriteAsync("NaN");
        return;
    }
 
    static ulong Gcd(ulong p, ulong q) => q == 0 ? p : Gcd(q, p % q);
 
    var lcm = a / Gcd(a, b) * b;
 
    ctx.Response.ContentType = "text/plain";
    await ctx.Response.WriteAsync(lcm.ToString());
});

app.Run();

