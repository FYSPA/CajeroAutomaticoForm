using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CajeroAutomaticoForm.MenuCajero;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CajeroAutomaticoForm
{
    public partial class MenuCajero : Form
    {
        static string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(cadenaconexion);

        private string _usuario;
        private string _clabe;
    




        public MenuCajero(string usuario, string clabe)
        {
            InitializeComponent();
            _usuario = usuario;
            _clabe = clabe;
            UpdateLabel();

            this.btnConsultarSaldo.Click += new System.EventHandler(this.btnConsultarSaldo_Click);

            timer1.Interval = 1000;
            timer1.Tick += TimerTick;
            timer1.Start();

          
        }


        private void TimerTick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("hh,mm tt");
        }

       
        private void UpdateLabel()
        {
            labTitular.Text = "Titular: " + _usuario;
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

            decimal saldo = ConsultarSaldo(_usuario, _clabe);

            if (saldo >= 0)
            {
                MessageBox.Show($"El saldo actual es: {saldo:C}", "Saldo Actual");
            }
            else if (saldo == -1)
            {
                MessageBox.Show("Usuario o clave incorrectos.", "Error");
            }
            else if (saldo <= 0)
            {
                MessageBox.Show($"No tiene dinero en la cuenta, el saldo es {saldo:C}", "Saldo Insuficiente");
            }
        }



        private decimal ConsultarSaldo(string usuario, string clabe)
        {
            decimal saldo = -1;

            string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True";
            string query = @"
             SELECT dc.Saldo 
             FROM Clientes c
             INNER JOIN DatosCliente dc ON c.Id_Cliente = dc.Id_Cliente
             WHERE c.Usuario = @Usuario AND c.Clabe = @Clabe";

            using (SqlConnection connection = new SqlConnection(cadenaconexion))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Clabe", clabe);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        saldo = Convert.ToDecimal(result);
                    }
                    else
                    {
                        saldo = 0; // Establecer el saldo a cero si no tiene dinero en la cuenta
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al consultar el saldo: {ex.Message}");
                }
            }

            return saldo;
        }

        private void btnRetirarSaldo_Click(object sender, EventArgs e)
        {
            // Pasar los valores de usuario y clave al crear una instancia de RetiraraMonto
            RetiraraMonto nuevoMenu = new RetiraraMonto(_usuario, _clabe);
            nuevoMenu.FormClosed += (s, args) => this.Close();
            nuevoMenu.Show();
        }



        private void btnCanjearPuntos_Click(object sender, EventArgs e)
        {
            // Implementación para canjear puntos
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Transferencia_Click(object sender, EventArgs e)
        {
            string numeroDeCuenta = ObtenerCuentaPrincipal(_usuario, _clabe); // Obtén el número de cuenta de alguna manera
            if (!string.IsNullOrEmpty(numeroDeCuenta))
            {
                TransferirNoCuenta transferenciaForm = new TransferirNoCuenta(numeroDeCuenta);
                transferenciaForm.FormClosed += (s, args) => this.Close(); // Cerrar el formulario actual cuando se cierre el formulario de transferencia
                transferenciaForm.Show();
            }
            else
            {
                MessageBox.Show("No se pudo obtener el número de cuenta.");
            }

        }



            private string ObtenerCuentaPrincipal(string usuario, string clabe)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string query = @"
        SELECT DC.NoCuentaPrincipal 
        FROM DatosCliente DC
        INNER JOIN Clientes C ON DC.Id_Cliente = C.Id_Cliente 
        WHERE C.Usuario = @Usuario AND C.Clabe = @Clabe";

                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@Usuario", usuario);
                command.Parameters.AddWithValue("@Clabe", clabe);

                try
                {
                    conexion.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        throw new Exception("No se encontró la cuenta principal para el usuario proporcionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la cuenta principal: {ex.Message}", "Error");
                    return null;
                }
            }
        }

   

        private void MenuCajero_Load(object sender, EventArgs e)
        {
            string usuario = _usuario; // Usar el usuario almacenado en la clase en lugar del texto de un TextBox

            string numeroDeCuenta = ObtenerCuentaPrincipal(usuario, _clabe);

            if (!string.IsNullOrEmpty(numeroDeCuenta))
            {
                label11.Text = numeroDeCuenta;
            }
            else
            {
                label11.Text = "Número de cuenta no encontrado";
            }
        }

        

    }
}

