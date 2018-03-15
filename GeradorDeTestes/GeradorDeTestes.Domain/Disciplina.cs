using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain
{
    public class Disciplina
    {
        private int _id;
        private string _nome;

        public int Id { get { return this._id; } set { this._id = value; } }
        public string Nome { get { return this._nome; } set { this._nome = value; } }

        //public List<Materia> listaMaterias;

        public Disciplina(string nome)
        {
            this.Nome = nome;
        }

        public void Validate()
        {
            if (Nome.Length < 4 || String.IsNullOrEmpty(Nome))
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} ", Nome);
        }

    }
}
