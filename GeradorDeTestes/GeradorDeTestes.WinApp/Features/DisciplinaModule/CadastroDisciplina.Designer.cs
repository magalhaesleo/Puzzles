﻿namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    partial class CadastroDisciplina
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnSalvarCadastroDisciplina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(56, 29);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(204, 20);
            this.txtNome.TabIndex = 1;
            // 
            // btnSalvarCadastroDisciplina
            // 
            this.btnSalvarCadastroDisciplina.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvarCadastroDisciplina.Location = new System.Drawing.Point(149, 55);
            this.btnSalvarCadastroDisciplina.Name = "btnSalvarCadastroDisciplina";
            this.btnSalvarCadastroDisciplina.Size = new System.Drawing.Size(111, 23);
            this.btnSalvarCadastroDisciplina.TabIndex = 2;
            this.btnSalvarCadastroDisciplina.Text = "Salvar Disciplina";
            this.btnSalvarCadastroDisciplina.UseVisualStyleBackColor = true;
            this.btnSalvarCadastroDisciplina.Click += new System.EventHandler(this.btnSalvarCadastroDisciplina_Click);
            // 
            // CadastroDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 83);
            this.Controls.Add(this.btnSalvarCadastroDisciplina);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroDisciplina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Disciplina";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSalvarCadastroDisciplina;
    }
}