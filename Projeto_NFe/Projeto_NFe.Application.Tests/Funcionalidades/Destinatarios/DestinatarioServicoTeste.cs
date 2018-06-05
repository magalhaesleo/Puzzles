using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Destinatarios
{
    [TestFixture]
    public class DestinatarioServicoTeste
    {
        Mock<IDestinatarioRepositorio> _mockRepositorioDestinatario;
        IDestinatarioServico _servicoDestinatario;
        Mock<IEnderecoRepositorio> _mockRepositorioEndereco;
        Mock<Destinatario> _mockDestinatario;
        Mock<CNPJ> _mockCnpj;
        Mock<CPF> _mockCpf;
        Mock<Endereco> _mockEndereco;

        [SetUp]
        public void InicializarTestes()
        {
            _mockRepositorioDestinatario = new Mock<IDestinatarioRepositorio>();
            _mockDestinatario = new Mock<Destinatario>();
            _mockRepositorioDestinatario = new Mock<IDestinatarioRepositorio>();
            _mockRepositorioEndereco = new Mock<IEnderecoRepositorio>();
            _servicoDestinatario = new DestinatarioServico(_mockRepositorioEndereco.Object, _mockRepositorioDestinatario.Object);
            _mockCnpj = new Mock<CNPJ>();
            _mockCpf = new Mock<CPF>();
            _mockEndereco = new Mock<Endereco>();
        }

        [Test]
        public void DestinatarioServico_Adicionar_Sucesso()
        {
            _mockDestinatario.Object.Endereco = _mockEndereco.Object;
            _mockDestinatario.Object.Documento = _mockCnpj.Object;

            _mockDestinatario.Setup(md => md.Validar());

            _mockRepositorioEndereco.Setup(mre => mre.Adicionar(_mockEndereco.Object)).Returns(_mockEndereco.Object);
            _mockRepositorioDestinatario.Setup(mrd => mrd.Adicionar(_mockDestinatario.Object)).Returns(_mockDestinatario.Object);

            _servicoDestinatario.Adicionar(_mockDestinatario.Object);

            _mockDestinatario.Verify(md => md.Validar());
            _mockRepositorioEndereco.Verify(mre => mre.Adicionar(_mockEndereco.Object));
            _mockRepositorioDestinatario.Verify(mrd => mrd.Adicionar(_mockDestinatario.Object));

        }

        [Test]
        public void DestinatarioServico_Atualizar_Sucesso()
        {
            _mockDestinatario.Object.Endereco = _mockEndereco.Object;
            _mockDestinatario.Object.Documento = _mockCnpj.Object;

            _mockDestinatario.Setup(md => md.Validar());
            _mockDestinatario.Setup(md => md.Id).Returns(1);

            _mockRepositorioEndereco.Setup(mre => mre.Atualizar(_mockEndereco.Object)).Returns(_mockEndereco.Object);
            _mockRepositorioDestinatario.Setup(mrd => mrd.Atualizar(_mockDestinatario.Object)).Returns(_mockDestinatario.Object);

            _servicoDestinatario.Atualizar(_mockDestinatario.Object);

            _mockDestinatario.Verify(md => md.Validar());
            _mockRepositorioEndereco.Verify(mre => mre.Atualizar(_mockEndereco.Object));
            _mockRepositorioDestinatario.Verify(mrd => mrd.Atualizar(_mockDestinatario.Object));

        }

        [Test]
        public void DestinatarioServico_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockDestinatario.Setup(md => md.Id).Returns(idInvalido);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Atualizar(_mockDestinatario.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioDestinatario.VerifyNoOtherCalls();

        }

        [Test]
        public void DestinatarioServico_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        {
            long idInvalido = 0;

            _mockDestinatario.Setup(md => md.Id).Returns(idInvalido);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Excluir(_mockDestinatario.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();

            _mockRepositorioDestinatario.VerifyNoOtherCalls();

        }

        [Test]
        public void DestinatarioServico_Excluir_Sucesso()
        {
            long idValido = 1;

            _mockDestinatario.Setup(md => md.Id).Returns(idValido);

            _mockRepositorioDestinatario.Setup(mrd => mrd.Excluir(_mockDestinatario.Object));
            _mockRepositorioEndereco.Setup(mre => mre.Excluir(_mockDestinatario.Object.Endereco));

            _servicoDestinatario.Excluir(_mockDestinatario.Object);

            _mockRepositorioDestinatario.Verify(mrd => mrd.Excluir(_mockDestinatario.Object));
            _mockRepositorioEndereco.Verify(mre => mre.Excluir(_mockDestinatario.Object.Endereco));

        }

        [Test]
        public void DestinatarioServico_BuscarPorId_Sucesso()
        {
            long id = 1;

            _mockRepositorioDestinatario.Setup(er => er.BuscarPorId(id));

            _servicoDestinatario.BuscarPorId(id);

            _mockRepositorioDestinatario.Verify(er => er.BuscarPorId(id));
        }

        [Test]
        public void DestinatarioServico_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long id = 0;

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.BuscarPorId(id);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoIdentificadorIndefinido>();
        }

        [Test]
        public void DestinatarioServico_BuscarTodos_Sucesso()
        {
            long id = 1;

            _mockRepositorioDestinatario.Setup(er => er.BuscarTodos());

            _servicoDestinatario.BuscarTodos();

            _mockRepositorioDestinatario.Verify(er => er.BuscarTodos());
        }




    }
}
