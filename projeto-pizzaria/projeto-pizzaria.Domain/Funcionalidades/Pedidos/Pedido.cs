﻿using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Clientes;
using projeto_pizzaria.Domain.Funcionalidades.Clientes.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Pedidos.Excecoes;
using projeto_pizzaria.Domain.Funcionalidades.Produtos;
using projeto_pizzaria.Infra.Extensao;
using projeto_pizzaria.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Pedidos
{
    public class Pedido : Entidade
    {
        public DateTime Data { get; set; }

        public virtual Cliente Cliente { get; set; }

        public List<Produto> Produtos { get; set; }

        public StatusPedido Status { get; set; }

        public double ValorTotal
        {
            get
            {
                return CalcularValorTotal();
            }
            set
            {
                
            }
        }

        public FormaPagamentoPedido? FormaPagamento { get; set; }

        public bool EmitirNota { get; set; }

        public string Responsavel { get; set; }

        public string Departamento { get; set; }

        public virtual IDocumento DocumentoCliente
        {
            get { return Cliente.Documento; }
        }

        public Pedido()
        {
            Status = StatusPedido.AGUARDANDO_MONTAGEM;
            Data = DateTime.Now;
            Produtos = new List<Produto>();
        }

        private double CalcularValorTotal()
        {
            double valorTotal = 0;

            foreach (Produto produto in Produtos)
            {
                valorTotal += produto.Valor * produto.Quantidade;
            }

            return valorTotal;
        }

        public void AtualizarStatus()
        {
            //Utilizando Método de Extensão
            if (!Status.Equals(StatusPedido.ENTREGUE))
                Status = Status.Next();
        }

        public void Realizar()
        {
            this.Validar();

            this.Status = StatusPedido.AGUARDANDO_MONTAGEM;
        }

        public void Validar()
        {
            if (Cliente == null)
                throw new PedidoSemClienteExcecao();

            if (Produtos.Count == 0)
                throw new PedidoSemProdutosExcecao();

            if (FormaPagamento == null)
                throw new PedidoSemFormaDePagamentoExcecao();

            if (ValorTotal <= 0)
                throw new PedidoComValorTotalZeroOuNegativoExcecao();

            if (EmitirNota)
            {
                if (DocumentoCliente == null)
                    throw new PedidoComClienteSemDocumentoExcecao();
                else
                {
                    if (DocumentoCliente.ObterTipo().Equals("CNPJ"))
                    {
                        if (string.IsNullOrEmpty(Departamento) || string.IsNullOrEmpty(Responsavel))
                        {
                            throw new PedidoParaEmpresaEmitindoNotaSemDepartamentoOuResponsavelExcecao();
                        }
                    }
                }
            }
        }
    }
}
