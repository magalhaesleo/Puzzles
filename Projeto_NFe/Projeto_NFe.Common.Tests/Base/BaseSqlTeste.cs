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
        private const string ADICIONAR_REGISTRO_TABELA_ENDERECO = "INSERT INTO TBENDERECO (Logradouro, Numero, Bairro, Municipio, Estado, Pais) VALUES ('Logradouro', 1, 'Bairro', 'Municipio', 'Estado', 'Pais')";
        private const string EXCLUIR_REGISTRO_TABELA_ENDERECO = "DELETE FROM [dbo].[TBENDERECO] DBCC CHECKIDENT('[dbo].[TBENDERECO]', RESEED, 0)";

        public static void InicializarBancoDeDados()
        {
            //Excluindo
            Db.Atualizar(EXCLUIR_REGISTRO_TABELA_ENDERECO);

            //Adicionando
            Db.Atualizar(ADICIONAR_REGISTRO_TABELA_ENDERECO);
        }


    }
}
