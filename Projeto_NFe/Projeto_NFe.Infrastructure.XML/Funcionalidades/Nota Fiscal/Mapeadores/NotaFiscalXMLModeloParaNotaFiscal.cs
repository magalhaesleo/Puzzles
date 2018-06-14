﻿using NFe.Infra.XML.Features.NotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal.Mapeadores
{
    public class NotaFiscalXMLModeloParaNotaFiscal
    {
        public NotaFiscal MontarNotaFiscal(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            NotaFiscal notaFiscal = new NotaFiscal();

            notaFiscal.ChaveAcesso = notaFiscalModeloXml.infNFe.ChaveAcesso;
            notaFiscal.Destinatario = MontarEntidadeDestinatario(notaFiscalModeloXml);
            notaFiscal.Emitente = MontarEntidadeEmitente(notaFiscalModeloXml);
            notaFiscal.Transportador = MontarEntidadeTransportador(notaFiscalModeloXml);
            throw new Exception("nao terminamos");
        }

        private static Transportador MontarEntidadeTransportador(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            Transportador transportador = new Transportador();

            if (notaFiscalModeloXml.infNFe.transp.Transporta.CnpjDestinatario.Length > 0)
            {
                CNPJ cnpj = new CNPJ();

                cnpj.NumeroComPontuacao = notaFiscalModeloXml.infNFe.transp.Transporta.CnpjDestinatario;
                transportador.Documento = cnpj;
            }
            else
            {
                CPF cpf = new CPF();

                cpf.NumeroComPontuacao = notaFiscalModeloXml.infNFe.transp.Transporta.CnpjDestinatario;
                transportador.Documento = cpf;
            }
            transportador.Endereco = MontarEnderecoTransportador(notaFiscalModeloXml);
            throw new Exception("nao terminamos");
        }

        private static Endereco MontarEnderecoTransportador(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            throw new Exception("nao terminamos");
        }

        private static Emitente MontarEntidadeEmitente(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            Emitente emitente = new Emitente();

            emitente.CNPJ = new CNPJ();
            emitente.CNPJ.NumeroComPontuacao = notaFiscalModeloXml.infNFe.emit.CnpjEmitente;
            emitente.Endereco = MontarEnderecoEmitente(notaFiscalModeloXml);
            emitente.InscricaoEstadual = notaFiscalModeloXml.infNFe.emit.InscricaoEstadual;
            emitente.InscricaoMunicipal = notaFiscalModeloXml.infNFe.emit.InscricaoMunicipal;
            emitente.NomeFantasia = notaFiscalModeloXml.infNFe.emit.Nome;
            emitente.RazaoSocial = notaFiscalModeloXml.infNFe.emit.RazaoSocial;

            return emitente;
        }

        private static Endereco MontarEnderecoEmitente(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            Endereco endereco = new Endereco();

            endereco.Numero = notaFiscalModeloXml.infNFe.emit.enderEmit.Numero;
            endereco.Bairro = notaFiscalModeloXml.infNFe.emit.enderEmit.Bairro;
            endereco.Municipio = notaFiscalModeloXml.infNFe.emit.enderEmit.Municipio;
            endereco.Logradouro = notaFiscalModeloXml.infNFe.emit.enderEmit.Logradouro;
            endereco.Estado = notaFiscalModeloXml.infNFe.emit.enderEmit.Estado;
            endereco.Pais = notaFiscalModeloXml.infNFe.emit.enderEmit.Pais;

            return endereco;
        }

        private static Destinatario MontarEntidadeDestinatario(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            Destinatario destinatario = new Destinatario();

            if(notaFiscalModeloXml.infNFe.dest.CnpjDestinatario.Length > 0)
            {
                CNPJ cnpj = new CNPJ();

                cnpj.NumeroComPontuacao = notaFiscalModeloXml.infNFe.dest.CnpjDestinatario;
                destinatario.Documento = cnpj;                
            }
            else
            {
                CPF cpf = new CPF();

                cpf.NumeroComPontuacao = notaFiscalModeloXml.infNFe.dest.CpfDestinatario;
                destinatario.Documento = cpf;
            }
            destinatario.InscricaoEstadual = notaFiscalModeloXml.infNFe.dest.InscricaoEstadual;
            destinatario.NomeRazaoSocial = notaFiscalModeloXml.infNFe.dest.Nome;
            destinatario.Endereco = MontarEnderecoDestinatario(notaFiscalModeloXml);

            return destinatario;
        }

        private static Endereco MontarEnderecoDestinatario(NotaFiscalModeloXml notaFiscalModeloXml)
        {
            Endereco endereco = new Endereco();

            endereco.Numero = notaFiscalModeloXml.infNFe.dest.enderDest.Numero;
            endereco.Bairro = notaFiscalModeloXml.infNFe.dest.enderDest.Bairro;
            endereco.Municipio = notaFiscalModeloXml.infNFe.dest.enderDest.Municipio;
            endereco.Logradouro = notaFiscalModeloXml.infNFe.dest.enderDest.Logradouro;
            endereco.Estado = notaFiscalModeloXml.infNFe.dest.enderDest.Estado;
            endereco.Pais = notaFiscalModeloXml.infNFe.dest.enderDest.Pais;

            return endereco;
        }
    }
}
