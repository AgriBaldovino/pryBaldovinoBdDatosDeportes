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
    public partial class frmEliminarEntrenador : Form
    {
        public frmEliminarEntrenador()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            string Codigo = lstCodigo.Text;
            clsEntrenador BuscarED = new clsEntrenador();
            BuscarED.Buscar(Codigo);

            if (BuscarED.CDeportista != Codigo)
            {
                MessageBox.Show("El entrenador no se encuentra en la base de datos");
            }
            else
            {
                lblNombre.Text = BuscarED.Nombre;
                lblApellido.Text = BuscarED.Apellido;
                lblDireccion.Text = BuscarED.Direccion;
                lblProvincia.Text = BuscarED.Provincia;
                lblDeporte.Text = Convert.ToString(BuscarED.Deporte);
            }
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            string CodigoDepo = lstCodigo.Text;

            clsEntrenador EliminarDE = new clsEntrenador();

            EliminarDE.Eliminar(CodigoDepo);
            //MessageBox.Show("Datos borrados con exito");

            Limpiar();
            lstCodigo.Focus();
        }

        private void frmEliminarEntrenador_Load(object sender, EventArgs e)
        {
            lstCodigo.Focus();
            clsDeportista CompletarLstCodigo = new clsDeportista();
            CompletarLstCodigo.llenarLst(lstCodigo);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            verificacionBoton();
        }
        private void Limpiar()
        {
            lstCodigo.SelectedIndex = -1;
            lblNombre.Text = "";
            lblApellido.Text = "";
            lblDireccion.Text = "";
            lblProvincia.Text = "";
            lblDeporte.Text = "";
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
