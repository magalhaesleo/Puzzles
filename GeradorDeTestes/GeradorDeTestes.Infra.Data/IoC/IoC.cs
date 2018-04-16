using GeradorDeTestes.Applications;
using GeradorDeTestes.WinApp;
using GeradorDeTestes.WinApp.Features.DisciplinaModule;
using GeradorDeTestes.WinApp.Features.MateriaModule;
using GeradorDeTestes.WinApp.Features.QuestaoModule;
using GeradorDeTestes.WinApp.Features.SerieModule;
using GeradorDeTestes.WinApp.Features.TesteModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Infra.Data.IoC
{
   public static class IoC
    {
        #region atributos e propriedades DAOS
        private static AlternativaDAO _alternativaDao;
        private static DisciplinaDAO _disciplinaDAO;
        private static QuestaoDAO _questaoDAO;
        private static MateriaDAO _materiaDAO;
        private static SerieDAO _serieDAO;
        private static TesteDAO _testeDAO;


        public static AlternativaDAO AlternativaDAO { get {
                if (_alternativaDao == null)
                {
                    return new AlternativaDAO();
                }else
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
        public static SerieDAO serieDAO
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
        public static TesteDAO SerieDAO
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

        #region atributos e propriedades Services

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

        #region atributos e propriedades Gerenciador de Formulário

        private static DisciplinaGerenciadorFormulario _gerenciadorDisciplina;
        private static MateriaGerenciadorFormulario _gerenciadorMateria;
        private static SerieGerenciadorFormulario _gerenciadorSerie;
        private static QuestaoGerenciadorFormulario _gerenciadorQuestao;
        private static TesteGerenciadorFormulario _gerenciadorTeste;
        private static GerenciadorFormulario _gerenciadorFormulario;

        public static DisciplinaGerenciadorFormulario DisciplinaGerenciadorFormulario
        {
            get
            {
                if (_gerenciadorDisciplina == null)
                {
                    return new DisciplinaGerenciadorFormulario();
                }
                else
                {
                    return _gerenciadorDisciplina;
                }
            }
        }
        public static MateriaGerenciadorFormulario MateriaGerenciadorFormulario
        {
            get
            {
                if (_gerenciadorMateria == null)
                {
                    return new MateriaGerenciadorFormulario();
                }
                else
                {
                    return _gerenciadorMateria;
                }
            }
        }
        public static SerieGerenciadorFormulario SerieGerenciadorFormulario
        {
            get
            {
                if (_gerenciadorSerie == null)
                {
                    return new SerieGerenciadorFormulario();
                }
                else
                {
                    return _gerenciadorSerie;
                }
            }
        }
        public static QuestaoGerenciadorFormulario QuestaoGerenciadorFormulario
        {
            get
            {
                if (_gerenciadorQuestao == null)
                {
                    return new QuestaoGerenciadorFormulario();
                }
                else
                {
                    return _gerenciadorQuestao;
                }
            }
        }
        public static TesteGerenciadorFormulario TesteGerenciadorFormulario
        {
            get
            {
                if (_gerenciadorTeste == null)
                {
                    return new TesteGerenciadorFormulario();
                }
                else
                {
                    return _gerenciadorTeste;
                }
            }
        }
        public static GerenciadorFormulario GerenciadorFormulario
        {
            get
            {
               return _gerenciadorFormulario;
            }
        }

        #endregion

        #region atributos e propriedades UserControl

        private static DisciplinaControl _disciplinaControl;
        private static MateriaControl _materiaControl;
        private static QuestaoControl _questaoControl;
        private static SerieControl _serieControl;
        private static TesteControl _testeControl;

        public static DisciplinaControl DisciplinaControl
        {
            get
            {
                if (_disciplinaControl == null)
                {
                    return new DisciplinaControl();
                }
                else
                {
                    return _disciplinaControl;
                }
            }
        }
        public static MateriaControl MateriaControl
        {
            get
            {
                if (_materiaControl == null)
                {
                    return new MateriaControl();
                }
                else
                {
                    return _materiaControl;
                }
            }
        }
        public static QuestaoControl QuestaoControl
        {
            get
            {
                if (_questaoControl == null)
                {
                    return new QuestaoControl();
                }
                else
                {
                    return _questaoControl;
                }
            }
        }
        public static SerieControl SerieControl
        {
            get
            {
                if (_serieControl == null)
                {
                    return new SerieControl();
                }
                else
                {
                    return _serieControl;
                }
            }
        }
        public static TesteControl TesteControl
        {
            get
            {
                if (_testeControl == null)
                {
                    return new TesteControl();
                }
                else
                {
                    return _testeControl;
                }
            }
        }

        #endregion

        #region atributos e propriedades GerarPDF

        private static GeraPDF _gerarPDF;

        public static GeraPDF GeraPDF
        {
            get
            {
                if (_gerarPDF == null)
                {
                    return new GeraPDF();
                }
                else
                {
                    return _gerarPDF;
                }
            }
        }
        #endregion
    }
}
