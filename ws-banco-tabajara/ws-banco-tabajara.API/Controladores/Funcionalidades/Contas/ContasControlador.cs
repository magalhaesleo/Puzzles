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

        #region Buscar
        
        [HttpGet]
        public IQueryable<Conta> BuscatrTodos()
        {
            return _contaServico.BuscarTodos();
        }

        // GET: api/ContasControlador/5
        [ResponseType(typeof(Conta))]
        public IHttpActionResult GetConta(long id)
        {
            Conta conta = db.Contas.Find(id);
            if (conta == null)
            {
                return NotFound();
            }

            return Ok(conta);
        }

        // PUT: api/ContasControlador/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConta(long id, Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conta.Id)
            {
                return BadRequest();
            }

            db.Entry(conta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContasControlador
        [ResponseType(typeof(Conta))]
        public IHttpActionResult PostConta(Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contas.Add(conta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conta.Id }, conta);
        }

        // DELETE: api/ContasControlador/5
        [ResponseType(typeof(Conta))]
        public IHttpActionResult DeleteConta(long id)
        {
            Conta conta = db.Contas.Find(id);
            if (conta == null)
            {
                return NotFound();
            }

            db.Contas.Remove(conta);
            db.SaveChanges();

            return Ok(conta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContaExists(long id)
        {
            return db.Contas.Count(e => e.Id == id) > 0;
        }
    }
}