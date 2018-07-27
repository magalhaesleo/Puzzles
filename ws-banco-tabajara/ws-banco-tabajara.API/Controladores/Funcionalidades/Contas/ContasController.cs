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

        #region Buscar

        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
           IQueryable<Conta> contas = _contaServico.BuscarTodos();

            return HandleQueryable<Conta>(contas);
        }

        // GET: api/ContasControlador/id
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Buscar(long id)
        {
            return HandleCallback(() => _contaServico.Buscar(id));
        }

        #endregion Buscar
        //// PUT: api/ContasControlador/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutConta(long id, Conta conta)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != conta.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(conta).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ContaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        #region Adicionar
        // POST: api/Contas
        [HttpPost]
        public IHttpActionResult PostConta(Conta conta)
        {
            return HandleCallback(() => _contaServico.Adicionar(conta));
        }

        #endregion Adicionar
        //// DELETE: api/ContasControlador/5
        //[ResponseType(typeof(Conta))]
        //public IHttpActionResult DeleteConta(long id)
        //{
        //    Conta conta = db.Contas.Find(id);
        //    if (conta == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Contas.Remove(conta);
        //    db.SaveChanges();

        //    return Ok(conta);
        //}
    }
}