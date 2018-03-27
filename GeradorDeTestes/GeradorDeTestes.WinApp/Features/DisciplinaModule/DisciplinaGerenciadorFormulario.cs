﻿using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public class DisciplinaGerenciadorFormulario : GerenciadorFormulario
    {
        DisciplinaService _disciplinaService;
        DisciplinaControl _disciplinaControl;

        public DisciplinaGerenciadorFormulario()
        {
            _disciplinaService = new DisciplinaService();  
        }

        public override void Adicionar()
        {
            CadastroDisciplina dialogDisciplina = new CadastroDisciplina();

            DialogResult resultado = dialogDisciplina.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                try
                {
                    _disciplinaService.AdicionarDisciplina(dialogDisciplina.NovaDisciplina);
                    MessageBox.Show("Disciplina adicionada");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                AtualizarListagem();
            }
        }

        public override UserControl CarregarListControl()
        {
            if (_disciplinaControl == null)
                _disciplinaControl = new DisciplinaControl();
            AtualizarListagem();
            return _disciplinaControl;
        }

        public override void Excluir()
        {
            //_disciplinaService.ExcluirDisciplina(objeto as Disciplina);
        }

        public override void AtualizarListagem()
        {
            //_disciplinaControl.listarDisciplinas(_disciplinaService.SelecionarTodasDisciplinas());
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override string ObtemTipo()
        {
            return "Disciplina";
        }
    }
}
