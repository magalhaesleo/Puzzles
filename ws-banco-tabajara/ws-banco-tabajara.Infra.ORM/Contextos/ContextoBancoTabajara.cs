﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Infra.ORM.Contextos
{
    public class ContextoBancoTabajara : DbContext
    {
        public ContextoBancoTabajara(string nomeBanco) : base(nomeBanco)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public ContextoBancoTabajara() : this("Puzzles_BancoTabajaraBD")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new ContaConfiguracao());
            modelBuilder.Configurations.Add(new MovimentacaoConfiguracao());
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string msg = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    msg = string.Format("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg += string.Format("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(msg);
            }
        }
    }
}
