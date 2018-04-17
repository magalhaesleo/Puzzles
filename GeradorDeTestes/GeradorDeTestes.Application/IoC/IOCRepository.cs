using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Application.IoC
{
    public static class IOCRepository
    {
        #region atributos e propriedades RepositoryS
     
        private static AlternativaRepository _alternativaRepository;
        private static DisciplinaRepository _disciplinaRepository;
        private static QuestaoRepository _questaoRepository;
        private static MateriaRepository _materiaRepository;
        private static SerieRepository _serieRepository;
        private static TesteRepository _testeRepository;


        public static AlternativaRepository AlternativaRepository
        {
            get
            {
                if (_alternativaRepository == null)
                {
                    return _alternativaRepository=  new AlternativaRepository();
                }
                else
                {
                    return _alternativaRepository;
                }
            }
        }
        public static DisciplinaRepository DisciplinaRepository
        {
            get
            {
                if (_disciplinaRepository == null)
                {
                    return _disciplinaRepository = new DisciplinaRepository();
                }
                else
                {
                    return _disciplinaRepository;
                }
            }
        }
        public static MateriaRepository MateriaRepository
        {
            get
            {
                if (_materiaRepository == null)
                {
                    return _materiaRepository = new MateriaRepository();
                }
                else
                {
                    return _materiaRepository;
                }
            }
        }
        public static SerieRepository SerieRepository
        {
            get
            {
                if (_serieRepository == null)
                {
                    return _serieRepository = new SerieRepository();
                }
                else
                {
                    return _serieRepository;
                }
            }
        }
        public static TesteRepository TesteRepository
        {
            get
            {
                if (_testeRepository == null)
                {
                    return _testeRepository = new TesteRepository();
                }
                else
                {
                    return _testeRepository;
                }
            }
        }
        public static QuestaoRepository QuestaoRepository
        {
            get
            {
                if (_questaoRepository == null)
                {
                    return _questaoRepository = new QuestaoRepository();
                }
                else
                {
                    return _questaoRepository;
                }
            }
        }

        #endregion
        
    }
}
