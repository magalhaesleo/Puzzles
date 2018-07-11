using projeto_pizzaria.Domain.Funcionalidades.Clientes;
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
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Domain.Funcionalidades.Adicionais;
using projeto_pizzaria.Domain.Funcionalidades.Sabores;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using projeto_pizzaria.Domain.Funcionalidades.ProdutosGenericos;
using projeto_pizzaria.Infra.Data.Funcionalidades.Adicionais;
using projeto_pizzaria.Infra.Data.Funcionalidades.ProdutosGenericos;

namespace projeto_pizzaria.Infra.Data.Contextos
{
    public class PizzariaContexto : DbContext
    {
        public PizzariaContexto() : base("PizzariaBD_Puzzles")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Cliente> Clientes { get; set; }
        
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Produto> ProdutoPedidos { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<ProdutoGenerico> ProdutosGenericos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Entity<Endereco>().ToTable("TBEndereco");
            modelBuilder.Entity<Produto>().ToTable("TBProdutoPedido");
            modelBuilder.Configurations.Add(new PizzaConfiguracao());
            modelBuilder.Configurations.Add(new CalzoneConfiguracao());
            modelBuilder.Configurations.Add(new PedidoConfiguracao());
            modelBuilder.Configurations.Add(new AdicionalConfiguracao());
            modelBuilder.Entity<ProdutoGenerico>().ToTable("TBProduto");
            modelBuilder.Entity<Sabor>().ToTable("TBSabor");
            modelBuilder.Configurations.Add(new ProdutoGenericoConfiguracao());
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
