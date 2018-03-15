using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain
{
    public class Materia
    {
        public string nome;

        public Disciplina disciplina;

        public Materia(string nome, Disciplina disciplina)
        {
            this.nome = nome;
            this.disciplina = disciplina;
        }

        public void Validate()
        {
            if (nome.Length < 4 || String.IsNullOrEmpty(nome))
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");
        }

        public override string ToString()
        {
            return String.Format("Matéria: {0}; Disciplina: {1}", nome, disciplina);
        }



    }
}
