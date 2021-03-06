﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.Entidades;
using GeradorDeTestes.Applications;
using GeradorDeTestes.Application.IoC;

namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    public partial class CadastroTeste : Form
    {

        public Teste Teste
        {
            get
            {
                Teste teste = new Teste();
                teste.Id = 0;
                teste.Nome = txtNome.Text; 
                teste.Materia = (Materia)cmbMateria.SelectedItem;
                teste.DataGeracao = DateTime.Parse(txtData.Text);
                teste.Questoes = IOCService.TesteService.SelecionaQuestoesAleatorias((int)numQuestoes.Value, teste.Materia.Id);

                return teste;
            }

        }

        public CadastroTeste()
        {
            InitializeComponent();

            txtData.Text = string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();

            foreach (Disciplina disciplina in IOCService.DisciplinaService.GetAll())
            {
                cmbDisciplina.Items.Add(disciplina);
            }
        }


        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.Enabled = true;
            cmbMateria.Items.Clear();
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplina.SelectedItem;
            foreach (Materia materia in IOCService.MateriaService.GetAll())
            {
                if (disciplinaSelecionada.Id == materia.Disciplina.Id)
                    cmbMateria.Items.Add(materia);
            }

        }

        public void ValidarPreenchimentoDosCampos()
        {
            if (txtNome.Text.Length < 5)
            {
                txtNome.BackColor = Color.Red;
                throw new Exception("O nome do teste deve possuir mais que 5 caracteres.");
            }

            if (txtNome.Text.Length > 50)
            {
                txtNome.BackColor = Color.Red;
                throw new Exception("O nome do teste deve possuir menos de 50 caracteres.");
            }

            if (cmbDisciplina.SelectedItem == null)
            {
                cmbDisciplina.BackColor = Color.Red;
                throw new Exception("A disciplina deve ser selecionada");
            }

            if (cmbMateria.SelectedItem == null)
            {
                cmbMateria.BackColor = Color.Red;
                throw new Exception("A matéria deve ser selecionada");
            }
        }

        private void btnGerarTeste_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarPreenchimentoDosCampos();
                Teste.Validar();
               
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            numQuestoes.Enabled = true;
            Materia materia = (Materia)cmbMateria.SelectedItem;
            List<int> quantidadeDeQuestoes = IOCService.QuestaoService.VerificarQuantidadeDeQuestoesPorMateria(materia.Id);
            numQuestoes.Maximum = (int)quantidadeDeQuestoes[0];
            if(quantidadeDeQuestoes[0] < 1)
            {
                numQuestoes.Enabled = false;
            }else
            {
                if((int)quantidadeDeQuestoes[0] > 30)
                {
                    numQuestoes.Maximum = 30;
                }
                numQuestoes.Value = 1;
                numQuestoes.Enabled = true;
            }
        }

        private void numQuestoes_ValueChanged(object sender, EventArgs e)
        {
            if(numQuestoes.Value == 0)
            {
                btnGerarTeste.Enabled = false;
            }
            else
            {
                btnGerarTeste.Enabled = true;
            }
        }
    }
}
