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
                                                                    "VALUES ('Nome ou Razao Social', '111.444.777-35', 'CNPJ', '319.402.517', 2)";

        #endregion
        public static void InicializarBancoDeDados()
        {
            //Excluindo
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_DESTINATARIO);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_EMITENTE);
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_ENDERECO);           

            //Adicionando
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_EMITENTE);
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_DESTINATARIO);
        }


    }
}
