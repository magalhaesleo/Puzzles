using GeradorDeTestes.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Application.IoC
{
    public static class IOCdao
    {
        #region atributos e propriedades DAOS
     
        private static AlternativaDAO _alternativaDao;
        private static DisciplinaDAO _disciplinaDAO;
        private static QuestaoDAO _questaoDAO;
        private static MateriaDAO _materiaDAO;
        private static SerieDAO _serieDAO;
        private static TesteDAO _testeDAO;


        public static AlternativaDAO AlternativaDAO
        {
            get
            {
                if (_alternativaDao == null)
                {
                    return new AlternativaDAO();
                }
                else
                {
                    return _alternativaDao;
                }
            }
        }
        public static DisciplinaDAO DisciplinaDAO
        {
            get
            {
                if (_disciplinaDAO == null)
                {
                    return new DisciplinaDAO();
                }
                else
                {
                    return _disciplinaDAO;
                }
            }
        }
        public static MateriaDAO MateriaDAO
        {
            get
            {
                if (_materiaDAO == null)
                {
                    return new MateriaDAO();
                }
                else
                {
                    return _materiaDAO;
                }
            }
        }
        public static SerieDAO SerieDAO
        {
            get
            {
                if (_serieDAO == null)
                {
                    return new SerieDAO();
                }
                else
                {
                    return _serieDAO;
                }
            }
        }
        public static TesteDAO TesteDAO
        {
            get
            {
                if (_testeDAO == null)
                {
                    return new TesteDAO();
                }
                else
                {
                    return _testeDAO;
                }
            }
        }
        public static QuestaoDAO QuestaoDAO
        {
            get
            {
                if (_questaoDAO == null)
                {
                    return new QuestaoDAO();
                }
                else
                {
                    return _questaoDAO;
                }
            }
        }

        #endregion
        
    }
}
