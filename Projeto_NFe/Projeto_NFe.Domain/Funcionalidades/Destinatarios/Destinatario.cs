﻿using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Interfaces;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios
{
    public class Destinatario : Entidade
    {
        public String NomeRazaoSocial { get; set; }

        public virtual IDocumento Documento { get; set; }

        public string InscricaoEstadual { get ; set; }

        public Endereco Endereco { get; set; }


        public virtual void Validar()
        {
            if (String.IsNullOrEmpty(NomeRazaoSocial))
                throw new ExcecaoDestinatarioSemNome();

            if (Documento == null)
                throw new ExcecaoDestinatarioSemDocumento();

            if (Documento.ObterTipo() == "CNPJ")
            {
                if (String.IsNullOrEmpty(InscricaoEstadual))
                    throw new ExcecaoDestinatarioComInscricaoEstadualNula();

                if (InscricaoEstadual.Length > 15)
                    throw new ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite();
            }

            if (Endereco == null)
                throw new ExcecaoDestinatarioSemEndereco();

            Endereco.Validar();

            Documento.Validar();
        }

        
    }
}
