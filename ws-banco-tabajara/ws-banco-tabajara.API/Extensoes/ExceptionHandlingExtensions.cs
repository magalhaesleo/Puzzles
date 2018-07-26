using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using ws_banco_tabajara.API.Excecoes;

namespace ws_banco_tabajara.API.Extensoes
{
    public static class ExceptionHandlingExtensions
    {
        /// <summary>
        /// Extension Method do HttpActionExecutedContext para manipular o context quando há uma exceção 
        /// e retornar um ExceptionPayload customizado, informando ao client o que houve de errado.
        /// 
        /// </summary>
        /// <param name="contexto">É o contexto atual da requisição</param>
        /// <returns>HttpResponseMessage contendo a exceção</returns>
        public static HttpResponseMessage HandleExecutedContextException(this HttpActionExecutedContext contexto)
        {
            // Retorna a resposta para o cliente com o erro 500 e o ExceptionPayload (código de erro de negócio e mensagem)
            return contexto.Request.CreateResponse(HttpStatusCode.InternalServerError, ExceptionPayload.New(contexto.Exception));
        }
    }
}