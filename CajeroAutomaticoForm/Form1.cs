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
        static string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(cadenaconexion);


        public string usu { get { return txtUSUARIO.Text; } }
        public string clav { get { return txtCLAVE.Text; } }
        public Form1()
        {
            InitializeComponent();

            btnEnter.Click += btnEnter_Click;
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




        private bool mensajeMostrado = false;
        private bool error = false;
        private MenuCajero menuCajero;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string usuario = txtUSUARIO.Text;
            string clabe = txtCLAVE.Text;

            string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True"; // Reemplaza con tu cadena de conexión
            SqlConnection connection = new SqlConnection(cadenaconexion);

            // Query para verificar las credenciales
            string query = "SELECT * FROM CLIENTES WHERE Usuario = @usuario COLLATE Latin1_General_CS_AS AND Clabe = @clabe COLLATE Latin1_General_CS_AS";

            // Comando para ejecutar la consulta
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@clabe", clabe);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Si las credenciales son válidas, mostrar mensaje y abrir el formulario principal
                    if (!mensajeMostrado)
                    {
                        MessageBox.Show("Inicio de sesión exitoso");
                        mensajeMostrado = true;
                    }

                    this.Hide();

                    if (menuCajero == null)
                    {
                        menuCajero = new MenuCajero(usuario, clabe);
                        menuCajero.FormClosed += (s, args) => { this.Close(); menuCajero = null; };
                    }

                    menuCajero.Show();
                }
                else
                {
                    if (!error)
                    {
                        MessageBox.Show("Nombre de usuario o clave incorrectos");
                        error = true;
                    }
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

        public string usuario
        {
            get { return txtUSUARIO.Text; }
        }

        public string Clave
        {
            get { return txtCLAVE.Text; }
        }
      
    }
}
