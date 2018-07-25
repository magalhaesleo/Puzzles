using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ws_banco_tabajara.Domain.Funcionalidades.Movimentacoes;
using ws_banco_tabajara.Infra.ORM.Contextos;
using ws_banco_tabajara.Infra.ORM.Funcionalidades.Movimentacoes;

namespace ws_banco_tabajara.Infra.ORM.Tests.Funcionalidades.Movimentacoes
{
    [TestFixture]
    public class MovimentacaoRepositorioSQLTeste
    {
        private MovimentacaoRepositorioSQL _repositorio;
        private ContextoBancoTabajara _contexto;

        private Movimentacao _movimentacao;

        [SetUp]
        public void IniciarCenario()
        {
            _contexto = new ContextoBancoTabajara();

            Database.SetInitializer(new BaseSQLTeste());
            _contexto.Database.Initialize(true);

            _repositorio = new MovimentacaoRepositorioSQL(_contexto);

            _movimentacao = ObjectMother.ObterMovimentacaoValido();
        }

        [Test]
        public void Movimentacao_InfraData_Adicionar_Sucesso()
        {
            _repositorio.Adicionar(_movimentacao);

            _movimentacao.Id.Should().BeGreaterThan(0);

            _repositorio.BuscarPorId(_movimentacao.Id).Should().Be(_movimentacao);
        }
    }
}
