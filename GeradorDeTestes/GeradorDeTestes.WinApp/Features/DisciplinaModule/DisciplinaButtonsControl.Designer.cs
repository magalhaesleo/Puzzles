namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    partial class DisciplinaButtonsControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadastrarDisciplina = new System.Windows.Forms.Button();
            this.btnEditarDisciplina = new System.Windows.Forms.Button();
            this.btnExcluirDisciplina = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadastrarDisciplina
            // 
            this.btnCadastrarDisciplina.Location = new System.Drawing.Point(15, 18);
            this.btnCadastrarDisciplina.Name = "btnCadastrarDisciplina";
            this.btnCadastrarDisciplina.Size = new System.Drawing.Size(121, 23);
            this.btnCadastrarDisciplina.TabIndex = 0;
            this.btnCadastrarDisciplina.Text = "Cadastrar";
            this.btnCadastrarDisciplina.UseVisualStyleBackColor = true;
            this.btnCadastrarDisciplina.Click += new System.EventHandler(this.btnCadastrarDisciplina_Click);
            // 
            // btnEditarDisciplina
            // 
            this.btnEditarDisciplina.Location = new System.Drawing.Point(15, 57);
            this.btnEditarDisciplina.Name = "btnEditarDisciplina";
            this.btnEditarDisciplina.Size = new System.Drawing.Size(121, 23);
            this.btnEditarDisciplina.TabIndex = 1;
            this.btnEditarDisciplina.Text = "Editar";
            this.btnEditarDisciplina.UseVisualStyleBackColor = true;
            // 
            // btnExcluirDisciplina
            // 
            this.btnExcluirDisciplina.Location = new System.Drawing.Point(15, 97);
            this.btnExcluirDisciplina.Name = "btnExcluirDisciplina";
            this.btnExcluirDisciplina.Size = new System.Drawing.Size(121, 23);
            this.btnExcluirDisciplina.TabIndex = 2;
            this.btnExcluirDisciplina.Text = "Excluir";
            this.btnExcluirDisciplina.UseVisualStyleBackColor = true;
            this.btnExcluirDisciplina.Click += new System.EventHandler(this.btnExcluirDisciplina_Click);
            // 
            // DisciplinaButtonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExcluirDisciplina);
            this.Controls.Add(this.btnEditarDisciplina);
            this.Controls.Add(this.btnCadastrarDisciplina);
            this.Name = "DisciplinaButtonsControl";
            this.Size = new System.Drawing.Size(150, 316);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrarDisciplina;
        private System.Windows.Forms.Button btnEditarDisciplina;
        private System.Windows.Forms.Button btnExcluirDisciplina;
    }
}
