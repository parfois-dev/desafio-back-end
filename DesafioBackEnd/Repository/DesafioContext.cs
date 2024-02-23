using Microsoft.EntityFrameworkCore;
using Parfois.DesafioBackEnd.Models;
using System;
using System.Reflection.Metadata;

namespace Parfois.DesafioBackEnd.Repository
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .HasKey(pedido => pedido.Id);
            
            modelBuilder.Entity<Pedido>()
                .Property(pedido => pedido.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pedido>()
                .Property(pedido => pedido.Codigo)
                .IsRequired();

            modelBuilder.Entity<Pedido>()
                .HasMany(pedido => pedido.Itens);

            modelBuilder.Entity<Item>()
                .HasKey(item => item.Id);

            modelBuilder.Entity<Item>()
                .Property(item => item.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Item> Itens { get; set; }
    }
}
