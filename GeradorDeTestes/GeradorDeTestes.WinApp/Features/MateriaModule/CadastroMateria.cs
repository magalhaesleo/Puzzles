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

        public List<Materia> ListMaterias { get; set; }
        public CadastroMateria(List<Disciplina> listDisciplina, List<Serie> listSerie, MateriaControl materiaControl, Boolean OperacaoDeAdicao,List<Materia> listMaterias)
        {
            InitializeComponent();
            popularComboBoxDisciplina(listDisciplina);
            popularComboBoxSerie(listSerie);
            ListMaterias = listMaterias;
            if (!OperacaoDeAdicao)
            {
                if (materiaControl.RetornaMateriaSelecionadaNoListBox() != null)
                {
                    _materiaParaEdicao = materiaControl.RetornaMateriaSelecionadaNoListBox();
                    txtMateria.Text = materiaControl.RetornaMateriaSelecionadaNoListBox().Nome;

                    foreach (var item in listDisciplina)
                    {
                        if (item.Id == _materiaParaEdicao.Disciplina.Id)
                        {
                            cmbDisciplina.SelectedItem = item;
                        }
                    }

                    foreach (var item in listSerie)
                    {
                        if (item.Id == _materiaParaEdicao.Serie.Id)
                        {
                            cmbSerie.SelectedItem = item;
                        }
                    }
                }

            }


        }

        public Materia NovaMateria
        {
            get
            {
                var materia = new Materia();

                materia.Nome = txtMateria.Text;
                materia.Disciplina = cmbDisciplina.SelectedItem as Disciplina;
                materia.Serie = cmbSerie.SelectedItem as Serie;

                return materia;
            }
        }

        public void popularComboBoxDisciplina(List<Disciplina> listDisciplina)
        {
            cmbDisciplina.Items.Clear();

            foreach (var item in listDisciplina)
            {
                cmbDisciplina.Items.Add(item);
            }

        }

        public void popularComboBoxSerie(List<Serie> listSerie)
        {
            cmbSerie.Items.Clear();
            foreach (var item in listSerie)
            {
                cmbSerie.Items.Add(item);
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

                    foreach (var item in ListMaterias )
                    {
                        if(MateriaEditada.Nome == item.Nome && MateriaEditada.Serie.Id == item.Serie.Id && MateriaEditada.Disciplina.Id == item.Disciplina.Id)
                        {
                            throw new Exception("Não houve alteração na matéria");
                        }
                    }
                }
                else
                {
                    NovaMateria.Validate();

                    foreach (var item in ListMaterias)
                    {
                        if(NovaMateria.Nome == item.Nome && NovaMateria.Serie.Id == item.Serie.Id && NovaMateria.Disciplina.Id == item.Disciplina.Id)
                        {
                            throw new Exception("A matéria ja esta cadastrada no banco de dados");
                        }
                    }
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

