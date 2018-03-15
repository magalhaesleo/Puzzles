using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain
{
    public class Disciplina
    {

        public string nome;

        //public List<Materia> listaMaterias;

        public Disciplina(string nome)
        {
            this.nome = nome;
        }

        public void Validate()
        {
            if (nome.Length < 4 || String.IsNullOrEmpty(nome))
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");         
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} ", nome);
        }

    }
}
