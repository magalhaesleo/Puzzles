using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.ProdutoNotasFiscais
{
    public class ProdutoNotaFiscalRepositorioSql : IProdutoNotaFiscalRepositorio
    {
        #region Scripts SQL

        public const string _sqlAdicionar = @"INSERT INTO TBPRODUTONOTAFISCAL
                                            (PRODUTOID,NOTAFISCALID,QUANTIDADE) 
                                            VALUES 
                                            ({0}PRODUTOID,{0}NOTAFISCALID,{0}QUANTIDADE);SELECT SCOPE_IDENTITY();";

        public const string _sqlAtualizar = @"UPDATE TBPRODUTONOTAFISCAL SET 
                                            PRODUTOID={0}PRODUTOID,
                                            NOTAFISCALID={0}NOTAFISCALID,
                                            QUANTIDADE={0}QUANTIDADE
                                            WHERE ID = {0}ID";

        public const string _sqlBuscarPorId = @"SELECT
                                                TBPRODUTONOTAFISCAL.Id[ID],
                                                TBPRODUTONOTAFISCAL.NotaFiscalId[NOTAFISCALID],
                                                TBPRODUTONOTAFISCAL.ProdutoId[PRODUTOID],
                                                TBPRODUTONOTAFISCAL.Quantidade[QUANTIDADE],
                                                TBPRODUTO.CODIGO[CODIGO_PRODUTO],
                                                TBPRODUTO.DESCRICAO[DESCRICAO_PRODUTO],
                                                TBPRODUTO.VALOR[VALOR_PRODUTO]
                                                FROM TBPRODUTONOTAFISCAL
                                                JOIN TBPRODUTO ON TBPRODUTO.ID = TBPRODUTONOTAFISCAL.PRODUTOID
                                                WHERE TBPRODUTONOTAFISCAL.ID = {0}ID";

        public const string _sqlExcluir = @"DELETE FROM TBPRODUTONOTAFISCAL
                                            WHERE ID = {0}ID";

        public const string _sqlBuscarTodos = @"SELECT
                                                TBPRODUTONOTAFISCAL.Id[ID],
                                                TBPRODUTONOTAFISCAL.NotaFiscalId[NOTAFISCALID],
                                                TBPRODUTONOTAFISCAL.ProdutoId[PRODUTOID],
                                                TBPRODUTONOTAFISCAL.Quantidade[QUANTIDADE],
                                                TBPRODUTO.CODIGO[CODIGO_PRODUTO],
                                                TBPRODUTO.DESCRICAO[DESCRICAO_PRODUTO],
                                                TBPRODUTO.VALOR[VALOR_PRODUTO]
                                                FROM TBPRODUTONOTAFISCAL
                                                JOIN TBPRODUTO ON TBPRODUTO.ID = TBPRODUTONOTAFISCAL.PRODUTOID";

        public const string _sqlBuscarListaPorIdNotaFiscal = @"SELECT
                                                TBPRODUTONOTAFISCAL.Id[ID],
                                                TBPRODUTONOTAFISCAL.NotaFiscalId[NOTAFISCALID],
                                                TBPRODUTONOTAFISCAL.ProdutoId[PRODUTOID],
                                                TBPRODUTONOTAFISCAL.Quantidade[QUANTIDADE],
                                                TBPRODUTO.CODIGO[CODIGO_PRODUTO],
                                                TBPRODUTO.DESCRICAO[DESCRICAO_PRODUTO],
                                                TBPRODUTO.VALOR[VALOR_PRODUTO]
                                                FROM TBPRODUTONOTAFISCAL
                                                JOIN TBPRODUTO ON TBPRODUTO.ID = TBPRODUTONOTAFISCAL.PRODUTOID
                                                WHERE NOTAFISCALID = {0}NOTAFISCALID";
        
        #endregion Scripts SQL

        public ProdutoNotaFiscal Adicionar(ProdutoNotaFiscal produtoNotaFiscal)
        {
            produtoNotaFiscal.Id = Db.Adicionar(_sqlAdicionar, ObterDicionarioProdutoNotaFiscal(produtoNotaFiscal));
            return produtoNotaFiscal;
        }

        public ProdutoNotaFiscal Atualizar(ProdutoNotaFiscal produtoNotaFiscal)
        {
            Db.Atualizar(_sqlAtualizar, ObterDicionarioProdutoNotaFiscal(produtoNotaFiscal));
            return produtoNotaFiscal;
        }

        public ProdutoNotaFiscal BuscarPorId(long Id)
        {
            return Db.BuscarPorId(_sqlBuscarPorId, FormaObjetoProdutoNotaFiscal, new Dictionary<string, object> { { "ID", Id } });
        }

        public IEnumerable<ProdutoNotaFiscal> BuscarTodos()
        {
            return Db.BuscarTodos(_sqlBuscarTodos, FormaObjetoProdutoNotaFiscal);
        }

        public void Excluir(ProdutoNotaFiscal produtoNotaFiscal)
        {
            Db.Excluir(_sqlExcluir, new Dictionary<string, object> { { "ID", produtoNotaFiscal.Id } });

        }

        public IEnumerable<ProdutoNotaFiscal> BuscarListaPorId(long id)
        {
            return Db.BuscarListaPorId(_sqlBuscarListaPorIdNotaFiscal, FormaObjetoProdutoNotaFiscal, new Dictionary<string, object> { { "NOTAFISCALID", id } });
        }


        #region Montar e Ler Objetos
        private Dictionary<string, object> ObterDicionarioProdutoNotaFiscal(ProdutoNotaFiscal produtoNotaFiscal)
        {
            return new Dictionary<string, object>
            {
                { "ID", produtoNotaFiscal.Id },
                { "NOTAFISCALID", produtoNotaFiscal.NotaFiscal.Id},
                { "PRODUTOID", produtoNotaFiscal.Produto.Id},
                { "QUANTIDADE", produtoNotaFiscal.Quantidade }
            };
        }

        private static Func<IDataReader, ProdutoNotaFiscal> FormaObjetoProdutoNotaFiscal = reader =>
            new ProdutoNotaFiscal
            {
                Id = Convert.ToInt64(reader["Id"]),
                Quantidade = Convert.ToInt32(reader["QUANTIDADE"]),

                NotaFiscal = new NotaFiscal
                {
                    Id = Convert.ToInt64(reader["NOTAFISCALID"])
                },

                Produto = new Produto
                {
                    Id = Convert.ToInt64(reader["PRODUTOID"]),
                    Codigo = Convert.ToString(reader["CODIGO_PRODUTO"]),
                    Descricao = Convert.ToString(reader["DESCRICAO_PRODUTO"]),
                    Valor = Convert.ToDouble(reader["VALOR_PRODUTO"])
                }
            };

        #endregion
    }
}
