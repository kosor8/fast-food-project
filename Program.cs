using FastFoodAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Swagger/OpenAPI Desteği
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // AddOpenApi yerine bu tercih edilir

// Controller ve Hizmet Tanımlamaları
builder.Services.AddControllers();
builder.Services.AddSingleton<OrderQueueService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Geliştirme ortamı için Swagger arayüzünü etkinleştir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirmesi ve yetkilendirme
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // CORS middleware burada çalışır
app.UseAuthorization();

// Controller’ları eşleştir
app.MapControllers();

// (İstersen özel test endpoint’in de kalabilir)
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
