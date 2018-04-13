using GeradorDeTestes.Domain.Abstract_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Teste : Entidade
    {
       
        private string _nome;
        private List<Questao> _listQuestoes;
        private DateTime _dataGeracao;
        private Materia _materia;
        private int _numeroQuestoes;

        public string Nome { get => this._nome; set => this._nome = value; }
        public List<Questao> Questoes { get => this._listQuestoes; set => this._listQuestoes = value; }
        public DateTime DataGeracao { get => this._dataGeracao; set => this._dataGeracao = value; }
        public Materia Materia { get => this._materia; set => this._materia = value; }

        public int NumeroDeQuestoes { get => this._numeroQuestoes; set => this._numeroQuestoes=value; }

        public Teste()
        {

        }

        public void Validar()
        {
           
            if (Materia == null)
            {
                throw new ArgumentNullException("A matéria deve ser selecionada");
            }
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} - Materia {1} - Data de Geração {2} ", Nome, Materia.Nome, DataGeracao);
        }
    }
}
