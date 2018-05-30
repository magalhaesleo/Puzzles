using Projeto_NFe.Application.Interfaces;
using Projeto_NFe.Domain.Funcionalidades.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes
{
    public class EmitenteServico : IEmitenteServico
    {
        IEmitenteRepositorio _repositorio;
        public EmitenteServico(IEmitenteRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Emitente Adicionar(Emitente entidade)
        {
            entidade.Validar();
            entidade.CNPJ.Validar();

           return _repositorio.Adicionar(entidade);
        }

        public Emitente Atualizar(Emitente entidade)
        {
            throw new NotImplementedException();
        }

        public Emitente BuscarPorId(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emitente> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Emitente entidade)
        {
            throw new NotImplementedException();
        }
    }
}
