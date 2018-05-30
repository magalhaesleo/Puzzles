using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Interfaces;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;

namespace Projeto_NFe.Application.Funcionalidades.Enderecos
{
    public class EnderecoServico : IEnderecoServico
    {
        private IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Endereco Adicionar(Endereco endereco)
        {
            endereco.Validar();

            return _enderecoRepositorio.Adicionar(endereco);
        }

        public Endereco Atualizar(Endereco endereco)
        {
            if(endereco.Id < 1)     
                throw new ExcecaoIdentificadorIndefinido();
            
            endereco.Validar();
            return _enderecoRepositorio.Atualizar(endereco);
        }

        public Endereco BuscarPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            return _enderecoRepositorio.BuscarPorId(id);
        }

        public IEnumerable<Endereco> BuscarTodos()
        {
            return _enderecoRepositorio.BuscarTodos();
        }

        public void Excluir(Endereco endereco)
        {
            if (endereco.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            _enderecoRepositorio.Excluir(endereco);
        }
    }
}
