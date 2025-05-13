namespace FastFoodMenuAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Hizmetleri ekleyin
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // CORS ayarlarýný ekleyin
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    // Frontend URL'sini belirtin, burada frontend'iniz localhost:3000'de çalýþýyorsa:
                    builder.WithOrigins("https://localhost:7102" ,"null")  // Buraya frontend'inizin URL'sini yazýn
                           .AllowAnyHeader()  // Herhangi bir baþlýða izin verir
                           .AllowAnyMethod();  // Herhangi bir metoda izin verir
                });
            });

            var app = builder.Build();

            // HTTP istek hattýný yapýlandýrýn
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // CORS middleware'ini etkinleþtirin
            app.UseCors();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
