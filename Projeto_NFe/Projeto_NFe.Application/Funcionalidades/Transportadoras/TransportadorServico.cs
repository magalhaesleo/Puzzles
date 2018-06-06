using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;

namespace Projeto_NFe.Application.Funcionalidades.Transportadoras
{
    public class TransportadorServico : ITransportadorServico
    {
        private ITransportadorRepositorio _transportadoraRepositorio;
        private IEnderecoRepositorio _enderecoRepositorio;

        public TransportadorServico(ITransportadorRepositorio transportadoraRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _transportadoraRepositorio = transportadoraRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Transportador Adicionar(Transportador transportador)
        {
            transportador.Validar();

            transportador.Endereco = _enderecoRepositorio.Adicionar(transportador.Endereco);
            return _transportadoraRepositorio.Adicionar(transportador);
        }

        public Transportador Atualizar(Transportador transportador)
        {
            transportador.Validar();

            if (transportador.Id < 1 || transportador.Endereco.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            transportador.Endereco = _enderecoRepositorio.Atualizar(transportador.Endereco);
            return _transportadoraRepositorio.Atualizar(transportador);
        }

        public Transportador BuscarPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            Transportador transportador = _transportadoraRepositorio.BuscarPorId(id);
            return transportador;
        }

        public IEnumerable<Transportador> BuscarTodos()
        {
            return _transportadoraRepositorio.BuscarTodos();
        }

        public void Excluir(Transportador transportador)
        {
            if (transportador.Id < 1 || transportador.Endereco.Id < 1)
                throw new ExcecaoIdentificadorIndefinido();

            _transportadoraRepositorio.Excluir(transportador);
            _enderecoRepositorio.Excluir(transportador.Endereco);
            
        }
    }
}
