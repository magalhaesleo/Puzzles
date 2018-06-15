﻿using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalEmitidaRepositorioSqlTeste
    {

        private NotaFiscalEmitidaRepositorioSql _repositorio;

        private NotaFiscal _notaFiscalValida;

        private NotaFiscalRepositorioXML _notaFiscalRepositorioXML;

        //Repositórios de dependências
        private DestinatarioRepositorioSql _destinatarioRepositorio;
        private EmitenteRepositorioSql _emitenteRepositorio;
        private TransportadorRepositorioSql _transportadorRepositorio;
        private ProdutoNotaFiscalRepositorioSql _produtoNotaFiscalRepositorioSql;

        [SetUp]
        public void IniciarCenario()
        {
            _repositorio = new NotaFiscalEmitidaRepositorioSql();

            _notaFiscalRepositorioXML = new NotaFiscalRepositorioXML();

            _destinatarioRepositorio = new DestinatarioRepositorioSql();
            _emitenteRepositorio = new EmitenteRepositorioSql();
            _transportadorRepositorio = new TransportadorRepositorioSql();
            _produtoNotaFiscalRepositorioSql = new ProdutoNotaFiscalRepositorioSql();

            BaseSqlTeste.InicializarBancoDeDadosPrepararNotaFiscalEmitida();

            long idEmitenteCadastradoPorBaseSql = 1;
            long idDestinatarioCadastradoPorBaseSql = 1;
            long idTransportadorCadastradoPorBaseSql = 1;
            long idProdutoNotaFiscalCadastradorPorBaseSql = 1;

            _notaFiscalValida = ObjectMother.PegarNotaFiscalValidaComIdDasDependencias(idEmitenteCadastradoPorBaseSql, idDestinatarioCadastradoPorBaseSql, idTransportadorCadastradoPorBaseSql);
            _notaFiscalValida.Destinatario = _destinatarioRepositorio.BuscarPorId(idDestinatarioCadastradoPorBaseSql);
            _notaFiscalValida.Emitente = _emitenteRepositorio.BuscarPorId(idEmitenteCadastradoPorBaseSql);
            _notaFiscalValida.Transportador = _transportadorRepositorio.BuscarPorId(idTransportadorCadastradoPorBaseSql);
            _notaFiscalValida.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscalValida.Produtos.Add(_produtoNotaFiscalRepositorioSql.BuscarPorId(idProdutoNotaFiscalCadastradorPorBaseSql));

            _notaFiscalValida.ValidarGeracao();
            _notaFiscalValida.ValidarParaEmitir();
            _notaFiscalValida.CalcularValoresTotais();
            _notaFiscalValida.GerarChaveDeAcesso(new Random());
            _notaFiscalValida.DataEmissao = DateTime.Now;
        }

        [Test]
        public void NotaFiscal_Emitida_InfraData_Adicionar_Sucesso()
        {
            _repositorio.Adicionar(_notaFiscalRepositorioXML.Serializar(_notaFiscalValida), _notaFiscalValida.ChaveAcesso);
        }


    }
}
