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
    public partial class frmReporte : Form
    {
        private UsuariosDBEntities contexto;

        public frmReporte()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            List<mostrarRegistros_Result> resultado = new List<mostrarRegistros_Result>();
            using (contexto = new UsuariosDBEntities())
            {
                resultado = contexto.mostrarRegistros().ToList();
            }

            dgvListar.DataSource = resultado.ToList();


        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Main mn= new Main();
            mn.Show();
            this.Hide();
        }
    }
}
