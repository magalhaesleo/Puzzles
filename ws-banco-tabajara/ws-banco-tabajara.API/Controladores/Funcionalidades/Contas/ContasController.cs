﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ws_banco_tabajara.API.Controladores.Base;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;

namespace ws_banco_tabajara.API.Controladores.Funcionalidades.Contas
{
    [RoutePrefix("api/contas")]
    public class ContasController : ControladorBaseAPI
    {
        private ContextoBancoTabajara bancoTabajaraContexto = new ContextoBancoTabajara();

        public IContaServico _contaServico;
        private IContaRepositorio _contaRepositorio;
        private IClienteRepositorio _clienteRepositorio;

        public ContasController() : base()
        {
            _contaRepositorio = new ContaRepositorioSQL(bancoTabajaraContexto);
            _clienteRepositorio = new ClienteRepositorioSQL(bancoTabajaraContexto);
            _contaServico = new ContaServico(_contaRepositorio, _clienteRepositorio);
        }

        #region Adicionar

        [HttpPost]
        public IHttpActionResult Adicionar(Conta conta)
        {

            return HandleCallback(() => _contaServico.Adicionar(conta));
        }

        #endregion Adicionar

        #region Buscar

        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            KeyValuePair<string, string> queryString = Request.GetQueryNameValuePairs()
                                  .Where(x => x.Key.Equals("quantidade"))
                                  .FirstOrDefault();

            IQueryable<Conta> contasBuscadas;
            if (queryString.Key != null)
            {
                int quantidade = int.Parse(queryString.Value);
                contasBuscadas = _contaServico.BuscarListaPorQuantidadeDefinida(quantidade);
            }
            else
            {
                contasBuscadas = _contaServico.BuscarTodos();
            }

            return HandleQueryable<Conta>(contasBuscadas);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Buscar(long id)
        {
            return HandleCallback(() => _contaServico.Buscar(id));
        }

        [HttpGet]
        [Route("cliente/{idCliente:int}")]
        public IHttpActionResult BuscarPorIdentificacaoDeCliente(long idCliente)
        {
            return HandleCallback(() => _contaServico.BuscarPorIdentificacaoDeCliente(idCliente));
        }

        #endregion Buscar

        #region Atualizar

        [HttpPut]
        public IHttpActionResult Editar(Conta conta)
        {

            return HandleCallback(() => _contaServico.Editar(conta));

        }

        #endregion Atualizar

        #region Excluir
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Excluir(long id)
        {
            Conta contaExcluir = new Conta();
            contaExcluir.Id = id;

            _contaServico.Excluir(id);

            return Ok();
        }

        #endregion Excluir

        #region AlterarStatus
        [HttpPatch]
        [Route("{id:int}/{alterarStatus}")]
        public IHttpActionResult AlterarStatus(long id)
        {
            return HandleCallback(() => _contaServico.AlterarStatusConta(id));
        }

        #endregion AlterarStatus

        #region MovimentacoesConta
        [HttpPut]
        [Route("{id:long}/depositar")]
        public IHttpActionResult Depositar(long id, [FromBody]double valorDeposito)
        {
            return HandleCallback(() => _contaServico.Depositar(id, valorDeposito));
        }

        [HttpPut]
        [Route("{id:long}/sacar")]
        public IHttpActionResult Sacar(long id, [FromBody]double valorSaque)
        {
            return HandleCallback(() => _contaServico.Sacar(id, valorSaque));
        }

        [HttpPut]
        [Route("{id:long}/transferir/{idContaDestino:long}")]
        public IHttpActionResult Transferir(long id, long idContaDestino, [FromBody]double valorTransferencia)
        {
            return HandleCallback(() => _contaServico.Transferir(id, idContaDestino, valorTransferencia));
        }

        #endregion MovimentacoesConta

        #region GerarExtrato

        [HttpGet]
        [Route("{id:long}/extrato")]
        public IHttpActionResult GerarExtrato(long id)
        {
            return HandleCallback(() => _contaServico.GerarExtrato(id));
        }

        #endregion
    }
}