using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Domain.Entidades
{
    public class Teste
    {
        private int _id;
        private string _nome;
        private int _numeroQuestoes;
        private DateTime _dataGeracao;
        private Materia _materia;

        public int Id { get => this._id; set => this._id = value; }
        public string Nome { get => this._nome; set => this._nome = value; }
        public int NumeroQuestoes { get => this._numeroQuestoes; set => this._numeroQuestoes = value; }
        public DateTime DataGeracao { get => this._dataGeracao; set => this._dataGeracao = value; }
        public Materia Materia { get => this._materia; set => this._materia = value; }

        public Teste()
        {

        }

        public void Validar()
        {
            if (DataGeracao < DateTime.Now)
            {
                throw new InvalidTimeZoneException("A data de geração não deve ser menor que a data atual");
            }
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
