using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public Disciplina()
        {

        }

        public Disciplina(string nome)
        {
            this.Nome = nome;
        }

        public void Validate()
        {
            if (Nome.Length < 4 )
                throw new Exception("O nome deve ter pelo menos quatro caracteres.");
            if (String.IsNullOrEmpty(Nome))
                throw new Exception("O nome não pode ser em branco.");
            if (Nome.Length > 15)
                throw new Exception("O nome não pode ultrapassar 15 caracteres.");
            if (Nome.All(char.IsDigit) == true)
                throw new Exception("Não pode conter numeros!");
            if (Nome.All(char.IsDigit) == true)
                throw new Exception("Não pode conter numeros!");

            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (regexItem.IsMatch(Nome))
                throw new Exception("Não pode conter caracteres especiais!");
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} ", Nome);
        }

    }
}
