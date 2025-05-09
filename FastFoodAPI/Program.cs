
using FastFoodAPI.DataStructures;
using FastFoodAPI.Services;

namespace FastFoodAPI
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

            builder.Services.AddSingleton<UrunHizmeti>();
            builder.Services.AddSingleton<SepetHizmeti>();
            builder.Services.AddSingleton<SiparisHizmeti>();
            builder.Services.AddSingleton<SiparisIsleyici>();
            builder.Services.AddSingleton<SiparisKuyrugu>();
            builder.Services.AddSingleton<SiparisDurumSozluk>();
            builder.Services.AddSingleton<GeriAlYigini>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
