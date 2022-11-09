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
    public partial class frmModificarEntrenador : Form
    {
        public frmModificarEntrenador()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModificarEntrenador_Load(object sender, EventArgs e)
        {
            lstCodigo.Focus();
            clsDeportista CompletarLstCodigo = new clsDeportista();
            CompletarLstCodigo.llenarLst(lstCodigo);
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            string CDeportista = lstCodigo.Text;

            clsEntrenador Modificar = new clsEntrenador();
            Modificar.Nombre = txtNombre.Text;
            Modificar.Provincia = txtProvincia.Text;
            Modificar.Apellido = txtApellido.Text;
            Modificar.Direccion = txtDireccion.Text;
            Modificar.Deporte = lstDeporte.Text;


            Modificar.Modificar(CDeportista);
            MessageBox.Show("Datos guardados con exito");
            Limpiar();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            string Codigo = lstCodigo.Text;
            clsEntrenador BuscarED = new clsEntrenador();
            BuscarED.Buscar(Codigo);

            if (BuscarED.CDeportista != Codigo)
            {
                MessageBox.Show("El deportista no se encuentra en la base de datos");
            }
            else
            {
                txtNombre.Text = BuscarED.Nombre;
                txtApellido.Text = BuscarED.Apellido;
                txtDireccion.Text = BuscarED.Direccion;
                txtProvincia.Text = Convert.ToString(BuscarED.Provincia);
                lstDeporte.Text = Convert.ToString(BuscarED.Deporte);
            }
        }

        private void verificacionBotones()
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtDireccion.Text != "" && txtProvincia.Text != "" && lstDeporte.SelectedIndex >= 0)
            {
                cmdGuardar.Enabled = true;
            }
            else
            {
                cmdGuardar.Enabled = false;
            }
        }

        private void verificacionBoton()
        {
            if (lstCodigo.SelectedIndex >= 0)
            {
                cmdBuscar.Enabled = true;
            }
            else
            {
                cmdBuscar.Enabled = false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            verificacionBoton();
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
            verificacionBoton();
        }
    }   

}
