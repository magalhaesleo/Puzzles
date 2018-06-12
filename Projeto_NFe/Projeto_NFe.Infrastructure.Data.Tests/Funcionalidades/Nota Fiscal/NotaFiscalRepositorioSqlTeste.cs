using NUnit.Framework;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalRepositorioSqlTeste
    {
        private INotaFiscalRepositorio _repositorio;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new NotaFiscalRepositorioSql();
        }

        [Test]
        public void NotaFiscal_InfraData_Adicionar_Sucesso()
        {
            
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_Sucesso()
        {
        }

        [Test]
        public void NotaFiscal_InfraData_BuscarPorId_Sucesso()
        {
        }

        [Test]
        public void NotaFiscal_InfraData_BuscarTodos_Sucesso()
        {
        }

        [Test]
        public void NotaFiscal_InfraData_Excluir_Sucesso()
        {
        }
    }
}
