using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ws_banco_tabajara.API.Controladores.Base;

namespace ws_banco_tabajara.Controller.Tests.Base
{
    /// <summary>
    /// Fake para tornar acessivel e sem influência os métodos protected de ApiControllerBase
    /// </summary>
    public class ControladorBaseAPIFake : ControladorBaseAPI
    {
         public IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            return base.HandleCallback(func);
        }

        public IHttpActionResult HandleQuery<TResult>(IQueryable<TResult> query)
        {
            return base.HandleQuery(query);
        }

        public IHttpActionResult HandleQueryable<TSource>(IQueryable<TSource> query)
        {
            return base.HandleQueryable<TSource>(query);
        }

        public IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure { 
            return base.HandleValidationFailure<T>(validationFailure);
        }
    }

    /// <summary>
    /// Dummy usado para preencher valores: um tipo vazio
    /// </summary>
    public class ControladorBaseAPIDummy
    {
    }

    /// <summary>
    /// Dummy usado para conversões de mapeamento
    /// </summary>
    public class ControladorBaseAPIDummyQuery
    {
    }
}
