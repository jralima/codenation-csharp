﻿using AceleraDev.CrossCutting.Constants;
using AceleraDev.CrossCutting.Utils;
using AceleraDev.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AceleraDev.Data.Context
{
    public class AceleraDevContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public AceleraDevContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null) property.SetMaxLength(255);
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            {
                if (property.GetColumnType() == null) property.SetColumnType("decimal(18, 4)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AceleraDevContext).Assembly);

            //Incluíndo no momento de criar a tabela (como se fosse um script "base")
            //modelBuilder.Entity<Cliente>().HasData(new Cliente { Nome = "Lacerda"});
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Nome = "Administrador", Email = "admin@mail.com", Senha = "1234".ToHashMD5(), Perfil = Constants.PERFIL_ADMIN });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { Nome = "Vendedor", Email = "vendedor@mail.com", Senha = "1234".ToHashMD5(), Perfil = Constants.PERFIL_VENDEDOR });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Ativando o Lazy Loading
            optionsBuilder.UseLazyLoadingProxies();
        }

        internal string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
