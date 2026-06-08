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
 
app.MapGet("/app/damirk120404_gmail_com", async ctx =>
{
    var q = ctx.Request.Query;
 
    string result;
 
    if (!ulong.TryParse(q["x"], out var a) || a == 0 ||
        !ulong.TryParse(q["y"], out var b) || b == 0)
    {
        result = "NaN";
    }
    else
    {
        static ulong Gcd(ulong p, ulong q) => q == 0 ? p : Gcd(q, p % q);
        result = (a / Gcd(a, b) * b).ToString();
    }
 
    var bytes = System.Text.Encoding.UTF8.GetBytes(result);
    ctx.Response.ContentType = "text/plain";
    ctx.Response.ContentLength = bytes.Length;
    await ctx.Response.Body.WriteAsync(bytes);
});
 
app.Run();
