using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcularNomina
{
    public partial class Form1 : Form
    {
       Empleado myEmpleado = new Empleado();
        Nomina myNomina = new Nomina();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlmacenarRegistro_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                error1.SetError(txtNombre, "Debe ingresar un nombre");
                txtNombre.Focus();
                return;
            }
            error1.SetError(txtNombre, "");

            //validar q solo deje ingresar numeros

            decimal AsignacionDia;
            if (!Decimal.TryParse(txtAsignacionDia.Text, out AsignacionDia))
            {
                error1.SetError(txtAsignacionDia, "Debe ingresar un numero");
                txtNombre.Focus();
                return;
            }
            error1.SetError(txtAsignacionDia, "");

            myEmpleado.Nombre = txtNombre.Text;
            myEmpleado.Identificacion = txtIdentificacion.Text;
            myEmpleado.AsignacionDia = Convert.ToDecimal(txtAsignacionDia.Text);
            myNomina.DiasLaborados = Convert.ToInt32(txtDiasLaborados.Text);
            MessageBox.Show("Se guardo el registro correctamente");

            
        }

        private void btnCalcularSalario_Click(object sender, EventArgs e)
        {
            txtTotalDevengado.Text = myNomina.CalcularNomina(Convert.ToInt32(myNomina.DiasLaborados), Convert.ToDecimal(myEmpleado.AsignacionDia)).ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtIdentificacion.Clear();
            txtAsignacionDia.Clear();
            txtDiasLaborados.Clear();
            txtTotalDevengado.Clear();
        }
    }
}
