using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Materia
    {
        private int _id;
        private string _nome;
        private Disciplina _disciplina;
        private Serie _serie;

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nome { get { return this._nome; } set { this._nome = value; } }
        public Disciplina Disciplina { get { return this._disciplina; } set { this._disciplina = value; } }
        public Serie Serie { get { return _serie;  } set { _serie = value;  } }


        public Materia()
        {
        }

        public Materia(string nome, Disciplina disciplina, Serie serie)
        {
            this.Nome = nome;
            this.Disciplina = disciplina;
        }

        public void Validate()
        {
            if (Nome.Length < 4 || String.IsNullOrEmpty(Nome))
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");

            if ((char.IsNumber(Nome[0])))  
                throw new Exception("O nome não deve iniciar com números ou conter apenas números!");

            if (Regex.IsMatch(Nome[0].ToString(), (@"[!""#$%&'()*+,-./:;?@[\\\]_`{|}~]")))
            {
                throw new Exception("O nome não deve iniciar com um caracter especial");
            }
        }

        public override string ToString()
        {
            return String.Format("Matéria: {0} - Disciplina: {1} - Serie: {2}", Nome, Disciplina.Nome, Serie.Numero);
        }



    }
}
