using Projeto_NFe.Application.Interfaces;
using Projeto_NFe.Domain.Excecoes;
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

        public Emitente Adicionar(Emitente emitente)
        {
            emitente.Validar();
            emitente.CNPJ.Validar();

           return _repositorio.Adicionar(emitente);
        }

        public Emitente Atualizar(Emitente emitente)
        {
            if (emitente.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            emitente.Validar();
            emitente.CNPJ.Validar();
            return _repositorio.Atualizar(emitente);
        }

        public Emitente BuscarPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            return _repositorio.BuscarPorId(id);
        }

        public IEnumerable<Emitente> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public void Excluir(Emitente emitente)
        {
            if (emitente.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            _repositorio.Excluir(emitente);
        }
    }
}
