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
        private int _idQuestaoEdicao;
        private AlternativaService _alternativaService;

        private Questao _questaoParaEdicao;


        public CadastroQuestao(List<Materia> materias)
        {
            InitializeComponent();

            _materias = materias;
            popularComboBoxes();
            cm = new ContextMenu();
            cm.MenuItems.Add("Excluir alternativa");
            cmbMateria.Enabled = false;
            btnAdicionar.Enabled = false;
        }

        public CadastroQuestao(List<Materia> materias, Questao questaoParaEditar) : this(materias)
        {
            _questaoParaEdicao = questaoParaEditar;
            cmbDisciplina.SelectedIndex = cmbDisciplina.FindString(questaoParaEditar.Materia.Disciplina.ToString());
            cmbMateria.SelectedIndex = cmbMateria.FindString(questaoParaEditar.Materia.ToString());
            numBimestre.Value = questaoParaEditar.Bimestre;
            txtEnunciadoQuestao.Text = questaoParaEditar.Enunciado;
            _idQuestaoEdicao = questaoParaEditar.Id;
            _alternativaService = new AlternativaService();

            foreach (Alternativa alternativa in questaoParaEditar.Alternativas)
            {
                chkListBoxAlternativas.Items.Add(alternativa);
               
            }
            int indiceItem = 0;
            foreach (Alternativa alternativa in chkListBoxAlternativas.Items)
            {
                if(alternativa.Correta) {
                     indiceItem = chkListBoxAlternativas.Items.IndexOf(alternativa);
                    
                }
            }
            chkListBoxAlternativas.SetItemChecked(indiceItem, true);
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
                    var alternativaParaAdicionar = (Alternativa)chkListBoxAlternativas.Items[i];
                    alternativaParaAdicionar.IdQuestao = questao.Id;
                    questao.Alternativas.Add(alternativaParaAdicionar);
                }

                return questao;
            }
        }

        public Questao QuestaoEditada
        {
            get
            {
                foreach (var item in _questaoParaEdicao.Alternativas)
                    {
                      _alternativaService.Excluir(item);
                    
                    }
                _questaoParaEdicao.Alternativas = new List<Alternativa>();
                _questaoParaEdicao.Materia = (Materia)cmbMateria.SelectedItem;
                _questaoParaEdicao.Bimestre = (int)numBimestre.Value;
                _questaoParaEdicao.Enunciado = txtEnunciadoQuestao.Text;
                
                foreach (Alternativa alt in chkListBoxAlternativas.Items)
                {
                    var alternativaParaEditar = alt;
                    alternativaParaEditar.IdQuestao = _questaoParaEdicao.Id;
                    _questaoParaEdicao.Alternativas.Add(alternativaParaEditar);

                    
                }

                

                return this._questaoParaEdicao;
            }

            set { this._questaoParaEdicao = value; }
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
            AtribuirLetraAoAdicionar(alt);
            alt.IdQuestao = 0;
            alt.Id = 0;
            alt.Enunciado = txtAlternativa.Text;

            try
            {
                txtAlternativa.Text = null;
                alt.Validate();

                chkListBoxAlternativas.Items.Add(alt);
                txtAlternativa.Text = "";

                if (chkListBoxAlternativas.Items.Count == 4)
                    btnAdicionar.Enabled = false;

                if (chkListBoxAlternativas.Items.Count >= 2)
                    chkListBoxAlternativas.BackColor = Color.FromArgb(255, 255, 255, 255);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }
        private void AtribuirLetraAoAdicionar(Alternativa alternativa)
        {
            int tamanhoDaLista = chkListBoxAlternativas.Items.Count;

            SwitchAtribuirLetra(alternativa, tamanhoDaLista);

        }

        private void AtribuirLetraAoExcluir(Alternativa alternativa)
        {
            int indice = 0;

            foreach (var item in chkListBoxAlternativas.Items)
            {
                if (alternativa == item)
                    indice = chkListBoxAlternativas.Items.IndexOf(item);
            }

            SwitchAtribuirLetra(alternativa, indice);

        }

        private void SwitchAtribuirLetra(Alternativa alternativa, int parametroSwitch)
        {
            switch (parametroSwitch)
            {
                case 0:
                    alternativa.Letra = 'A';
                    break;
                case 1:
                    alternativa.Letra = 'B';
                    break;
                case 2:
                    alternativa.Letra = 'C';
                    break;
                case 3:
                    alternativa.Letra = 'D';
                    break;
                case 4:
                    alternativa.Letra = 'E';
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
                toolTip1.ToolTipTitle = "Alternativa:";
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
                txtEnunciadoQuestao.BackColor = Color.Red;
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
            
            Alternativa alt = (Alternativa)chkListBoxAlternativas.SelectedItem;
            if (alt != null)
            {
                if (items.CheckedItems.Count > 0)
                {
                    e.NewValue = CheckState.Unchecked;
                    alt.Correta = false;
                }
                else
                {
                    alt.Correta = true;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarPreenchimentoDosCampos();

                if (_questaoParaEdicao != null)
                {
                    QuestaoEditada.Validar();
                }

                else
                {
                   NovaQuestao.Validar();
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_materias[(cmbMateria.SelectedIndex + 1)] != null)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Alternativa excluida = new Alternativa();
            Alternativa alt = (Alternativa)chkListBoxAlternativas.SelectedItem;

            foreach (Alternativa alternativa in chkListBoxAlternativas.Items)
            {
                
                if (alternativa == alt)
                {
                    excluida = alt;
                    if(alternativa.Id > 0)
                    {
                        _alternativaService.Excluir(alternativa);
                    }
                }
            }

            chkListBoxAlternativas.Items.Remove(excluida);


            for (int i = 0; i < chkListBoxAlternativas.Items.Count; i++)
            {
                Alternativa alternativaAtual = (Alternativa)chkListBoxAlternativas.Items[i];
                AtribuirLetraAoExcluir(alternativaAtual);
            }

        }

        private void chkListBoxAlternativas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkListBoxAlternativas.SelectedIndex != -1)
            {
                btnExcluir.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
            }
        }

        private void txtAlternativa_TextChanged(object sender, EventArgs e)
        {
            if (txtAlternativa.Text.Length < 1 || chkListBoxAlternativas.Items.Count == 5)
            {
                btnAdicionar.Enabled = false;
            }
            else
            {
                btnAdicionar.Enabled = true;
            }
        }
    }
}
