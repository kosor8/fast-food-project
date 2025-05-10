namespace FastFoodMenuAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // **CORS Servisini Ekleme**
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("null", "http://localhost:3000", "http://localhost:8080", "http://localhost:7102") // Frontend portlarýnýzý ve "null" origin'ini ekleyin. Gerekirse daha fazla port ekleyebilirsiniz.
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // **CORS Middleware'ýný Uygulama**
            app.UseCors(); // Default policy'i uygular.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}