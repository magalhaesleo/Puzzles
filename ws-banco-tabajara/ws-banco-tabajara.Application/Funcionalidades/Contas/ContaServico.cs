using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Excecoes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;

namespace ws_banco_tabajara.Application.Funcionalidades.Contas
{
    public class ContaServico : IContaServico
    {
        private IContaRepositorio _contaRepositorio;
        public ContaServico(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }
        public Conta Adicionar(Conta conta)
        {
            Conta contaAdicionada = _contaRepositorio.Adicionar(conta);

            return contaAdicionada;
        }

        public void AlterarStatusConta(long contaId)
        {
            Conta contaBuscadaDoBanco = _contaRepositorio.Buscar(contaId);

            contaBuscadaDoBanco.AlterarStatus();

            _contaRepositorio.Editar(contaBuscadaDoBanco);
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

        public void Excluir(Conta conta)
        {
            _contaRepositorio.Excluir(conta);
        }
    }
}
