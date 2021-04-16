using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoDP4500
{
    public partial class Principal : Form
    { 
        private UsuariosDBEntities contexto;

        public Principal()
        {
            InitializeComponent();
        }

        private void txtDocumento_Validated(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() == "")
            {
                errorProvider1.SetError(txtDocumento, "Ingrese el documento");
                txtDocumento.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            contexto = new UsuariosDBEntities();

            DateTime thisDay = DateTime.Today;


            Console.WriteLine(thisDay.ToString("d"));

            String codigo = txtDocumento.Text;

            try
            {
                using (UsuariosDBEntities context = new UsuariosDBEntities())
                {
                    EMPLEADO ec = context.EMPLEADO.FirstOrDefault(x => x.documento == codigo);
                    var vl = ec;

                    if (vl != null)
                    {
                        MessageBox.Show("El usuario existe en el sistema ");
                        Main mv = new Main();
                        mv.Show();
                        this.Hide();
                    }
                    else if(txtDocumento.Text.Trim()=="")
                    {
                        errorProvider1.SetError(txtDocumento, "Ingrese el documento");
                        txtDocumento.Focus();
                    }
                    else
                    {
                        MessageBox.Show("El usaurio no existe en el sistema");
                        frmUsuario fu = new frmUsuario();
                        fu.Show();
                        this.Hide();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }
    }
}