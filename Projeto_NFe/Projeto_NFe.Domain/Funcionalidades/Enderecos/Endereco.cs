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
        public void Validar()
        {
            if (String.IsNullOrEmpty(Bairro))
                throw new ExcecaoEnderecoSemBairro();
        }
    }
}
