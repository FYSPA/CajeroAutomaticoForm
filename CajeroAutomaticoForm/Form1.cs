using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CajeroAutomaticoForm
{
    public partial class Form1 : Form
    {
        static string cadenaconexion = "";
        SqlConnection conexion = new SqlConnection(cadenaconexion);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCLAVE.Clear();
            txtUSUARIO.Clear();
        }




        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





        private void btnEnter_Click(object sender, EventArgs e)
        {

            string usuario = txtUSUARIO.Text;
            string clave = txtCLAVE.Text;

            SqlConnection connection = new SqlConnection(cadenaconexion);

            // Query para verificar las credenciales
            string query = "SELECT * FROM Usuarios WHERE usuario = @usuario AND clave = @clave";

            // Comando para ejecutar la consulta
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@clave", clave);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Si las credenciales son válidas, podrías abrir el formulario principal del cajero automático u otro formulario
                    MessageBox.Show("Inicio de sesión exitoso");



                }
                else
                {
                    MessageBox.Show("Nombre de usuario o clave incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
