using projeto_pizzaria.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizzaria.Infra.Objetos_de_Valor.CNPJs
{
    public class CNPJ : IDocumento
    {
        private string _numero;
        public string Numero
        {
            get
            {
                string num = _numero.Trim();
                num = _numero.Replace(".", "").Replace("-", "").Replace("/", "");
                return num;
            }
        }
        public string NumeroComPontuacao
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
            }
        }

        public virtual string ObterTipo()
        {
            return "CNPJ";
        }

        public virtual void Validar()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            if (Numero.Length != 14)
                throw new ExcecaoCNPJNaoPossuiQuatorzeNumeros();

            if (Numero == "00000000000000" || Numero == "11111111111111" ||
                Numero == "22222222222222" || Numero == "33333333333333" ||
                Numero == "44444444444444" || Numero == "55555555555555" ||
                Numero == "66666666666666" || Numero == "77777777777777" ||
                Numero == "88888888888888" || Numero == "99999999999999")
            {
                throw new ExcecaoNumeroCNPJInvalido();
            }

            tempCnpj = Numero.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            if (Numero.EndsWith(digito) == false)
                throw new ExcecaoNumeroCNPJInvalido();
        }

    }
}
