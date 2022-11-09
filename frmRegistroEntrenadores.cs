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
    public partial class frmRegistroEntrenadores : Form
    {
        
        public OleDbConnection ConexionBD;
        public OleDbCommand ComandoBD;
        
        public OleDbDataReader LectorBD;

        public string RutaBD = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + "DEPORTE.accdb";

        public frmRegistroEntrenadores()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cmdRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                clsEntrenador Registro = new clsEntrenador();
                Registro.CDeportista = lstCodigo.Text;
                Registro.Nombre = txtNombre.Text;
                Registro.Apellido = txtApellido.Text;
                Registro.Direccion = txtDireccion.Text;
                Registro.Provincia = txtProvincia.Text;
                Registro.Deporte = lstDeporte.Text;

                Registro.Agregar();
                MessageBox.Show("Datos registrados correctamente");
                Limpiar();
                txtNombre.Focus();
            }
            catch (Exception Mensajito)
            {
                MessageBox.Show(Mensajito.Message);
            }
        }

        private void frmRegistroEntrenadores_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
            
            //Lleno las lst con la info que hay en los add
            clsDeportista CompletarLstCodigo = new clsDeportista();
            CompletarLstCodigo.llenarLst(lstCodigo);
            

        }
        private void verificacionBotones()
        {
            if (lstCodigo.SelectedIndex >= 0 && txtNombre.Text != "" && txtApellido.Text != "" && txtDireccion.Text != "" && txtProvincia.Text != "" && lstDeporte.SelectedIndex >= 0)
            {
                cmdRegistrar.Enabled = true;
            }
            else
            {
                cmdRegistrar.Enabled = false;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtProvincia_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void lstDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            verificacionBotones();
        }
        private void Limpiar()
        {
            txtApellido.Text = "";
            lstCodigo.SelectedIndex = -1;
            lstDeporte.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtProvincia.Text = "";
        }

        private void lstCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void txtProvincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 & e.KeyChar <= 64) || (e.KeyChar >= 91 & e.KeyChar <= 96) || (e.KeyChar >= 123 & e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Por favor introduzca solo letras");
            }
        }
    }
}
