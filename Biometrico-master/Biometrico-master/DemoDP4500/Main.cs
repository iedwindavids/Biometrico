using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoDP4500
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrar registrar = new frmRegistrar();
            registrar.Show();
            this.Hide();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            frmMarcar marcar = new frmMarcar();
            marcar.Show();
            this.Hide();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmReporte reporte = new frmReporte();
            reporte.Show();
            this.Hide();
        }
    }
}
