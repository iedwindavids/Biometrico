namespace DemoDP4500
{
    partial class frmMarcar
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
            this.cbxTipoMarcacion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // cbxTipoMarcacion
            // 
            this.cbxTipoMarcacion.FormattingEnabled = true;
            this.cbxTipoMarcacion.Items.AddRange(new object[] {
            "Entrada",
            "Entrada Almuerzo",
            "Salida Almuerzo ",
            "Salida"});
            this.cbxTipoMarcacion.Location = new System.Drawing.Point(634, 3);
            this.cbxTipoMarcacion.Name = "cbxTipoMarcacion";
            this.cbxTipoMarcacion.Size = new System.Drawing.Size(165, 24);
            this.cbxTipoMarcacion.TabIndex = 7;
            this.cbxTipoMarcacion.SelectedIndexChanged += new System.EventHandler(this.cbxTipoMarcacion_SelectedIndexChanged_1);
            // 
            // frmMarcar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.cbxTipoMarcacion);
            this.Name = "frmMarcar";
            this.Text = "frmVerificar";
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.cbxTipoMarcacion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTipoMarcacion;
    }
}