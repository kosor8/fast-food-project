using FastFoodAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Swagger/OpenAPI Desteği
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger'ı kullanmaya devam ediyoruz

// Controller ve Hizmet Tanımlamaları
builder.Services.AddControllers();
builder.Services.AddSingleton<OrderQueueService>(); // OrderQueueService servisini ekliyoruz

// CORS Yapılandırması
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

// HTTPS yönlendirmesi ve CORS middleware'i
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // CORS middleware burada çalışır
app.UseAuthorization();

// Controller’ları eşleştir
app.MapControllers();

app.Run();
