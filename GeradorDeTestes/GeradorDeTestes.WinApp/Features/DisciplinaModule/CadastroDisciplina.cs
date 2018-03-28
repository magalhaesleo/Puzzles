using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeradorDeTestes.Domain.Entidades;

namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    public partial class CadastroDisciplina : Form
    {

        private Disciplina _disciplinaParaEdicao;

        public Disciplina DisciplinaEditada
        {
            get
            {
                _disciplinaParaEdicao.Nome = txtNome.Text;
                return this._disciplinaParaEdicao;
            }

            set { this._disciplinaParaEdicao = value; }
        }
        public CadastroDisciplina(DisciplinaControl disciplinaControl, Boolean OperacaoDeAdicao)
        {
            InitializeComponent();

            if (!OperacaoDeAdicao)
            {
                if (disciplinaControl.retornaItemSelecionadoNoListBox() != null)
                {
                    _disciplinaParaEdicao = disciplinaControl.retornaItemSelecionadoNoListBox();
                    txtNome.Text = _disciplinaParaEdicao.Nome;
                }
            }

        }


        public Disciplina NovaDisciplina
        {
            get
            {
                var disciplina = new Disciplina();
                disciplina.Nome = txtNome.Text;

                return disciplina;
            }
        }



        public void ValidarPreenchimentoDosCampos()
        {

                if (txtNome.Text == null)
                {
                    txtNome.BackColor = Color.Red;
                    throw new Exception("O campo nome não pode estar vazio");
                }

                if (_disciplinaParaEdicao != null)
                {
                    if (txtNome.Text == _disciplinaParaEdicao.Nome)
                    {
                        txtNome.BackColor = Color.Red;
                        throw new Exception("Digite um nome diferente do atual, caso contrário feche a janela");
                    }
                }
         

        }

        private void btnSalvarCadastroDisciplina_Click(object sender, EventArgs e)
        {


            try
            {
                ValidarPreenchimentoDosCampos();

                if (_disciplinaParaEdicao != null)
                {
                    DisciplinaEditada.Validate();
                }
                else
                {
                    NovaDisciplina.Validate();
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }


        }


    }
}
