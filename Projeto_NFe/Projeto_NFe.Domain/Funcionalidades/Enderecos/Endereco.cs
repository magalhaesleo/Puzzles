using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Enderecos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public virtual void Validar()
        {
            if (String.IsNullOrEmpty(Bairro))
                throw new ExcecaoEnderecoSemBairro();

            if (String.IsNullOrEmpty(Municipio))
                throw new ExcecaoEnderecoSemMunicipio();

            if (String.IsNullOrEmpty(Pais))
                throw new ExcecaoEnderecoSemPais();

            if (String.IsNullOrEmpty(Estado))
                throw new ExcecaoEnderecoSemEstado();

            if (String.IsNullOrEmpty(Logradouro))
                throw new ExcecaoEnderecoSemLogradouro();

            if (Numero == 0)
                throw new ExcecaoEnderecoSemNumero();
        }
    }
}
