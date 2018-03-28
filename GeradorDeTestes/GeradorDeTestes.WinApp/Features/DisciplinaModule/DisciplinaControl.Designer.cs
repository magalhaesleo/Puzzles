namespace GeradorDeTestes.WinApp.Features.DisciplinaModule
{
    partial class DisciplinaControl
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
            this.listDisciplina = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listDisciplina
            // 
            this.listDisciplina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDisciplina.FormattingEnabled = true;
            this.listDisciplina.Location = new System.Drawing.Point(0, 0);
            this.listDisciplina.Name = "listDisciplina";
            this.listDisciplina.Size = new System.Drawing.Size(825, 282);
            this.listDisciplina.TabIndex = 1;
            this.listDisciplina.SelectedIndexChanged += new System.EventHandler(this.listDisciplina_SelectedIndexChanged);
            // 
            // DisciplinaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.listDisciplina);
            this.Name = "DisciplinaControl";
            this.Size = new System.Drawing.Size(825, 282);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listDisciplina;
    }
}
