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

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nome { get { return this._nome; } set { this._nome = value; } }
        public Disciplina Disciplina { get { return this._disciplina; } set { this._disciplina = value; } }

        public Materia()
        {

        }

        public Materia(string nome, Disciplina disciplina)
        {
            this.Nome = nome;
            this.Disciplina = disciplina;
        }

        public void Validate()
        {
            if (Nome.Length < 4 || String.IsNullOrEmpty(Nome))
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");

            if ((char.IsNumber(Nome[0])))  
                throw new Exception("O nome não deve iniciar com números ou ser só números!");

            Regex regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            
            if (regexItem.IsMatch(Nome[0].ToString()))
                throw new Exception("O nome não pode possuir caracteres especiais!");

        }

        public override string ToString()
        {
            return String.Format("Matéria: {0}; Disciplina: {1}", Nome, Disciplina.Nome);
        }



    }
}
