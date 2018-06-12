using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{
    #region Scripts SQL

    public const string _sqlAdicionar = @"";

    public const string _sqlAtualizar = @"";

    public const string _sqlBuscarPorId = @"

ID = {0}ID";

    public const string _sqlExcluir = @"DELETE FROM TBEMITENTE
                                              WHERE ID = {0}ID";

    public const string _sqlBuscarTodos = @"SELECT
                                                TBEMITENTE.ID[IDEMITENTE],
                                                TBEMITENTE.NOMEFANTASIA[NOME_FANTASIA],
                                                TBEMITENTE.RAZAOSOCIAL[RAZAO_SOCIAL],
                                                TBEMITENTE.CNPJ[CNPJ_EMITENTE],
                                                TBEMITENTE.INSCRICAOESTADUAL[INSCRICAO_ESTADUAL],
                                                TBEMITENTE.INSCRICAOMUNICIPAL[INSCRICAO_MUNICIPAL],
                                                TBEMITENTE.ENDERECOID[ENDERECO_ID],
                                                TBENDERECO.ID[IDENDERECO],
                                                TBENDERECO.LOGRADOURO[LOGRADOURO_ENDERECO],
                                                TBENDERECO.NUMERO[NUMERO_ENDERECO],
                                                TBENDERECO.BAIRRO[BAIRRO_ENDERECO],
                                                TBENDERECO.MUNICIPIO[MUNICIPIO_ENDERECO],
                                                TBENDERECO.ESTADO[ESTADO_ENDERECO],
                                                TBENDERECO.PAIS[PAIS_ENDERECO]
                                                FROM TBEMITENTE
                                                JOIN TBENDERECO ON TBEMITENTE.ENDERECOID = TBENDERECO.ID";

    #endregion Scripts SQL

    public class NotaFiscalRepositorioSql : INotaFiscalRepositorio
    {
        public NotaFiscal Adicionar(NotaFiscal entidade)
        {
            throw new NotImplementedException();
        }

        public NotaFiscal Atualizar(NotaFiscal entidade)
        {
            throw new NotImplementedException();
        }

        public NotaFiscal BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotaFiscal> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(NotaFiscal entidade)
        {
            throw new NotImplementedException();
        }
    }
}
