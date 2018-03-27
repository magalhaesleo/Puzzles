namespace GeradorDeTestes.WinApp.Features.SerieModule
{
    partial class CadastroSerie
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
            this.numSerie = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCriarSerie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSerie)).BeginInit();
            this.SuspendLayout();
            // 
            // numSerie
            // 
            this.numSerie.Location = new System.Drawing.Point(24, 12);
            this.numSerie.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numSerie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSerie.Name = "numSerie";
            this.numSerie.ReadOnly = true;
            this.numSerie.Size = new System.Drawing.Size(38, 20);
            this.numSerie.TabIndex = 0;
            this.numSerie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ª série";
            // 
            // btnCriarSerie
            // 
            this.btnCriarSerie.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCriarSerie.Location = new System.Drawing.Point(27, 53);
            this.btnCriarSerie.Name = "btnCriarSerie";
            this.btnCriarSerie.Size = new System.Drawing.Size(75, 23);
            this.btnCriarSerie.TabIndex = 2;
            this.btnCriarSerie.Text = "Criar Série";
            this.btnCriarSerie.UseVisualStyleBackColor = true;
            // 
            // CadastroSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(137, 97);
            this.Controls.Add(this.btnCriarSerie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSerie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Série";
            ((System.ComponentModel.ISupportInitialize)(this.numSerie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numSerie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCriarSerie;
    }
}