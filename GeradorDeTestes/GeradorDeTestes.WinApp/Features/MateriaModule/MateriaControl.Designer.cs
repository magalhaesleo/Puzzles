namespace GeradorDeTestes.WinApp.Features.MateriaModule
{
    partial class MateriaControl
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
            this.listMateria = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listMateria
            // 
            this.listMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMateria.FormattingEnabled = true;
            this.listMateria.Location = new System.Drawing.Point(0, 0);
            this.listMateria.Name = "listMateria";
            this.listMateria.Size = new System.Drawing.Size(825, 282);
            this.listMateria.TabIndex = 3;
            this.listMateria.SelectedIndexChanged += new System.EventHandler(this.listMateria_SelectedIndexChanged);
            // 
            // MateriaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listMateria);
            this.Name = "MateriaControl";
            this.Size = new System.Drawing.Size(825, 282);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listMateria;
    }
}
