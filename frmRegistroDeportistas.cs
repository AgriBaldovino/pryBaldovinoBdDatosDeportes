using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pryBaldovinoBdDatos2
{
    public partial class frmRegistroDeportistas : Form
    {
        public OleDbConnection ConexionBase;
        public OleDbCommand ComandoBase;
        public OleDbDataReader LectorBase;

        public string CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "DEPORTE.accdb";


        public frmRegistroDeportistas()
        {
            InitializeComponent();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                clsDeportista Registro = new clsDeportista();
                Registro.CDeportista = txtCodigo.Text;
                Registro.Nombre = txtNombre.Text;
                Registro.Apellido = txtApellido.Text;
                Registro.Direccion = txtDireccion.Text;
                Registro.Edad = Convert.ToInt32(mskEdad.Text);
                Registro.Telefono = Convert.ToInt32(mskTelefono.Text);
                Registro.Deportes = lstDeporte.Text;
                Registro.Agregar();
                MessageBox.Show("Datos registrados correctamente");
                Limpiar();
                txtNombre.Focus();
            }
            catch (Exception Mensajito)
            {
                MessageBox.Show(Mensajito.Message);
                //throw;
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegistroDeportistas_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void verificacionBotones()
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && txtDireccion.Text != "" && mskTelefono.Text != "" && mskEdad.Text != "" && lstDeporte.SelectedIndex >= 0)
            {
                cmdRegistrar.Enabled = true;
            }
            else
            {
                cmdRegistrar.Enabled = false;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void lstDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void Limpiar()
        {
            txtApellido.Text = "";
            txtCodigo.Text = "";
            lstDeporte.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtNombre.Text = "";
            mskEdad.Text = "";
            mskTelefono.Text = "";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 & e.KeyChar <= 64) || (e.KeyChar >= 91 & e.KeyChar <= 96) || (e.KeyChar >= 123 & e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Por favor introduzca solo letras");
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 & e.KeyChar <= 64) || (e.KeyChar >= 91 & e.KeyChar <= 96) || (e.KeyChar >= 123 & e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Por favor introduzca solo letras");
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 & e.KeyChar <= 64) || (e.KeyChar >= 91 & e.KeyChar <= 96) || (e.KeyChar >= 123 & e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Por favor introduzca solo letras");
            }
        }
    }
}
