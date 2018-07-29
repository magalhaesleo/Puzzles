using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ws_banco_tabajara.Application.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.API.Controladores.Base;
using ws_banco_tabajara.Domain.Excecoes;
using System;
using System.Net.Http;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes;

namespace ws_banco_tabajara.API.Controladores.Funcionalidades.Clientes
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ControladorBaseAPI
    {
        private ContextoBancoTabajara bancoTabajaraContexto = new ContextoBancoTabajara();

        public IClienteServico _clienteServico;
        IClienteRepositorio _clienteRepositorio;

        public ClientesController() : base()
        {
            _clienteRepositorio = new ClienteRepositorioSQL(bancoTabajaraContexto);
            _clienteServico = new ClienteServico(_clienteRepositorio);
        }

        #region GET
        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            var queryString = Request.GetQueryNameValuePairs()
                                .Where(x => x.Key.Equals("quantidade"))
                                .FirstOrDefault();

            int? quantidade = null;

            IQueryable<Cliente> clientesEncontrados = null;

            if (queryString.Key != null)
            {
                quantidade = int.Parse(queryString.Value);
                clientesEncontrados = _clienteServico.BuscarListaPorQuantidadeDefinida((int)quantidade);
            }
            else
            {
                clientesEncontrados = _clienteServico.BuscarTodos();
            }
   
           return HandleQueryable<Cliente>(clientesEncontrados);
        }

        [HttpGet]
        [Route("{clienteId:int}")]
        public IHttpActionResult Buscar(long clienteId)
        {
            return HandleCallback(() => _clienteServico.Buscar(clienteId));
        }



        #endregion

        #region PUT
        [HttpPut]
        public IHttpActionResult Editar(Cliente cliente)
        {
            _clienteServico.Editar(cliente);
            return Ok(true);
        }

        #endregion

        #region POST

        [HttpPost]
        public IHttpActionResult Adicionar(Cliente cliente)
        {
            return HandleCallback(() => _clienteServico.Adicionar(cliente));
        }

        #endregion

        #region DELETE
       
        [HttpDelete]
        [Route("{idCliente:long}")]
        public IHttpActionResult Excluir(long idCliente)
        {
            Action acaoDeExcluir = () => _clienteServico.Excluir(idCliente);

            acaoDeExcluir.Invoke();

            return Ok();
        }

        #endregion


    }
}