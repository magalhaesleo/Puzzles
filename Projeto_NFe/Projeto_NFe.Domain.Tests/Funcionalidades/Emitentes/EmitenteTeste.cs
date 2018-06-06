using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteTeste
    {
        private Mock<Endereco> _enderecoMock;
        private Mock<CNPJ> _cnpjMock;

        [SetUp]
        public void Inicializa()
        {
            _enderecoMock = new Mock<Endereco>();
            _cnpjMock = new Mock<CNPJ>();
        }

        [Test]
        public void Emitente_Validar_Sucesso()
        {
            Emitente emitente = ObjectMother.PegarEmitenteValido(_enderecoMock.Object, _cnpjMock.Object);

            _enderecoMock.Setup(em => em.Validar());
            _cnpjMock.Setup(cm => cm.Validar());

            Action resultado = () => emitente.Validar();

            resultado.Should().NotThrow<ExcecaoDeNegocio>();

            _enderecoMock.Verify(em => em.Validar());
            _cnpjMock.Verify(cm => cm.Validar());
        }

        [Test]
        public void Emitente_Validar_SemNome_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteSemNome(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoEmitenteSemNome>();
            
        }

        [Test]
        public void Emitente_Validar_SemRazaoSocial_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteSemRazaoSocial(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

      
            resultado.Should().Throw<ExcecaoEmitenteSemRazaoSocial>();
        }

        [Test]
        public void Emitente_Validar_SemCNPJ_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteSemCNPJ(_enderecoMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoEmitenteSemCNPJ>();
        }

        [Test]
        public void Emitente_Validar_SemInscricaoEstadual_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteSemInscricaoEstadual(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

           resultado.Should().Throw<ExcecaoEmitenteSemInscricaoEstadual>();
        }

        [Test]
        public void Emitente_Validar_SemInscricaoMunicipal_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteSemInscricaoMunicipal(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoEmitenteSemInscricaoMunicipal>();
        }

        [Test]
        public void Emitente_Validar_SemEndereco_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteSemEndereco(_cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoEmitenteSemEndereco>();
        }

        [Test]
        public void Emitente_Validar_Nome3Letras_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteComNomeDe3Letras(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoNomeEmitentePequeno>();
        }

        [Test]
        public void Emitente_Validar_RazaoSocial3Letras_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteComRazaoSocialDe3Letras(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoRazaoSocialEmitentePequeno>();
        }

        [Test]
        public void Emitente_Validar_InscricaoEstadualInvalida_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteComInscricaoEstadualInvalida(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoEmitenteComInscricaoEstadualAcimaDoLimite>();
        }

        [Test]
        public void Emitente_Validar_InscricaoEstadualComLetras_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteComInscricaoEstadualComLetras(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoInscricacaoEstadualEmitenteComLetras>();
        }

        [Test]
        public void Emitente_Validar_InscricaoMunicipalComLetras_Falha()
        {
            Emitente emitente = ObjectMother.PegarEmitenteComInscricaoMunicipalComLetras(_enderecoMock.Object, _cnpjMock.Object);

            Action resultado = () => emitente.Validar();

            resultado.Should().Throw<ExcecaoInscricacaoMunicipalEmitenteComLetras>();
        }
    }
}
