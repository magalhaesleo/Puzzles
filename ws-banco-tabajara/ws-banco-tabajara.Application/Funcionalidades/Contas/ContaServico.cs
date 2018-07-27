using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Excecoes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public class ContaServico : IContaServico
    {
        private IContaRepositorio _contaRepositorio;
        private IClienteRepositorio _clienteRepositorio;
        public ContaServico(IContaRepositorio contaRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _contaRepositorio = contaRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }
        public Conta Adicionar(Conta conta)
        {
            if (conta.Titular == null)
                throw new ContaSemTitularExcecao();

            conta.Titular = _clienteRepositorio.Buscar(conta.Titular.Id);

            Conta contaAdicionada = _contaRepositorio.Adicionar(conta);

            return contaAdicionada;
        }

        public Conta Buscar(long id)
        {
            return _contaRepositorio.Buscar(id);
        }

        public IQueryable<Conta> BuscarTodos()
        {
            return _contaRepositorio.BuscarTodos();
        }

        public void Editar(Conta contaReferencia)
        {
            Conta contaBuscadaNoBanco = _contaRepositorio.Buscar(contaReferencia.Id) ?? throw new ExcecaoRegistroNaoEncontrado();

            if(contaReferencia.Titular!=null)
            contaBuscadaNoBanco.Titular = contaReferencia.Titular;

            contaBuscadaNoBanco.Limite = contaReferencia.Limite;
            contaBuscadaNoBanco.Numero = contaReferencia.Numero;
            contaBuscadaNoBanco.Saldo = contaReferencia.Saldo;
                    
            _contaRepositorio.Editar(contaBuscadaNoBanco);
        }

        public void Excluir(long idConta)
        {
            Conta contaBuscadaNoBanco = _contaRepositorio.Buscar(idConta);
            
            _contaRepositorio.Excluir(contaBuscadaNoBanco);
        }

        public void AlterarStatusConta(long contaId)
        {
            Conta contaBuscadaDoBanco = _contaRepositorio.Buscar(contaId);

            contaBuscadaDoBanco.AlterarStatus();

            _contaRepositorio.Editar(contaBuscadaDoBanco);
        }

        public Conta Sacar(long contaId, double valor)
        {
            Conta contaBuscadaDoBanco = _contaRepositorio.Buscar(contaId);

            contaBuscadaDoBanco.Sacar(valor);

            _contaRepositorio.Editar(contaBuscadaDoBanco);

            return contaBuscadaDoBanco;
        }

        public Conta Depositar(long contaId, double valor)
        {
            Conta contaBuscadaDoBanco = _contaRepositorio.Buscar(contaId);

            contaBuscadaDoBanco.Depositar(valor);

            _contaRepositorio.Editar(contaBuscadaDoBanco);

            return contaBuscadaDoBanco;
        }

        public Conta Transferir(long contaId, long contaMovimentadaId, double valor)
        {
            Conta contaBuscadaDoBanco = _contaRepositorio.Buscar(contaId);
            Conta contaMovimentadaBuscadaDoBanco = _contaRepositorio.Buscar(contaMovimentadaId);

            contaBuscadaDoBanco.Transferir(contaMovimentadaBuscadaDoBanco, valor);

            _contaRepositorio.Editar(contaBuscadaDoBanco);
            _contaRepositorio.Editar(contaMovimentadaBuscadaDoBanco);

            return contaBuscadaDoBanco;
        }
    }
}
