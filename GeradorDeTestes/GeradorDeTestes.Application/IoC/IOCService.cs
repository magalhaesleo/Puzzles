using GeradorDeTestes.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Application.IoC
{
   public static class IOCService
    {
        #region
        private static AlternativaService _alternativaService;
        private static DisciplinaService _disciplinaService;
        private static QuestaoService _questaoService;
        private static MateriaService _materiaService;
        private static SerieService _serieService;
        private static TesteService _testeService;

        public static AlternativaService AlternativaService
        {
            get
            {
                if (_alternativaService == null)
                {
                    return new AlternativaService();
                }
                else
                {
                    return _alternativaService;
                }
            }
        }
        public static DisciplinaService DisciplinaService
        {
            get
            {
                if (_disciplinaService == null)
                {
                    return new DisciplinaService();
                }
                else
                {
                    return _disciplinaService;
                }
            }
        }
        public static QuestaoService QuestaoService
        {
            get
            {
                if (_questaoService == null)
                {
                    return new QuestaoService();
                }
                else
                {
                    return _questaoService;
                }
            }
        }
        public static MateriaService MateriaService
        {
            get
            {
                if (_materiaService == null)
                {
                    return new MateriaService();
                }
                else
                {
                    return _materiaService;
                }
            }
        }
        public static SerieService SerieService
        {
            get
            {
                if (_serieService == null)
                {
                    return new SerieService();
                }
                else
                {
                    return _serieService;
                }
            }
        }
        public static TesteService TesteService
        {
            get
            {
                if (_testeService == null)
                {
                    return new TesteService();
                }
                else
                {
                    return _testeService;
                }
            }
        }
        #endregion
    }
}
