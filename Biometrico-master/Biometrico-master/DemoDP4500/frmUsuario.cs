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
    public partial class frmUsuario : Form
    {
        private DPFP.Template Template;
        private UsuariosDBEntities context;

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            context = new UsuariosDBEntities();
            Listar();
        }
        private void Listar()
        {
            try
            {
                var empleados = from emp in context.EMPLEADO

                                select new
                                {
                                    ID = emp.documento,
                                    EMPLEADO = emp.nombre
                                };
                if (empleados != null)
                {
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                EMPLEADO empleado = new EMPLEADO()
                {
                    idEmpleado = 0,
                    documento = TxtDocumento.Text,
                    nombre = TxtNombre.Text,
                    apellido = TxtApellidos.Text
                };
                EMPLEADO emplead = context.EMPLEADO.Add(empleado);
                context.SaveChanges();
                MessageBox.Show("Registro agregado a la BD correctamente");
                Listar();
                Main mn = new Main();
                mn.Show();
                this.Hide();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void TxtDocumento_Validated(object sender, EventArgs e)
        {
            if (TxtDocumento.Text.Trim() == "")
            {
                epError.SetError(TxtDocumento, "Ingrese el documento");
                TxtDocumento.Focus();
            }
            else
            {
                epError.Clear();
            }
        }

        private void TxtNombre_Validated(object sender, EventArgs e)
        {
            if (TxtNombre.Text.Trim() == "")
            {
                epError.SetError(TxtNombre, "Ingrese el nombre");
                TxtNombre.Focus();
            }
            else
            {
                epError.Clear();
            }
        }

        private void TxtApellidos_Validated(object sender, EventArgs e)
        {
            if (TxtApellidos.Text.Trim() == "")
            {
                epError.SetError(TxtApellidos, "Ingrese sus apellidos");
                TxtApellidos.Focus();
            }
            else
            {
                epError.Clear();
            }
        }
        private void btnSkip_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Principal pl = new Principal();
            pl.Show();
            this.Hide();
        }
    }
}