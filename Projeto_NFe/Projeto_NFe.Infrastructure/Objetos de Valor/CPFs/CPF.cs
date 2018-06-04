using Projeto_NFe.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs
{
    public class CPF : IDocumentO
    {

        private string _numero;
        public string Numero
        {
            get
            {
                string num = _numero.Trim();
                num = _numero.Replace(".", "").Replace("-", "");
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

        public virtual void Validar()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (Numero == "00000000000" || Numero == "11111111111" ||
                Numero == "22222222222" || Numero == "33333333333" ||
                Numero == "44444444444" || Numero == "55555555555" ||
                Numero == "66666666666" || Numero == "77777777777" ||
                Numero == "88888888888" || Numero == "99999999999")
            {
                throw new ExcecaoNumeroCPFInvalido();
            }

            if (Numero.Length != 11)
                throw new ExcecaoCPFNaoPossuiOnzeNumeros();

            tempCpf = Numero.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            if (Numero.EndsWith(digito) == false)
                throw new ExcecaoNumeroCPFInvalido();
        }
    }
}
