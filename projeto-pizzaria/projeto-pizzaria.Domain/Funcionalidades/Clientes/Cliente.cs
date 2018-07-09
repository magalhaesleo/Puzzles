using projeto_pizzaria.Domain.Base;
using projeto_pizzaria.Domain.Funcionalidades.Clientes.Excecoes;
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

        public DateTime DataNascimneto { get; set; }

        public virtual IDocumento Documento { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ClienteSemNomeExcecao();

            if (string.IsNullOrEmpty(Telefone))
                throw new ClienteSemTelefoneExcecao();

            if (Endereco == null)
                throw new ClienteSemEnderecoExcecao();
        }
    }
}
