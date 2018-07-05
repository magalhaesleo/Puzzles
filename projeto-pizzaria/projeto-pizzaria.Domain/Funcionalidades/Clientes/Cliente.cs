using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Enderecos;
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
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }
        public IDocumento Documento { get; set; }
        public void Validar()
        {
        }
    }
}
