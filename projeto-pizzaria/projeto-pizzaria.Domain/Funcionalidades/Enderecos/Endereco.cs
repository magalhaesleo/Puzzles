using projeto_pizzaria.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Domain.Funcionalidades.Enderecos
{
    public class Endereco : Entidade
    {
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public virtual void Validar()
        {
            //if (String.IsNullOrEmpty(CEP))
            //    throw new EnderecoSemCEPExcecao();

            //if (String.IsNullOrEmpty(Cidade))
            //    throw new EnderecoSemCidadeExcecao();

            //if (String.IsNullOrEmpty(Bairro))
            //    throw new EnderecoSemBairroExcecao();

            //if (String.IsNullOrEmpty(Rua))
            //    throw new EnderecoSemRuaExcecao();

            //if (Numero == 0)
            //    throw new EnderecoSemNumeroExcecao();

            //if (String.IsNullOrEmpty(Complemento))
            //    throw new EnderecoSemComplementoExcecao();


        }
    }
}
