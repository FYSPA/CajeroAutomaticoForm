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
    public partial class Deposito : Form
    {
        static string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True";

        public Deposito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string numeroCuenta = txtCuentaDeposito.Text;
                decimal monto;

                if (!decimal.TryParse(txtMontoDeposito.Text, out monto))
                {
                    MessageBox.Show("Por favor, ingresa un monto válido.");
                    return;
                }

                if (monto <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor a cero.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(cadenaconexion))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Actualizar el saldo del cliente
                        string queryActualizarSaldo = "UPDATE DatosCliente SET Saldo = Saldo + @Monto WHERE NoCuentaPrincipal = @NoCuentaPrincipal";
                        using (SqlCommand command = new SqlCommand(queryActualizarSaldo, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Monto", monto);
                            command.Parameters.AddWithValue("@NoCuentaPrincipal", numeroCuenta);
                            command.ExecuteNonQuery();
                        }

                        // Calcular y actualizar los puntos del cliente
                        int puntos = (int)(monto / 100) * 10;
                        string queryActualizarPuntos = "UPDATE DatosCliente SET Puntos = ISNULL(Puntos, 0) + @Puntos WHERE NoCuentaPrincipal = @NoCuentaPrincipal";
                        using (SqlCommand command = new SqlCommand(queryActualizarPuntos, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Puntos", puntos);
                            command.Parameters.AddWithValue("@NoCuentaPrincipal", numeroCuenta);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show($"Depósito realizado con éxito. Has recibido {puntos} puntos.");

                        txtCuentaDeposito.Clear();
                        txtMontoDeposito.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error al realizar el depósito: {ex.Message}");
                    }
                } 
            } 
        
            
            private void ActualizarPuntos(string numeroCuenta, int puntos, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE DatosCliente SET Puntos = Puntos + @Puntos WHERE NoCuentaPrincipal = @NoCuentaPrincipal";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Puntos", puntos);
                command.Parameters.AddWithValue("@NoCuentaPrincipal", numeroCuenta);
                command.ExecuteNonQuery();
            }
        }

       

     
        private decimal ObtenerSaldo(string numeroCuenta, SqlConnection connection)
        {
            string query = "SELECT Saldo FROM DatosCliente WHERE NoCuentaPrincipal = @NoCuentaPrincipal";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NoCuentaPrincipal", numeroCuenta);
                object result = command.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
            }
        }

        private void ActualizarSaldo(string numeroCuenta, decimal monto, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "UPDATE DatosCliente SET Saldo = Saldo + @Monto WHERE NoCuentaPrincipal = @NoCuentaPrincipal";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Monto", monto);
                command.Parameters.AddWithValue("@NoCuentaPrincipal", numeroCuenta);
                command.ExecuteNonQuery();
            }
        }
    

    private void button2_Click(object sender, EventArgs e)
        {
            txtCuentaDeposito.Clear();
            txtMontoDeposito.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
