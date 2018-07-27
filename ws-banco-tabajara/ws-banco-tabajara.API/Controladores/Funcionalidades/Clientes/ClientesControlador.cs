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
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.RepositorioSqlEF;

namespace ws_banco_tabajara.API.Controladores.Funcionalidades.Clientes
{
    [RoutePrefix("api/clientes")]
    public class ClientesControlador : ApiController
    {
        private ContextoBancoTabajara bancoTabajaraContexto = new ContextoBancoTabajara();

        //IClienteServico _clienteServico;
        //IClienteRepositorio _clienteRepositorio;

        //public ClientesControlador() : base()
        //{
        //    _clienteRepositorio = new ClienteRepositorioSqlEF(bancoTabajaraContexto);
        //    _clienteServico = new ClienteServico(_clienteRepositorio);
        //}
        //// GET: api/ClientesControlador
        //public IQueryable<Cliente> GetClientes()
        //{
            
        //}

        //// GET: api/ClientesControlador/5
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult GetCliente(long id)
        //{
        //    Cliente cliente = db.Clientes.Find(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(cliente);
        //}

        //// PUT: api/ClientesControlador/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCliente(long id, Cliente cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cliente.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(cliente).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClienteExists(id))
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

        //// POST: api/ClientesControlador
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult PostCliente(Cliente cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Clientes.Add(cliente);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        //}

        //// DELETE: api/ClientesControlador/5
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult DeleteCliente(long id)
        //{
        //    Cliente cliente = db.Clientes.Find(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Clientes.Remove(cliente);
        //    db.SaveChanges();

        //    return Ok(cliente);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ClienteExists(long id)
        //{
        //    return db.Clientes.Count(e => e.Id == id) > 0;
        //}
    }
}