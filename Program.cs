var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<PedidoContext>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

app.Run();
