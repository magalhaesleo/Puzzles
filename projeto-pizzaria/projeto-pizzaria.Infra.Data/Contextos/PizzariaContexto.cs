﻿using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Pedidos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Produtos.Calzones;
using projeto_pizzaria.Infra.Data.Funcionalidades.Clientes;
using projeto_pizzaria.Infra.Data.Funcionalidades.Produtos.Pizzas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos;

namespace projeto_pizzaria.Infra.Data.Contextos
{
    public class PizzariaContexto : DbContext
    {
        public PizzariaContexto() : base("PizzariaBD")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Entity<Endereco>().ToTable("TBENDERECO");
            //modelBuilder.Configurations.Add(new PizzaConfiguracao());
            //modelBuilder.Configurations.Add(new CalzoneConfiguracao());
            //modelBuilder.Configurations.Add(new PedidoConfiguracao());
        }
    }
}
