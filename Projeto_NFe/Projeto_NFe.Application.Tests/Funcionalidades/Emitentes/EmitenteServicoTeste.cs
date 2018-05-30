using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteServicoTeste
    {
        Mock<IEmitenteRepositorio> _mockRepositorioEmitente;
        IEmitenteServico _emitenteServico;
        Mock<Emitente> _mockEmitente;
        Mock<CNPJ> _mockCnpj;

        [SetUp]
        public void InicializarTestes()
        {
            _mockRepositorioEmitente = new Mock<IEmitenteRepositorio>();
            _mockEmitente = new Mock<Emitente>();
            _emitenteServico = new EmitenteServico(_mockRepositorioEmitente.Object);
            _mockCnpj = new Mock<CNPJ>();

            _mockEmitente.Object.CNPJ = _mockCnpj.Object;
        }

        [Test]
        public void EmitenteServico_Adicionar_Sucesso()
        {
            _mockEmitente.Setup(me => me.Validar());
            _mockCnpj.Setup(mc => mc.Validar());
            _mockRepositorioEmitente.Setup(mre => mre.Adicionar(_mockEmitente.Object)).Returns(_mockEmitente.Object);

            _emitenteServico.Adicionar(_mockEmitente.Object);

            _mockCnpj.Verify(mc => mc.Validar());
            _mockEmitente.Verify(me => me.Validar());
            _mockRepositorioEmitente.Verify(mre => mre.Adicionar(_mockEmitente.Object));
        }

        [Test]
        public void EmitenteServico_Atualizar_Sucesso()
        {

        }

        [Test]
        public void EmitenteServico_Excluir_Sucesso()
        {

        }

        [Test]
        public void EmitenteServico_BuscarPorId_Sucesso()
        {

        }

        [Test]
        public void EmitenteServico_BuscarTodos_Sucesso()
        {

        }
    }
}
