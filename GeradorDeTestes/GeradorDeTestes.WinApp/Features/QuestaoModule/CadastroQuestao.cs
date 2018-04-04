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

namespace GeradorDeTestes.WinApp.Features.QuestaoModule
{
    public partial class CadastroQuestao : Form
    {

        ContextMenu cm;
        int ttIndex;
        ToolTip toolTip1 = new ToolTip();
        List<Materia> _materias;


        public CadastroQuestao(List<Materia> materias)
        {
            InitializeComponent();

            _materias = materias;
            popularComboBoxes();
            cm = new ContextMenu();
            cm.MenuItems.Add("Excluir alternativa");
            cmbMateria.Enabled = false;
        }

        public CadastroQuestao(List<Materia> materias, Questao questaoParaEditar)
        {
            InitializeComponent();
            
            _materias = materias;
            popularComboBoxes();
            cm = new ContextMenu();
            cm.MenuItems.Add("Excluir alternativa");

            cmbDisciplina.SelectedIndex = cmbDisciplina.FindString(questaoParaEditar.Materia.Disciplina.ToString());
            cmbMateria.SelectedIndex = cmbMateria.FindString(questaoParaEditar.Materia.ToString());
            numBimestre.Value = questaoParaEditar.Bimestre;
            txtEnunciadoQuestao.Text = questaoParaEditar.Enunciado;
            foreach (Alternativa alternativa in questaoParaEditar.Alternativas)
            {
                chkListBoxAlternativas.Items.Add(alternativa);
            }
        }

        public Questao NovaQuestao
        {
            get
            {
                var questao = new Questao();
                questao.Id = 0;
                questao.Enunciado = txtEnunciadoQuestao.Text;
                questao.Bimestre = (int)numBimestre.Value;
                questao.Materia = cmbMateria.SelectedItem as Materia;

                for (int i = 0; i < chkListBoxAlternativas.Items.Count; i++)
                {
                    questao.Alternativas.Add(chkListBoxAlternativas.Items[i] as Alternativa);
                }

                return questao;
            }
        }

        private void popularComboBoxes()
        {
            cmbDisciplina.Items.Clear();
            cmbMateria.Items.Clear();

            foreach (Materia materia in _materias)
            {
                if (cmbDisciplina.FindString(materia.Disciplina.ToString()) != 0)
                {
                    cmbDisciplina.Items.Add(materia.Disciplina);
                }
                cmbMateria.Items.Add(materia);
            }   

        }

        private void chkListBoxAlternativas_MouseUp(object sender, MouseEventArgs e)
        {
            chkListBoxAlternativas.SelectedIndex = chkListBoxAlternativas.IndexFromPoint(e.X, e.Y);
            if (chkListBoxAlternativas.SelectedIndex == -1 || e.Button != MouseButtons.Right)
                return;
            Rectangle r = chkListBoxAlternativas.GetItemRectangle(chkListBoxAlternativas.SelectedIndex);
            if (r.Contains(e.Location))
            {
                cm.Show(chkListBoxAlternativas, e.Location);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Alternativa alt = new Alternativa();
            AtribuirLetra(alt);
            alt.Enunciado = txtAlternativa.Text;
            chkListBoxAlternativas.Items.Add(alt);
            txtAlternativa.Text = "";

            if (chkListBoxAlternativas.Items.Count == 5)
                btnAdicionar.Enabled = false;

            if (chkListBoxAlternativas.Items.Count >= 2)
                chkListBoxAlternativas.BackColor = Color.FromArgb(255, 255, 255, 255);

        }
        private void AtribuirLetra(Alternativa alternativa)
        {
            switch (chkListBoxAlternativas.Items.Count)
            {
                case 0:
                    alternativa.Letra = Letra.a;
                    break;
                case 1:
                    alternativa.Letra = Letra.b;
                    break;
                case 2:
                    alternativa.Letra = Letra.c;
                    break;
                case 3:
                    alternativa.Letra = Letra.d;
                    break;
                case 4:
                    alternativa.Letra = Letra.e;
                    break;
                default:
                    break;
            }
        }

        private void chkListBoxAlternativas_MouseMove(object sender, MouseEventArgs e)
        {
            ttIndex = chkListBoxAlternativas.IndexFromPoint(e.Location);
        }
        private void ShowToolTip()
        {

            ttIndex = chkListBoxAlternativas.IndexFromPoint(chkListBoxAlternativas.PointToClient(MousePosition));
            if (ttIndex > -1)
            {
                toolTip1.ToolTipTitle = "Tooltip Title";
                toolTip1.SetToolTip(chkListBoxAlternativas, chkListBoxAlternativas.Items[ttIndex].ToString());

            }
        }

        private void chkListBoxAlternativas_MouseHover(object sender, EventArgs e)
        {

            //if (ttIndex != chkListBoxAlternativas.IndexFromPoint(e.Location))
            ShowToolTip();
        }

        public void ValidarPreenchimentoDosCampos()
        {
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

            if (txtEnunciadoQuestao.Text == null || txtEnunciadoQuestao.Text.Length < 1)
            {
                cmbDisciplina.BackColor = Color.Red;
                throw new Exception("O campo enunciado da questão deve ser preenchido");
            }

            if (chkListBoxAlternativas.Items.Count < 2)
            {
                chkListBoxAlternativas.BackColor = Color.Red;
                throw new Exception("A questão deve ter entre 2 e 5 alternativas");
            }

            if (chkListBoxAlternativas.CheckedItems.Count == 0)
            {
                lblAlternativaCorreta.ForeColor = Color.Red;
                throw new Exception("Uma das alternativas deve ser marcada como correta");
            }


        }

        private void chkListBoxAlternativas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox items = (CheckedListBox)sender;
            if (items.CheckedItems.Count > 0)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {               
                ValidarPreenchimentoDosCampos();
                NovaQuestao.Validar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Materia materia = (Materia)cmbMateria.SelectedItem;
            cmbDisciplina.SelectedIndex = cmbDisciplina.FindString(materia.Disciplina.ToString());
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_materias[(cmbMateria.SelectedIndex + 1)] != null)
            {
                cmbMateria.Items.Clear();
            }
            
            Disciplina disciplina = (Disciplina)cmbDisciplina.SelectedItem;
            foreach (Materia materia in _materias)
            {
                if (materia.Disciplina.Id == disciplina.Id)
                {
                    cmbMateria.Items.Add(materia);
                }
            }

            cmbMateria.Enabled = true;
        }
    }
}
