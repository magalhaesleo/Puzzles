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
    public class EnderecoService : IEnderecoService
    {
        private IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoService(IEnderecoRepositorio enderecoRepositorio)
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
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
