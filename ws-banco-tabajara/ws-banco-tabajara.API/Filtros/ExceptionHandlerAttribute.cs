using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using ws_banco_tabajara.API.Extensoes;

namespace ws_banco_tabajara.API.Filtros
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Método invocado quando ocorre uma exceção no controller
        /// </summary>
        /// <param name="contexto">É o contexto atual da requisição</param>
        public override void OnException(HttpActionExecutedContext contexto)
        {
            contexto.Response = contexto.HandleExecutedContextException();
        }
    }
}