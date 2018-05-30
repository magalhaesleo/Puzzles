using NUnit.Framework;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteRepositorioSqlTeste
    {
        private IEmitenteRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new EmitenteRepositorioSql();


        }
    }
}
