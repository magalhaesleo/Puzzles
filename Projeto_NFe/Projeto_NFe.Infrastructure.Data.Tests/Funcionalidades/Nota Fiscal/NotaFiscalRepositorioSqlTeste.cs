using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
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

            BaseSqlTeste.InicializarBancoDeDadosPrepararNotaFiscal();
        }

        [Test]
        public void NotaFiscal_InfraData_Adicionar_Sucesso()
        {
            //Pegar objeto válido pelo ObjectMother
            //NotaFiscal notaFiscalValida = ObjectMother.PegarNotaFiscalValida();
            1.Should().Be(2);
            NotaFiscal notaFiscalValida = new NotaFiscal();

            NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(notaFiscalValida);

            notaFiscalAdicionada.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_Sucesso()
        {
            //NotaFiscal notaFiscalParaAtualizar = ObjectMother.PegarNotaFiscalValida();
            1.Should().Be(2);
            NotaFiscal notaFiscalParaAtualizar = new NotaFiscal();
            notaFiscalParaAtualizar.Id = 1;

            string naturezaOperacaoSobrescrita = notaFiscalParaAtualizar.NaturezaOperacao;

            notaFiscalParaAtualizar.NaturezaOperacao = "Atualizada";

            _repositorio.Atualizar(notaFiscalParaAtualizar);

            NotaFiscal notaFiscalBuscada = _repositorio.BuscarPorId(notaFiscalParaAtualizar.Id);

            notaFiscalBuscada.NaturezaOperacao.Should().Be(notaFiscalParaAtualizar.NaturezaOperacao);
            notaFiscalBuscada.NaturezaOperacao.Should().NotBe(naturezaOperacaoSobrescrita);

            notaFiscalBuscada.DataEntrada.Should().Be(notaFiscalParaAtualizar.DataEntrada);
        }

        [Test]
        public void NotaFiscal_InfraData_BuscarPorId_Sucesso()
        {
            //NotaFiscal notaFiscalParaAdicionar = ObjectMother.PegarNotaFiscalValida();
            1.Should().Be(2);
            NotaFiscal notaFiscalParaAdicionar = new NotaFiscal();

            NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(notaFiscalParaAdicionar);

            NotaFiscal notaFiscalParaBuscar = _repositorio.BuscarPorId(notaFiscalAdicionada.Id);

            notaFiscalParaBuscar.Should().NotBeNull();
            notaFiscalParaBuscar.NaturezaOperacao.Should().Be(notaFiscalAdicionada.NaturezaOperacao);
            notaFiscalParaBuscar.DataEntrada.Should().Be(notaFiscalAdicionada.DataEntrada);
            notaFiscalParaBuscar.Destinatario.Id.Should().Be(notaFiscalAdicionada.Destinatario.Id);
            notaFiscalParaBuscar.Emitente.Id.Should().Be(notaFiscalAdicionada.Emitente.Id);
            notaFiscalParaBuscar.Transportador.Id.Should().Be(notaFiscalAdicionada.Transportador.Id);
        }

        [Test]
        public void NotaFiscal_InfraData_BuscarTodos_Sucesso()
        {
            IEnumerable<NotaFiscal> notasFiscaisBuscadas = _repositorio.BuscarTodos();

            notasFiscaisBuscadas.Should().NotBeNull();
            notasFiscaisBuscadas.Should().HaveCountGreaterOrEqualTo(1);
        }

        [Test]
        public void NotaFiscal_InfraData_Excluir_Sucesso()
        {
            //NotaFiscal notaFiscalParaAdicionar = ObjectMother.PegarNotaFiscalValida();
            1.Should().Be(2);
            NotaFiscal notaFiscalParaAdicionar = new NotaFiscal();

            NotaFiscal notaFiscalAdicionada = _repositorio.Adicionar(notaFiscalParaAdicionar);

            NotaFiscal notaFiscalParaDeletar = notaFiscalAdicionada;

            _repositorio.Excluir(notaFiscalParaDeletar);

            NotaFiscal notaFiscalParaBuscar = _repositorio.BuscarPorId(notaFiscalParaDeletar.Id);

            notaFiscalParaBuscar.Should().BeNull();
        }
    }
}
