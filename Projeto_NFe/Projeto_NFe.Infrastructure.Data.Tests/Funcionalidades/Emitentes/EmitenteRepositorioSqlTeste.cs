using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
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
        private Mock<Endereco> _enderecoMock;
        private Mock<CNPJ> _cnpjMock;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new EmitenteRepositorioSql();
            _enderecoMock = new Mock<Endereco>();
            _cnpjMock = new Mock<CNPJ>();

            BaseSqlTeste.InicializarBancoDeDados();
        }

        [Test]
        public void EmitenteRepositorioSql_Adicionar_Sucesso()
        {            
            _enderecoMock.Setup(em => em.Id).Returns(1);
            _cnpjMock.Object.NumeroComPontuacao = "99.327.235/0001-50";
            Emitente emitente = ObjectMother.PegarEmitenteValido(_enderecoMock.Object, _cnpjMock.Object);

            Emitente resultado = _repositorio.Adicionar(emitente);

            resultado.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmitenteRepositorioSql_Atualizar_Sucesso()
        {
            Emitente resultado = _repositorio.BuscarPorId(1);
            //_enderecoMock.Setup(em => em.Id).Returns(1);
            //_cnpjMock.Object.NumeroComPontuacao = "99.327.335/0001-50";
            //Emitente emitente = ObjectMother.PegarEmitenteValido(_enderecoMock.Object, _cnpjMock.Object);
            //emitente.Id = 1;

            //_repositorio.Atualizar(emitente);

            //Emitente resultado = _repositorio.BuscarPorId(emitente.Id);

            //resultado.NomeFantasia.Should().Be(emitente.NomeFantasia);
        }
    }
}
