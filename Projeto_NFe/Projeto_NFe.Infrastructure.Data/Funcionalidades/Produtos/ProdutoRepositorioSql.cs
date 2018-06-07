using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos
{
    public class ProdutoRepositorioSql : IProdutoRepositorio
    {
        public const string _sqlAdicionar = @"INSERT INTO TBPRODUTO
                                            (Codigo, Descricao, Valor) 
                                            VALUES 
                                            ({0}Codigo, {0}Descricao, {0}Valor);
                                            SELECT SCOPE_IDENTITY();";

        public const string _sqlBuscarPorId = @"SELECT * FROM TBPRODUTO WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT * FROM TBPRODUTO";

        public const string _sqlAtualizar = @"UPDATE TBPRODUTO SET 
                                            CODIGO={0}CODIGO,
                                            DESCRICAO={0}DESCRICAO,
                                            VALOR={0}VALOR 
                                            WHERE ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBPRODUTO
                                            WHERE ID = {0}ID";

        public Produto Adicionar(Produto produto)
        {
            produto.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioDeProduto(produto));
            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioDeProduto(produto));
            return produto;
        }

        public Produto BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoProduto, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Produto produto)
        {
            throw new NotImplementedException();
        }

        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioDeProduto(Produto produto)
        {
            return new Dictionary<string, object>
            {
                { "ID", produto.Id },
                { "CODIGO", produto.Codigo},
                { "DESCRICAO", produto.Descricao},
                { "VALOR", produto.Valor }
            };

        }

        private static Func<IDataReader, Produto> FormaObjetoProduto = reader =>
            new Produto
            {
                Id = Convert.ToInt64(reader["Id"]),
                Codigo = Convert.ToString(reader["Codigo"]),
                Descricao = Convert.ToString(reader["Descricao"]),
                Valor = Convert.ToDouble(reader["Valor"])
            };
        #endregion
    }
}
