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

namespace GeradorDeTestes.WinApp.IoC
{
    public static class IOCgerenciadorFormulario
    {
        private static GerenciadorFormulario _gerenciadorFormulario;
        private static DisciplinaGerenciadorFormulario _disciplinaGerenciadorFormulario;
        private static MateriaGerenciadorFormulario _materiaGerenciadorFormulario;
        private static QuestaoGerenciadorFormulario _questaoGerenciadorFormulario;
        private static SerieGerenciadorFormulario _serieGerenciadorFormulario;
        private static TesteGerenciadorFormulario _testeGerenciadorFormulario;

        public static GerenciadorFormulario GerenciadorFormulario
        {
            get
            {
                return _gerenciadorFormulario;
            }
            set
            {
                _gerenciadorFormulario = value;
            }
        }

        public static DisciplinaGerenciadorFormulario DisciplinaGerenciadorFormulario
        {
            get
            {
                if (_disciplinaGerenciadorFormulario == null)
                {
                    return _disciplinaGerenciadorFormulario = new DisciplinaGerenciadorFormulario();
                }
                else
                {
                    return _disciplinaGerenciadorFormulario;
                }
            }
        }
        public static MateriaGerenciadorFormulario MateriaGerenciadorFormulario
        {
            get
            {
                if (_materiaGerenciadorFormulario == null)
                {
                    return _materiaGerenciadorFormulario = new MateriaGerenciadorFormulario();
                }
                else
                {
                    return _materiaGerenciadorFormulario;
                }
            }
        }
        public static QuestaoGerenciadorFormulario QuestaoGerenciadorFormulario
        {
            get
            {
                if (_questaoGerenciadorFormulario == null)
                {
                    return _questaoGerenciadorFormulario = new QuestaoGerenciadorFormulario();
                }
                else
                {
                    return _questaoGerenciadorFormulario;
                }
            }
        }
        public static SerieGerenciadorFormulario SerieGerenciadorFormulario
        {
            get
            {
                if (_serieGerenciadorFormulario == null)
                {
                    return _serieGerenciadorFormulario = new SerieGerenciadorFormulario();
                }
                else
                {
                    return _serieGerenciadorFormulario;
                }
            }
        }
        public static TesteGerenciadorFormulario TesteGerenciadorFormulario
        {
            get
            {
                if (_testeGerenciadorFormulario == null)
                {
                    return _testeGerenciadorFormulario = new TesteGerenciadorFormulario();
                }
                else
                {
                    return _testeGerenciadorFormulario;
                }
            }
        }
    }
}
