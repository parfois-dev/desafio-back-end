using Microsoft.EntityFrameworkCore;
using PedidoApi.Models;

namespace PedidoApi.Data
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
