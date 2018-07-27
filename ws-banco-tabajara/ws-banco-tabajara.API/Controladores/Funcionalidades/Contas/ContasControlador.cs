using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;

namespace ws_banco_tabajara.API.Controladores.Funcionalidades.Contas
{
    [RoutePrefix("api/contas")]
    public class ContasControlador : ApiController
    {
        private ContextoBancoTabajara bancoTabajaraContexto = new ContextoBancoTabajara();

        private IContaServico _contaServico;
        private IContaRepositorio _contaRepositorio;

        public ContasControlador() : base()
        {
            _contaRepositorio = new ContaRepositorioSQL(bancoTabajaraContexto);
            _contaServico = new ContaServico(_contaRepositorio);
        }

        [Route("{id}")]
        public Conta Depositar(long id, double valorDeposito)
        {
            Conta conta = _contaServico.Buscar(id);

            conta.Depositar(valorDeposito);

            return conta;
        }

        [Route("{id}")]
        public Conta Sacar(long id, double valorSaque)
        {
            Conta conta = _contaServico.Buscar(id);

            conta.Sacar(valorSaque);

            return conta;
        }

        [Route("{id}")]
        public Conta Transferir(long id, long idContaDestino, double valorTransferencia)
        {
            Conta conta = _contaServico.Buscar(id);

            Conta contaDestino = _contaServico.Buscar(idContaDestino);

            conta.Transferir(contaDestino, valorTransferencia);

            return conta;
        }
    }
}