using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ws_banco_tabajara.API.Controladores.Base
{
    [RoutePrefix("api/publico")]
    public class ControladorPublico : ControladorBaseAPI
    {
        /// <summary>
        /// Informa para o client que está ativa
        /// Útil para validar tokens e para descobrir o estado da API
        /// </summary>
        [HttpGet]
        [Route("is-alive")]
        public IHttpActionResult IsAlive()
        {
            return Ok(true);
        }
    }
}