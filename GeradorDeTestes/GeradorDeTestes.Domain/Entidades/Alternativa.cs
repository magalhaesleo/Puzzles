using GeradorDeTestes.Domain.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Alternativa : Entidade
    {
        
        private string _enunciado;
        private bool _correta;
        private Char letra;
        private int _idQuestao;
       
        public int IdQuestao { get => _idQuestao; set => _idQuestao = value; }
        public bool Correta { get => _correta; set => _correta = value; }
        public Char Letra { get => letra; set => letra = value; }
        public string Enunciado { get => _enunciado; set => _enunciado = value; }

        public Alternativa()
        {
        }

        public void Validate()
        {
            if (Enunciado.Contains("  "))
                throw new Exception("A alternativa não deve possuir dois ou mais espaços consecutivos.");

            if (Enunciado.Length > 100)
                throw new Exception("A alternativa deve ter no máximo 100 caracteres.");

            //Trim() retira todos os espaços em branco do nome para que não seja aceito nomes com apenas espaços
            if (String.IsNullOrEmpty(Enunciado) || Enunciado.Trim() == "")
                throw new Exception("A alternativa não pode ser em branco.");

        }

        public override string ToString()
        {
            return Letra + ") " + Enunciado;
        }

    }

   
}
