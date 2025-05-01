using Web.Services;

var builder = WebApplication.CreateBuilder(args);
.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var orderQueue = new OrderQueue();
orderQueue.LoadOrders(); 

builder.Services.AddSingleton(orderQueue);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
