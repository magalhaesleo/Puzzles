﻿using Microsoft.Owin;
using Owin;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http;

[assembly: OwinStartup(typeof(ws_banco_tabajara.API.Startup))]
namespace ws_banco_tabajara.API
{
    /// <summary>
    /// Classe para o inicio da API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Método que invoca as configurações iniciais para execução da API
        /// 
        /// Existem configurações que são executadas durante a inicialização. Veja também em Global.asax 
        /// 
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            // Cria a configuração da api
            HttpConfiguration config = new HttpConfiguration();
            // Inicia a API com as configurações
            app.UseWebApi(config);
        }
    }
}