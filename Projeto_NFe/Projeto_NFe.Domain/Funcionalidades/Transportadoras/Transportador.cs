using Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Base;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras
{
    public class Transportador : Entidade
    {
        public string NomeRazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool ResponsabilidadeFrete { get; set; }
        public Endereco Endereco { get; set; }
        public IDocumento Documento { get; set; }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(NomeRazaoSocial))
                throw new ExcecaoTransportadorSemNome();

            if (Documento == null)
                throw new ExcecaoTransportadorSemDocumento();

            if (Documento.ObterTipo() == "CNPJ")
            {
                if (string.IsNullOrEmpty(InscricaoEstadual))
                    throw new ExcecaoTransportadorComInscricaoEstadualNula();

                if (InscricaoEstadual.Length > 15)
                    throw new ExcecaoTransportadorComInscricaoEstadualAcimaDoLimite();
            }

            if (Endereco == null)
                throw new ExcecaoTransportadorSemEndereco();

            Endereco.Validar();

            Documento.Validar();
        }
    }
}
