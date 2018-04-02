using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Alternativa
    {

        private int _id;
        private string _enunciado;
        private bool _correta;
        private Letra letra;

        public int Id { get => _id; set => _id = value; }
        public bool Correta { get => _correta; set => _correta = value; }
        public Letra Letra { get => letra; set => letra = value; }
        public string Enunciado { get => _enunciado; set => _enunciado = value; }

        public void Validate()
        {
            if (Enunciado.Contains("  "))
                throw new Exception("O enunciado não deve possuir mais que um espaço consecutivos.");

            if (Enunciado.Length > 100)
                throw new Exception("A alternativa deve ter no máximo 100 caracteres.");

            //Trim() retira todos os espaços em branco do nome para que não seja aceito nomes com apenas espaços
            if (String.IsNullOrEmpty(Enunciado) || Enunciado.Trim() == "")
                throw new Exception("O nome não pode ser em branco.");

        }

    }

    public enum Letra
    {
        a, b, c, d, e
    };
}
