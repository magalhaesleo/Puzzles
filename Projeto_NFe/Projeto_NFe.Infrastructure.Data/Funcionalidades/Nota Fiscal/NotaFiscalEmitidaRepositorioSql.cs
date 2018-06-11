using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalEmitidaRepositorioSql : INotaFiscalEmitidaRepositorio
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

        public int ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso)
        {
            throw new NotImplementedException();
        }

        public void Excluir(NotaFiscal entidade)
        {
            throw new NotImplementedException();
        }
    }
}
