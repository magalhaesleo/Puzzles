namespace GeradorDeTestes.WinApp
{
    partial class Principal
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciadorDeDisciplinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciadorDeMatériasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciadorDeQuestõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajudaToolStripMenuItem,
            this.gerenciadorDeDisciplinasToolStripMenuItem,
            this.gerenciadorDeMatériasToolStripMenuItem,
            this.gerenciadorDeQuestõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.ajudaToolStripMenuItem.Text = "Gerador de Testes";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // gerenciadorDeDisciplinasToolStripMenuItem
            // 
            this.gerenciadorDeDisciplinasToolStripMenuItem.Name = "gerenciadorDeDisciplinasToolStripMenuItem";
            this.gerenciadorDeDisciplinasToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.gerenciadorDeDisciplinasToolStripMenuItem.Text = "Gerenciador de Disciplinas";
            this.gerenciadorDeDisciplinasToolStripMenuItem.Click += new System.EventHandler(this.gerenciadorDeDisciplinasToolStripMenuItem_Click);
            // 
            // gerenciadorDeMatériasToolStripMenuItem
            // 
            this.gerenciadorDeMatériasToolStripMenuItem.Name = "gerenciadorDeMatériasToolStripMenuItem";
            this.gerenciadorDeMatériasToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.gerenciadorDeMatériasToolStripMenuItem.Text = "Gerenciador de Matérias";
            // 
            // gerenciadorDeQuestõesToolStripMenuItem
            // 
            this.gerenciadorDeQuestõesToolStripMenuItem.Name = "gerenciadorDeQuestõesToolStripMenuItem";
            this.gerenciadorDeQuestõesToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.gerenciadorDeQuestõesToolStripMenuItem.Text = "Gerenciador de Questões";
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(188, 27);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(649, 321);
            this.panelControl.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.Location = new System.Drawing.Point(12, 27);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(170, 321);
            this.panelButtons.TabIndex = 2;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 360);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciadorDeDisciplinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciadorDeMatériasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerenciadorDeQuestõesToolStripMenuItem;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelButtons;
    }
}

