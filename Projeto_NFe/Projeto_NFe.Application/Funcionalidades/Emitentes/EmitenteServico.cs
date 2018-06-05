using Projeto_NFe.Application.Interfaces;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes
{
    public class EmitenteServico : IEmitenteServico
    {
        IEmitenteRepositorio _repositorio;
        IEnderecoRepositorio _enderecoRepositorio;
        public EmitenteServico(IEmitenteRepositorio repositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
            _repositorio = repositorio;
        }

        public Emitente Adicionar(Emitente emitente)
        {
           emitente.Validar();

           emitente.Endereco = _enderecoRepositorio.Adicionar(emitente.Endereco);
           return _repositorio.Adicionar(emitente);
        }

        public Emitente Atualizar(Emitente emitente)
        {
            if (emitente.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            emitente.Validar();

            emitente.Endereco = _enderecoRepositorio.Atualizar(emitente.Endereco);
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

            //Adicionar validação para id do endereço
            _repositorio.Excluir(emitente);
            _enderecoRepositorio.Excluir(emitente.Endereco);
        }
    }
}
