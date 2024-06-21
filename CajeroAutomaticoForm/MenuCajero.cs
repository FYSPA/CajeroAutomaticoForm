using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomaticoForm
{
    public partial class MenuCajero : Form
    {
        static string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(cadenaconexion);


        private string nomUsuari { get; set; }
        private string _usuario;


        public static void Maind()
        {
            Usuario usuario = new Usuario { nomUsuari = "tuNombreUsuario" };
            decimal saldo = usuario.ConsultarSaldo();

            MessageBox.Show($"El saldo actual es: {saldo:C}", "Saldo Actual");
        }

        public MenuCajero()
        {
            InitializeComponent();
            this.btnConsultarSaldo.Click += new System.EventHandler(this.btnConsultarSaldo_Click);
        }


        internal class Usuario
        {
            public string nomUsuari { get; set; }

            internal decimal ConsultarSaldo()
            {
                throw new NotImplementedException();
            }
        }

            public MenuCajero(string usuario)
            {
              InitializeComponent();
             _usuario = usuario;
             UpdateLabel();


              // Configurar el Timer
              hora = new Timer();
              hora.Interval = 1000; // Intervalo de 1 segundo
              hora.Tick += Timer_Tick; // Evento que se ejecuta cada vez que el Timer cuenta el intervalo
              hora.Start(); // Iniciar el Timer
            }





        private void UpdateLabel()
        {
            labTitular.Text = "Titular:" + _usuario;
        }



        private void labHora_Click(object sender, EventArgs e)
        {
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualizar el Label con la hora actual
            labh.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Form1 nuevomenu = new Form1();
            nuevomenu.FormClosed += (s, args) => this.Close();
            nuevomenu.Show();

            this.Hide();
        }

        private void btnConsultarSaldo_Click(object sender, EventArgs e)
        {
            string nombreUsuario = "tuNombreUsuario"; // Puedes obtener esto de un TextBox u otro control
            decimal saldo = ConsultarSaldo(nombreUsuario);

            MessageBox.Show($"El saldo actual es: {saldo:C}", "Saldo Actual");
        }



            private void btnRetirarSaldo_Click(object sender, EventArgs e)
        {

        }

        private void btnCanjearPuntos_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public decimal ConsultarSaldo(string nombreUsuario)
        {
            decimal saldo = 0;

            string query = "SELECT Saldo FROM Clientes WHERE usuario = @usuario";

            using (SqlConnection connection = new SqlConnection(cadenaconexion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", nombreUsuario);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        saldo = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consultar el saldo: {ex.Message}");
                }
            }

            return saldo;
        }

    }

   }

