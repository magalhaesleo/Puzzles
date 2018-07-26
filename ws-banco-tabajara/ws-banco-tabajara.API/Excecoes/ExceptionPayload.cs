using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ws_banco_tabajara.Domain.Excecoes;

namespace ws_banco_tabajara.API.Excecoes
{
    public class ExceptionPayload
    {
        public int CodigoDoErro { get; set; }

        public string MensagemDoErro { get; set; }

        /// <summary>
        /// Método para criar um novo ExceptionPayload de uma exceção de negócio.
        ///          
        /// As exceções de negócio, que são providas no Prova1.Domain
        /// são identificadas pelos códigos no enum ErrorCodes. 
        /// 
        /// Assim, esse método monta o ExceptionPayload, que será o código retornado o cliente, 
        /// com base na exceção lançada.
        /// 
        ///</summary>
        /// <param name="excecao">É a exceção lançada</param>
        /// <returns>ExceptionPayload contendo o código do erro e a mensagem da da exceção que foi lançada </returns>
        public static ExceptionPayload New<T>(T excecao) where T : Exception
        {
            int codigoDeErro;
            if (excecao is ExcecaoDeNegocio)
                codigoDeErro = (excecao as ExcecaoDeNegocio).CodigoDoErro.GetHashCode();
            else
                codigoDeErro = CodigosDeErro.Unhandled.GetHashCode();
            return new ExceptionPayload
            {
                CodigoDoErro = codigoDeErro,
                MensagemDoErro = excecao.Message,
            };
        }
    }
}