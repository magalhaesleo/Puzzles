namespace GeradorDeTestes.WinApp.Features.QuestaoModule
{
    partial class CadastroQuestao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numBimestre = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnunciadoQuestao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkListBoxAlternativas = new System.Windows.Forms.CheckedListBox();
            this.txtAlternativa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblAlternativaCorreta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBimestre)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(68, 12);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(400, 21);
            this.cmbDisciplina.TabIndex = 6;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Disciplina:";
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(68, 39);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(400, 21);
            this.cmbMateria.TabIndex = 8;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Matéria:";
            // 
            // numBimestre
            // 
            this.numBimestre.Location = new System.Drawing.Point(68, 66);
            this.numBimestre.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBimestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBimestre.Name = "numBimestre";
            this.numBimestre.ReadOnly = true;
            this.numBimestre.Size = new System.Drawing.Size(28, 20);
            this.numBimestre.TabIndex = 9;
            this.numBimestre.UseWaitCursor = true;
            this.numBimestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Bimestre:";
            // 
            // txtEnunciadoQuestao
            // 
            this.txtEnunciadoQuestao.Location = new System.Drawing.Point(18, 114);
            this.txtEnunciadoQuestao.Multiline = true;
            this.txtEnunciadoQuestao.Name = "txtEnunciadoQuestao";
            this.txtEnunciadoQuestao.Size = new System.Drawing.Size(450, 67);
            this.txtEnunciadoQuestao.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Enunciado da questão:";
            // 
            // chkListBoxAlternativas
            // 
            this.chkListBoxAlternativas.CheckOnClick = true;
            this.chkListBoxAlternativas.FormattingEnabled = true;
            this.chkListBoxAlternativas.HorizontalScrollbar = true;
            this.chkListBoxAlternativas.Location = new System.Drawing.Point(18, 307);
            this.chkListBoxAlternativas.Name = "chkListBoxAlternativas";
            this.chkListBoxAlternativas.Size = new System.Drawing.Size(450, 109);
            this.chkListBoxAlternativas.TabIndex = 13;
            this.chkListBoxAlternativas.Tag = "";
            this.chkListBoxAlternativas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListBoxAlternativas_ItemCheck);
            this.chkListBoxAlternativas.MouseHover += new System.EventHandler(this.chkListBoxAlternativas_MouseHover);
            this.chkListBoxAlternativas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkListBoxAlternativas_MouseMove);
            this.chkListBoxAlternativas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkListBoxAlternativas_MouseUp);
            // 
            // txtAlternativa
            // 
            this.txtAlternativa.Location = new System.Drawing.Point(18, 215);
            this.txtAlternativa.Multiline = true;
            this.txtAlternativa.Name = "txtAlternativa";
            this.txtAlternativa.Size = new System.Drawing.Size(450, 57);
            this.txtAlternativa.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Alternativa:";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(312, 278);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 16;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Location = new System.Drawing.Point(393, 278);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 17;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(393, 440);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 18;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblAlternativaCorreta
            // 
            this.lblAlternativaCorreta.AutoSize = true;
            this.lblAlternativaCorreta.Location = new System.Drawing.Point(15, 288);
            this.lblAlternativaCorreta.Name = "lblAlternativaCorreta";
            this.lblAlternativaCorreta.Size = new System.Drawing.Size(143, 13);
            this.lblAlternativaCorreta.TabIndex = 21;
            this.lblAlternativaCorreta.Text = "Assinale a alternativa correta";
            // 
            // CadastroQuestao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 475);
            this.Controls.Add(this.lblAlternativaCorreta);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAlternativa);
            this.Controls.Add(this.chkListBoxAlternativas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEnunciadoQuestao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numBimestre);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroQuestao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Questão";
            ((System.ComponentModel.ISupportInitialize)(this.numBimestre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnunciadoQuestao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkListBoxAlternativas;
        private System.Windows.Forms.TextBox txtAlternativa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblAlternativaCorreta;
    }
}