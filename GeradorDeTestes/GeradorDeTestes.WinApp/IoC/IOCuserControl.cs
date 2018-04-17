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
    public static class IOCuserControl
    {
        #region e instâncias User Controls
        private static DisciplinaControl _disciplinaControl;
        private static QuestaoControl _questaoControl;
        private static SerieControl _serieControl;
        private static TesteControl _testeControl;
        private static MateriaControl _materiaControl;

        public static DisciplinaControl DisciplinaControl
        {
            get
            {
                if (_disciplinaControl == null)
                {
                    return _disciplinaControl = new DisciplinaControl();

                }
                else
                {
                    return _disciplinaControl;
                }
            }
        }


        public static QuestaoControl QuestaoControl
        {
            get
            {
                if (_questaoControl == null)
                {
                    return _questaoControl = new QuestaoControl();

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
                    _serieControl = new SerieControl();
                    return _serieControl;
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
                    _testeControl = new TesteControl();
                    return _testeControl;
                }
                else
                {
                    return _testeControl;
                }
            }
        }


        public static MateriaControl MateriaControl
        {
            get
            {
                if (_materiaControl == null)
                {
                    _materiaControl = new MateriaControl();
                    return _materiaControl;
                }
                else
                {
                    return _materiaControl;
                }
            }
        }

        #endregion
    }
}
