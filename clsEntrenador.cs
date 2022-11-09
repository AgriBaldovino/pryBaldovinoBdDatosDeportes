using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace pryBaldovinoBdDatos2
{
    internal class clsEntrenador
    {

        private OleDbConnection ConexionBD = new OleDbConnection();
        private OleDbCommand ComandoBD = new OleDbCommand();
        private OleDbDataAdapter Adaptador = new OleDbDataAdapter();
        

        private string CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + "DEPORTE.accdb";
        private string Tabla = "ENTRENADORES";


        private string CodigoDeportista;
        private string NombreE;
        private string ApellidoE;
        private string DireccionE;
        private string ProvinciaE;
        private string DeporteE;
        public string CDeportista
        {
            get { return CodigoDeportista; }
            set { CodigoDeportista = value; }
        }

        public string Nombre
        {
            get { return NombreE; }
            set { NombreE = value; }
        }

        public string Apellido
        {
            get { return ApellidoE; }
            set { ApellidoE = value; }
        }

        public string Direccion
        {
            get { return DireccionE; }
            set { DireccionE = value; }
        }

        public string Provincia
        {
            get { return ProvinciaE; }
            set { ProvinciaE = value; }
        }

        public string Deporte
        {
            get { return DeporteE; }
            set { DeporteE = value; }
        }


        public void Buscar(string Codigo)
        {
            try
            {
                ConexionBD.ConnectionString = CadenaConexion;
                ConexionBD.Open();

                ComandoBD.Connection = ConexionBD;
                ComandoBD.CommandType = CommandType.TableDirect;
                ComandoBD.CommandText = Tabla;
                OleDbDataReader Lector = ComandoBD.ExecuteReader();

                //Si hay registros ingresa
                if (Lector.HasRows)
                {
                    //Mientras tenga datos en la tabla, esto lo va a leer
                    while (Lector.Read())
                    {
                        if (Lector.GetString(0) == Codigo)
                        {
                            CodigoDeportista = Lector.GetString(0);
                            NombreE = Lector.GetString(1);
                            ApellidoE = Lector.GetString(2);
                            DireccionE = Lector.GetString(3);
                            ProvinciaE = Lector.GetString(4);
                            DeporteE = Lector.GetString(5);
                        }
                    }
                }
                ConexionBD.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la busqueda");
            }
        }

        public void Eliminar(string CodigoDepo)
        {
            try
            {
                string Sql = "DELETE FROM ENTRENADORES WHERE ('" + CodigoDepo + "'= [CODIGO DEPORTISTA])";

                ConexionBD.ConnectionString = CadenaConexion;
                ConexionBD.Open();

                ComandoBD.Connection = ConexionBD;
                ComandoBD.CommandType = CommandType.Text;
                ComandoBD.CommandText = Sql;
                ComandoBD.ExecuteNonQuery();

                ConexionBD.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar entrenador");
            }
            //ConexionBD.Close();
        }

        public void Modificar(string CDeportista)
        {
            try
            {
                string Sql = "UPDATE ENTRENADORES SET [NOMBRE] = '" + Nombre + "', [APELLIDO]= '" + Apellido + "', [DIRECCION]= '" + Direccion + "', [PROVINCIA]= '" + Provincia + "', [DEPORTE]= '" + Deporte + "' WHERE '" + CDeportista + "'= [CODIGO DEPORTISTA]";
                
                ConexionBD.ConnectionString = CadenaConexion;
                ConexionBD.Open();
                ComandoBD.Connection = ConexionBD;
                ComandoBD.CommandType = CommandType.Text;
                ComandoBD.CommandText = Sql;
                ComandoBD.ExecuteNonQuery();
                ConexionBD.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        public void Agregar()
        {
            try
            {
                string Sql = "INSERT INTO ENTRENADORES ([CODIGO DEPORTISTA], [NOMBRE], [APELLIDO], [DIRECCION], [PROVINCIA], [DEPORTE])" +
                    "VALUES ('" + CodigoDeportista + "','" + Nombre + "','" + Apellido + "','" + Direccion + "','" + Provincia +"','" + Deporte +"')";
                ConexionBD.ConnectionString = CadenaConexion;
                ConexionBD.Open();

                ComandoBD.Connection = ConexionBD;
                ComandoBD.CommandType = CommandType.Text;
                ComandoBD.CommandText = Sql;
                ComandoBD.ExecuteNonQuery();

                ConexionBD.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido registrar el dato");
            }
            
        }

    }
}
