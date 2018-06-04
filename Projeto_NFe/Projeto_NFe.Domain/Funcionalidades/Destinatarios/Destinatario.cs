using Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes;
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
    public class Destinatario
    {
        public String NomeRazaoSocial { get; set; }

        public IDocumento Documento { get; set; }

        public string TipoDeDocumento
        {
            get
            {
                if (Documento.GetType() == typeof(CNPJ))
                {
                    return "CNPJ";
                }
                else
                {
                    return "CPF";
                }

            }
        }

        public string IncricaoEstadual { get; set; }
        public void Validar()
        {
            if (String.IsNullOrEmpty(NomeRazaoSocial))
                throw new ExcecaoDestinatarioSemNome();

            if (Documento == null)
                throw new ExcecaoDestinatarioSemDocumento();

            if (TipoDeDocumento == "CNPJ")
            {
                if (IncricaoEstadual.Length > 15)
                    throw new ExcecaoDestinatarioComInscricaoEstadualAcimaDoLimite();

                if (IncricaoEstadual.Length < 15)
                    throw new ExcecaoDestinatarioComInscricaoEstadualAbaixoDoLimite();
            }

            Documento.Validar();
        }

        
    }
}
