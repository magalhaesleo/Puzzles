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
using ws_banco_tabajara.API.Controladores.Base;
using ws_banco_tabajara.Application.Funcionalidades.Contas;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Contas;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.RepositorioSqlEF;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Contas;

namespace ws_banco_tabajara.API.Controladores.Funcionalidades.Contas
{
    [RoutePrefix("api/contas")]
    public class ContasController : ControladorBaseAPI
    {
        private ContextoBancoTabajara bancoTabajaraContexto = new ContextoBancoTabajara();

        private IContaServico _contaServico;
        private IContaRepositorio _contaRepositorio;
        private IClienteRepositorio _clienteRepositorio;

        public ContasController() : base()
        {
            _contaRepositorio = new ContaRepositorioSQL(bancoTabajaraContexto);
            _clienteRepositorio = new ClienteRepositorioSqlEF(bancoTabajaraContexto);
            _contaServico = new ContaServico(_contaRepositorio, _clienteRepositorio);
        }

        #region Adicionar

        [HttpPost]
        public IHttpActionResult PostConta(Conta conta)
        {
            return HandleCallback(() => _contaServico.Adicionar(conta));
        }

        #endregion Adicionar

        #region Buscar

        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {

            KeyValuePair<string,string> queryString = Request.GetQueryNameValuePairs()
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

        #endregion Buscar

        #region Atualizar
  
        [HttpPut]
        public IHttpActionResult Editar(Conta conta)
        {
            _contaServico.Editar(conta);

            return Ok();
        }

        #endregion Atualizar

        #region Excluir
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Excluir(long id)
        {
            Conta contaExcluir = new Conta();
            contaExcluir.Id = id;

             _contaServico.Excluir(contaExcluir);

            return Ok();
        }

        #endregion Excluir

        #region AlterarStatus
        [HttpPatch]
        [Route("{id:int}/{alterarStatus}")]
        public IHttpActionResult AtualizarStatus(long id)
        { 
            _contaServico.AlterarStatusConta(id);

            return Ok();
        }
        #endregion AlterarStatus
    }
}