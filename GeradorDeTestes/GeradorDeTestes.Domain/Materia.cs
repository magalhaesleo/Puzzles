using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain
{
    public class Materia
    {
        private int _id;
        private string _nome;
        private Disciplina _disciplina;

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nome { get { return this._nome; } set { this._nome = value; } }
        public Disciplina Disciplina { get { return this._disciplina; } set { this._disciplina = value; } }

        public Materia(string nome, Disciplina disciplina)
        {
            this.Nome = nome;
            this.Disciplina = disciplina;
        }

        public void Validate()
        {
            if (Nome.Length < 4 || String.IsNullOrEmpty(Nome))
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");
        }

        public override string ToString()
        {
            return String.Format("Matéria: {0}; Disciplina: {1}", Nome, Disciplina.Nome);
        }



    }
}
