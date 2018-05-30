using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes
{
    public class Emitente : Entidade
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public CNPJ CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public Endereco Endereco { get; set; }
        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(NomeFantasia))
                throw new ExcecaoEmitenteSemNome();

            if (NomeFantasia.Length < 5)
                throw new ExcecaoNomeEmitentePequeno();

            if (string.IsNullOrEmpty(RazaoSocial))
                throw new ExcecaoEmitenteSemRazaoSocial();

            if (RazaoSocial.Length < 5)
                throw new ExcecaoRazaoSocialEmitentePequeno();

            if (CNPJ == null)
                throw new ExcecaoEmitenteSemCNPJ();

            if (string.IsNullOrEmpty(InscricaoEstadual))
                throw new ExcecaoEmitenteSemInscricaoEstadual();

            if (!InscricaoEstadual.All(char.IsDigit))
                throw new ExcecaoInscricacaoEstadualEmitenteComLetras();

            if (InscricaoEstadual.Length != 9)
                throw new ExcecaoEmitenteComInscricaoEstadualInvalida();

            if (string.IsNullOrEmpty(InscricaoMunicipal))
                throw new ExcecaoEmitenteSemInscricaoMunicipal();

            if (!InscricaoMunicipal.All(char.IsDigit))
                throw new ExcecaoInscricacaoMunicipalEmitenteComLetras();

            if (Endereco == null)
                throw new ExcecaoEmitenteSemEndereco();

        }
    }
}
