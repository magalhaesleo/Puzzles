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

            Cliente clienteAdicionadoBanco = _clienteRepositorio.Buscar(conta.Titular.Id);

            //Se a conta ja existir na base de dados, utiliza a mesma referencia
            //Senão o EF fará a adição da conta
            if (clienteAdicionadoBanco != null)
                conta.Titular = clienteAdicionadoBanco;

            Conta contaAdicionada = _contaRepositorio.Adicionar(conta);

            return contaAdicionada;
        }

        public void AlterarStatusConta(long contaId)
        {
            Conta contaBuscadaDoBanco = _contaRepositorio.Buscar(contaId);

            contaBuscadaDoBanco.Ativa = !contaBuscadaDoBanco.Ativa;

            _contaRepositorio.Editar(contaBuscadaDoBanco);
        }

        public Conta Buscar(long id)
        {
            return _contaRepositorio.Buscar(id);
        }

        public IQueryable<Conta> BuscarListaPorQuantidadeDefinida(int quantidade)
        {
            return _contaRepositorio.BuscarListaPorQuantidadeDefinida(quantidade);
        }

        public IQueryable<Conta> BuscarTodos()
        {
            return _contaRepositorio.BuscarTodos();
        }

        public void Editar(Conta conta)
        {
            //Verifica se conta possui um titular para continuar
            if (conta.Titular == null)
                throw new ContaSemTitularExcecao();

            //Se possuir verifica se ja existe no banco
            Cliente clienteAdicionadoBanco = _clienteRepositorio.Buscar(conta.Titular.Id);

            if (clienteAdicionadoBanco == null)
                throw new ExcecaoRegistroNaoEncontrado();

            //Busca no banco para pegar a conta referencia
            Conta contaReferencia = _contaRepositorio.Buscar(conta.Id);

            if (conta.Numero != contaReferencia.Numero)
                throw new ContaNumeroAlteradoExcecao();

            //atualiza as informações da conta
            contaReferencia.Limite = conta.Limite;
            contaReferencia.Saldo = conta.Saldo;
            contaReferencia.Ativa = conta.Ativa;

            //Salva no banco
            _contaRepositorio.Editar(contaReferencia);
           
        }

        public void Excluir(long idConta)
        {
            Conta contaParaExcluir = _contaRepositorio.Buscar(conta.Id);

            _contaRepositorio.Excluir(contaParaExcluir);
        }
    }
}
