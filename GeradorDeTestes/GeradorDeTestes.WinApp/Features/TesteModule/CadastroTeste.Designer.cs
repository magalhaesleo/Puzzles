namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    partial class CadastroTeste
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numQuestoes = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGerarTeste = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disciplina:";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(106, 32);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(350, 21);
            this.cmbDisciplina.TabIndex = 1;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.Enabled = false;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(106, 59);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(350, 21);
            this.cmbMateria.TabIndex = 2;
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Materia:";
            // 
            // numQuestoes
            // 
            this.numQuestoes.Enabled = false;
            this.numQuestoes.Location = new System.Drawing.Point(133, 99);
            this.numQuestoes.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numQuestoes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestoes.Name = "numQuestoes";
            this.numQuestoes.ReadOnly = true;
            this.numQuestoes.Size = new System.Drawing.Size(39, 20);
            this.numQuestoes.TabIndex = 4;
            this.numQuestoes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuestoes.ValueChanged += new System.EventHandler(this.numQuestoes_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Número de Questões:";
            // 
            // btnGerarTeste
            // 
            this.btnGerarTeste.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGerarTeste.Location = new System.Drawing.Point(382, 124);
            this.btnGerarTeste.Name = "btnGerarTeste";
            this.btnGerarTeste.Size = new System.Drawing.Size(74, 23);
            this.btnGerarTeste.TabIndex = 7;
            this.btnGerarTeste.Text = "Gerar Teste";
            this.btnGerarTeste.UseVisualStyleBackColor = true;
            this.btnGerarTeste.Click += new System.EventHandler(this.btnGerarTeste_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(382, 98);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(74, 20);
            this.txtData.TabIndex = 8;
            this.txtData.Text = "5/4/2018";
            this.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Data de geração:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nome do Teste:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(106, 6);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(350, 20);
            this.txtNome.TabIndex = 11;
            // 
            // CadastroTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 159);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnGerarTeste);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numQuestoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroTeste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar Teste";
            ((System.ComponentModel.ISupportInitialize)(this.numQuestoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numQuestoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGerarTeste;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNome;
    }
}