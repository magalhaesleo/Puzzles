﻿using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
using projeto_pizzaria.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Clientes
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public Endereco Endereco { get; set; }

        public DateTime DataNascimento { get; set; }

        public IDocumento Documento { get; set; }

        public string TipoDeDocumento { get { return Documento.ObterTipo();  } set {} }

        public string NumeroDocumento { get { return Documento.NumeroComPontuacao; } set {} }

        public void Validar()
        {

        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - ID: {2}", this.Nome, this.Telefone, this.Id);
        }
    }
}
