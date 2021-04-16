using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoDP4500
{
    public partial class frmMarcar : CaptureForm
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        private UsuariosDBEntities contexto;
        private int tipoMarc;
        private DateTime day;
        TimeSpan time;

        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Verificación de Huella Digital";
            Verificator = new DPFP.Verification.Verification(); // Create a fingerprint template verificator
            UpdateStatus(0);
        }
        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }
        public void cbxTipoMarcacion_SelectedIndexChanged_1(object sender, EventArgs e) 
        {
            switch (cbxTipoMarcacion.SelectedIndex) //El switch case valida que posicion esta seleccionada
            {
                case 0: //Si esta en la posicion 0 
                    tipoMarc = 1; //Le da el valor a tipoMarc =1
                    break;
                case 1: // Si esta seleccionada la posicion 1 
                    tipoMarc = 2; //le asigna a tipoMar el valor de 2
                    break;
                case 2:// Si esta seleccionada la posicion 2 
                    tipoMarc = 3; //le asigna a tipoMar el valor de 3
                    break;
                case 3:// Si esta seleccionada la posicion 3 
                    tipoMarc = 4;//le asigna a tipoMar el valor de 4
                    break;
            }
        }
        protected override void Process(DPFP.Sample Sample)
        {
           contexto = new UsuariosDBEntities();
            base.Process(Sample);

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (!closeValidationForm(tipoMarc)) //LLama a closeValidationForm verifica si es diferente de nulo, si lo es NO hace ningun proceso 
            {
            }
            else //De lo contrario ejecuta o continua el proceso
            {
                if (features != null) //Feature es el resultado de el enrolamiento, si es diferente de nulo, es decir si la huella ha sido de buena calidad , entonces continua con el proceso.
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                    DPFP.Template template = new DPFP.Template();
                    Stream stream;
                    foreach (var emp in contexto.REGISTRO)
                    {
                        int numero = emp.idRegistro;
                        stream = new MemoryStream(emp.huella);
                        template = new DPFP.Template(stream);
                        Verificator.Verify(features, template, ref result);
                        UpdateStatus(result.FARAchieved);

                        DateTime[] dates = { DateTime.Now };
                        foreach (var date in dates)
                        {
                            Console.WriteLine("Day: {0:d} Time: {1:g}", date.Date, date.TimeOfDay);
                            day = date.Date;
                            time = date.TimeOfDay;
                        }
                        if (result.Verified)
                        {
                            MakeReport("The fingerprint was VERIFIED. " + emp.EMPLEADO.nombre);
                            try
                            {
                                MARCACION marcacion = new MARCACION()
                                {
                                    horaMarcacion = time,
                                    diaMarcacion = day,
                                    idRegistro = numero,
                                    tipoMarcacion = tipoMarc
                                };
                                contexto.MARCACION.Add(marcacion);
                                contexto.SaveChanges();
                                MessageBox.Show(emp.EMPLEADO.nombre+"  "+emp.EMPLEADO.apellido + "\n  Hora de marcacion: " + time+ "\n Tipo marcacion " + marcacion.tipoMarcacion );
                                contexto = null;
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("ERROR :Sql EXCEPTION" + ex.Message);
                                MessageBox.Show("Error al buscar");
                                contexto = null;
                            }
                            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                            {
                                Console.WriteLine("Error: tipo de marcacion repetida" + ex.Message);
                                MessageBox.Show("Error: Tipo de marcacion repetida");
                                contexto = null;
                            }
                        }
                    }
                }
            }
        }
        private bool closeValidationForm(int verificar) //Proceso para validar si se selecciono alguna opcion en en ComboBox
        {
            bool isValidate = false;
            string message = "Olvidaste seleccinar el tipo de entrada";
            string caption = "¡Debes seleccionar el tipo de entrada!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            if (verificar.Equals(0))
            {
                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.OK)
                {
                    isValidate = false;
                }
            }
            else
            {
                isValidate = true;
            }
            return isValidate;
        }
        public frmMarcar()
        {
            contexto = new UsuariosDBEntities();
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Main mv = new Main();
            mv.Show();
            this.Hide();
        }
    }
}