using Microsoft.EntityFrameworkCore;
using BackendChallenge.Models;

namespace BackendChallenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
