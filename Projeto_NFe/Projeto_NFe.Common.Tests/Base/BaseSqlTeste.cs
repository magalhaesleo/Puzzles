using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
{
    public static partial class BaseSqlTeste
    {
        #region Scripts SQL
        private const string EXCLUIR_REGISTRO_TABELA_ENDERECO = "DELETE FROM [dbo].[TBENDERECO]; DBCC CHECKIDENT('[dbo].[TBENDERECO]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_ENDERECO = "INSERT INTO TBENDERECO (Logradouro, Numero, Bairro, Municipio, Estado, Pais) VALUES ('Logradouro', 1, 'Bairro', 'Município', 'Estado', 'País')";

        private const string EXCLUIR_REGISTRO_TABELA_EMITENTE = "DELETE FROM [dbo].[TBEMITENTE]; DBCC CHECKIDENT('[dbo].[TBEMITENTE]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_EMITENTE = @"INSERT INTO TBEMITENTE (NOMEFANTASIA, RAZAOSOCIAL,
                                                        CNPJ, INSCRICAOESTADUAL, INSCRICAOMUNICIPAL, ENDERECOID)
                                                        VALUES ('67768776876', '76887867876', '99.327.235/0001-50',
                                                                '296.062.760.060', '0129195449791', 1)";

        private const string EXCLUIR_REGISTRO_TABELA_DESTINATARIO = "DELETE FROM [dbo].[TBDESTINATARIO]; DBCC CHECKIDENT('[dbo].[TBDESTINATARIO]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_DESTINATARIO = "INSERT INTO TBDESTINATARIO (Nome, Documento, TipoDeDocumento, InscricaoEstadual, EnderecoId)" +
                                                                    "VALUES ('Nome ou Razao Social', '99.327.235/0001-50', 'CNPJ', '319.402.517', 2)";

        private const string EXCLUIR_REGISTRO_TABELA_TRANSPORTADOR = "DELETE FROM [dbo].[TBTRANSPORTADOR]; DBCC CHECKIDENT('[dbo].[TBTRANSPORTADOR]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_TRANSPORTADOR = "INSERT INTO TBTRANSPORTADOR (Nome, Documento, TipoDocumento, InscricaoEstadual, EnderecoId, ResponsabilidadeFrete)" +
                                                                    "VALUES ('Nome ou Razao Social', '99.327.235/0001-50', 'CNPJ', '319.402.517', 2, 1)";

        private const string ADICIONAR_REGISTRO_TABELA_DESTINATARIO_COMCPF = "INSERT INTO TBDESTINATARIO (Nome, Documento, TipoDeDocumento, InscricaoEstadual, EnderecoId)" +
                                                                    "VALUES ('Nome ou Razao Social', '111.444.777-35', 'CPF', '319.402.517', 2)";

        private const string ADICIONAR_REGISTRO_TABELA_TRANSPORTADOR_COMCPF = "INSERT INTO TBTRANSPORTADOR (Nome, Documento, TipoDocumento, InscricaoEstadual, EnderecoId, ResponsabilidadeFrete)" +
                                                                    "VALUES ('Nome ou Razao Social', '111.444.777-35', 'CPF', '319.402.517', 2, 1)";

        private const string EXCLUIR_REGISTRO_TABELA_PRODUTO = "DELETE FROM [dbo].[TBPRODUTO]; DBCC CHECKIDENT('[dbo].[TBPRODUTO]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_PRODUTO = "INSERT INTO TBPRODUTO (CODIGO, DESCRICAO, VALOR) VALUES ('CODIGO', 'DESCRICAO', 100)";

        private const string EXCLUIR_REGISTRO_TABELA_PRODUTONOTAFISCAL = "DELETE FROM [dbo].[TBPRODUTONOTAFISCAL]; DBCC CHECKIDENT('[dbo].[TBPRODUTONOTAFISCAL]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_PRODUTONOTAFISCAL = "INSERT INTO TBPRODUTONOTAFISCAL (ProdutoId, NotaFiscalId, Quantidade) VALUES (1, 1, 100)";

        private const string EXCLUIR_REGISTRO_TABELA_NOTAFISCAL = "DELETE FROM [dbo].[TBNOTAFISCAL]; DBCC CHECKIDENT('[dbo].[TBNOTAFISCAL]', RESEED, 0)";
        private const string ADICIONAR_REGISTRO_TABELA_NOTAFISCAL = "INSERT INTO TBNOTAFISCAL (EmitenteId, DestinatarioId, TransportadorId, NaturezaDaOperacao, DataEntrada) VALUES (1, 1, 1, 'NaturezaDaOperacao', '07-05-2018 00:00:00')";



        #endregion
        public static void InicializarBancoDeDados()
        {
            //Excluindo
            
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_PRODUTONOTAFISCAL);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_PRODUTO);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_NOTAFISCAL);
           
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_DESTINATARIO);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_EMITENTE);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_TRANSPORTADOR);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_ENDERECO);            

            //Adicionando
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_EMITENTE);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_DESTINATARIO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_TRANSPORTADOR);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_PRODUTO);

        }

        public static void InicializarBancoDeDadosPrepararProduto()
        {
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_PRODUTONOTAFISCAL);

            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_PRODUTO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_PRODUTO);
        }

        public static void InicializarBancoDeDadosPrepararNotaFiscal()
        {
            InicializarBancoDeDados();

            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_NOTAFISCAL);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_NOTAFISCAL);

            InicializarBancoDeDadosPrepararTesteRepositorioProdutoNotaFiscal();
        }

        //Deve ser chamado após a criação de uma nota fiscal
        public static void InicializarBancoDeDadosPrepararTesteRepositorioProdutoNotaFiscal()
        {
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_PRODUTONOTAFISCAL);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_PRODUTONOTAFISCAL);
        }

        public static void InicializarBancoDeDadosPrepararEntidadesComCPF()
        {
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_DESTINATARIO_COMCPF);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_TRANSPORTADOR_COMCPF);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_EMITENTE);
        }

    }
}
