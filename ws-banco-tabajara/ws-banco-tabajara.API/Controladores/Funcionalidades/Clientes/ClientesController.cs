using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ws_banco_tabajara.Application.Funcionalidades.Clientes;
using ws_banco_tabajara.Domain.Funcionalidades.Clientes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Clientes.RepositorioSqlEF;
using ws_banco_tabajara.API.Controladores.Base;

namespace ws_banco_tabajara.API.Controladores.Funcionalidades.Clientes
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : ControladorBaseAPI
    {
        private ContextoBancoTabajara bancoTabajaraContexto = new ContextoBancoTabajara();

        IClienteServico _clienteServico;
        IClienteRepositorio _clienteRepositorio;

        public ClientesController() : base()
        {
            _clienteRepositorio = new ClienteRepositorioSqlEF(bancoTabajaraContexto);
            _clienteServico = new ClienteServico(_clienteRepositorio);
        }

        #region GET
        [HttpGet]
        public IHttpActionResult BuscarTodos()
        {
            var clientesEncontrados = _clienteRepositorio.BuscarTodos();
            return HandleQueryable<Cliente>(clientesEncontrados);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Buscar(long clienteId)
        {
            return HandleCallback(() => _clienteServico.Buscar(clienteId));
        }

        #endregion

        #region PUT
        // PUT: api/ClientesControlador/5
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
        public IHttpActionResult Excluir(Cliente cliente)
        {
            _clienteServico.Excluir(cliente);

            return Ok(true);
        }

        #endregion


    }
}