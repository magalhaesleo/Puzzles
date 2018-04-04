using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Disciplina
    {
        private int _id;
        private string _nome;

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nome { get { return this._nome; } set { this._nome = value; } }



        public Disciplina()
        {

        }

        public Disciplina(string nome)
        {
            this.Nome = nome;
        }

        public void Validate()
        {
            if (Nome.Contains("  "))
                throw new Exception("O nome não deve possuir mais que um espaço consecutivos.");

            if (Nome.Length < 4)
            {
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");
            }

            if (Nome.Length > 25)
            {
                throw new Exception("O nome deve ter no máximo 25 caracteres.");
            }

            if (String.IsNullOrEmpty(Nome) || Nome.Trim() == "")
            {
                throw new Exception("O nome não pode ser em branco.");
            }

            if (Regex.IsMatch(Nome, (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
            {
                throw new Exception("O nome da disciplina não pode conter caracteres especiais!");
            }

            if ((char.IsNumber(Nome[0])))
                throw new Exception("O nome não deve iniciar com números ou conter apenas números!");

            if (!Regex.IsMatch(Nome, @"^[ a-zA-Z áãõêí]*$"))
                throw new Exception("O nome não deve conter números!");
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} ", Nome);
        }

    }
}
