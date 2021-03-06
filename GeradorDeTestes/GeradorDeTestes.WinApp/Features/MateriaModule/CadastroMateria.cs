﻿using GeradorDeTestes.Application.IoC;
using GeradorDeTestes.Applications;
using GeradorDeTestes.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    public partial class CadastroMateria : Form
    {
        private Materia _materiaParaEdicao;
        public Materia MateriaEditada
        {
            get
            {
                _materiaParaEdicao.Nome = txtMateria.Text;
                _materiaParaEdicao.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
                _materiaParaEdicao.Serie = cmbSerie.SelectedItem as Serie;

                return this._materiaParaEdicao;
            }

            set { this._materiaParaEdicao = value; }
        }

        public CadastroMateria(bool OperacaoDeAdicao)
        {
            InitializeComponent();
            popularComboBoxDisciplina();
            popularComboBoxSerie();

            if (!OperacaoDeAdicao)
            {
                if (IoC.IOCuserControl.MateriaControl.RetornaMateriaSelecionadaNoListBox() != null)
                {
                    _materiaParaEdicao = IoC.IOCuserControl.MateriaControl.RetornaMateriaSelecionadaNoListBox();
                    txtMateria.Text = IoC.IOCuserControl.MateriaControl.RetornaMateriaSelecionadaNoListBox().Nome;

                    cmbDisciplina.SelectedIndex = cmbDisciplina.FindString(_materiaParaEdicao.Disciplina.ToString());
                    cmbSerie.SelectedIndex = cmbSerie.FindString(_materiaParaEdicao.Serie.ToString());
                }
            }
        }

        public Materia NovaMateria
        {
            get
            {
                var materia = new Materia();
                materia.Id = 0;
                materia.Nome = txtMateria.Text;
                materia.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
                materia.Serie = cmbSerie.SelectedItem as Serie;

                return materia;
            }
        }

        public void popularComboBoxDisciplina()
        {
            cmbDisciplina.Items.Clear();

            foreach (Disciplina disciplina in IOCService.DisciplinaService.GetAll())
            {
                cmbDisciplina.Items.Add(disciplina);
            }

        }

        public void popularComboBoxSerie()
        {
            cmbSerie.Items.Clear();
            foreach (Serie serie in IOCService.SerieService.GetAll())
            {
                cmbSerie.Items.Add(serie);
            }
        }

        private void ValidarSeExisteNoBanco(Materia materia)
        {
            List<Materia> listMaterias = IOCService.MateriaService.GetAll();
            if (materia.Id == 0)
            {
                foreach (var item in listMaterias)
                {
                    if (materia.Nome.ToLower() == item.Nome.ToLower())
                        throw new Exception("A materia já existe no banco de dados");
                }
            }
            else
            {
                foreach (var item in listMaterias)
                {
                    if (materia.Nome.ToLower() == item.Nome.ToLower() && materia.Id != item.Id)
                        throw new Exception("A materia já existe no banco de dados");
                }
            }
        }

        private void btnSalvarMateria_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarPreenchimentoDosCampos();

                if (_materiaParaEdicao != null)
                {
                    MateriaEditada.Validate();


                    foreach (var item in IOCService.MateriaService.GetAll())
                    {
                        if (MateriaEditada.Nome == item.Nome && MateriaEditada.Serie.Id == item.Serie.Id && MateriaEditada.Disciplina.Id == item.Disciplina.Id)
                        {
                            throw new Exception("Não houve alteração na matéria");
                        }
                    }
                    ValidarSeExisteNoBanco(MateriaEditada);


                }
                else
                {
                    NovaMateria.Validate();

                    ValidarSeExisteNoBanco(NovaMateria);
                }

            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }



        public void ValidarPreenchimentoDosCampos()
        {
            if (cmbDisciplina.SelectedItem == null)
            {
                cmbDisciplina.BackColor = Color.Red;
                throw new Exception("A disciplina deve ser selecionada");
            }

            if (cmbSerie.SelectedItem == null)
            {
                cmbSerie.BackColor = Color.Red;
                throw new Exception("A serie deve ser selecionada");
            }

            if (txtMateria.Text == null)
            {
                cmbDisciplina.BackColor = Color.Red;
                throw new Exception("O campo nome deve ser preenchido");
            }


        }


    }
}

