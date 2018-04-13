namespace GeradorDeTestes.WinApp.Features.TesteModule
{
    partial class ExportarTesteDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPDF = new System.Windows.Forms.RadioButton();
            this.rbXML = new System.Windows.Forms.RadioButton();
            this.rbCSV = new System.Windows.Forms.RadioButton();
            this.btnExportar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCSV);
            this.groupBox1.Controls.Add(this.rbXML);
            this.groupBox1.Controls.Add(this.rbPDF);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formatos:";
            // 
            // rbPDF
            // 
            this.rbPDF.AutoSize = true;
            this.rbPDF.Location = new System.Drawing.Point(22, 35);
            this.rbPDF.Name = "rbPDF";
            this.rbPDF.Size = new System.Drawing.Size(46, 17);
            this.rbPDF.TabIndex = 0;
            this.rbPDF.TabStop = true;
            this.rbPDF.Text = "PDF";
            this.rbPDF.UseVisualStyleBackColor = true;
            // 
            // rbXML
            // 
            this.rbXML.AutoSize = true;
            this.rbXML.Location = new System.Drawing.Point(22, 58);
            this.rbXML.Name = "rbXML";
            this.rbXML.Size = new System.Drawing.Size(47, 17);
            this.rbXML.TabIndex = 1;
            this.rbXML.TabStop = true;
            this.rbXML.Text = "XML";
            this.rbXML.UseVisualStyleBackColor = true;
            // 
            // rbCSV
            // 
            this.rbCSV.AutoSize = true;
            this.rbCSV.Location = new System.Drawing.Point(22, 81);
            this.rbCSV.Name = "rbCSV";
            this.rbCSV.Size = new System.Drawing.Size(46, 17);
            this.rbCSV.TabIndex = 2;
            this.rbCSV.TabStop = true;
            this.rbCSV.Text = "CSV";
            this.rbCSV.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExportar.Location = new System.Drawing.Point(188, 161);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(106, 23);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar Teste";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // ExportarTesteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 196);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportarTesteDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exportar Teste";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCSV;
        private System.Windows.Forms.RadioButton rbXML;
        private System.Windows.Forms.RadioButton rbPDF;
        private System.Windows.Forms.Button btnExportar;
    }
}