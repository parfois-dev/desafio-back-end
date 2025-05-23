using Microsoft.EntityFrameworkCore;
using PedidoApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PedidoContext>(options =>
    options.UseInMemoryDatabase("PedidosDb"));

var app = builder.Build();

app.MapGet("/", () => "Pedido API");

app.Run();
