namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    partial class TesteControl
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
            this.listTeste = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listTeste
            // 
            this.listTeste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTeste.FormattingEnabled = true;
            this.listTeste.Location = new System.Drawing.Point(0, 0);
            this.listTeste.Name = "listTeste";
            this.listTeste.Size = new System.Drawing.Size(825, 282);
            this.listTeste.TabIndex = 0;
            // 
            // TesteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTeste);
            this.Name = "TesteControl";
            this.Size = new System.Drawing.Size(825, 282);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTeste;
    }
}
