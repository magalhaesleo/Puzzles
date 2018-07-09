﻿using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("TBCLIENTE");
            modelBuilder.Entity<Endereco>().ToTable("TBENDERECO");
        }
    }
}