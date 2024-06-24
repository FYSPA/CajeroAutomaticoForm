using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomaticoForm
{
    public partial class TransferirNoCuenta : Form
    {

        static string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True";
        SqlConnection conexion = new SqlConnection(cadenaconexion);

       

        public string NumeroDeCuenta { get; }


        public TransferirNoCuenta(string numeroDeCuenta)
        {
            InitializeComponent();
            // Usa el número de cuenta en tu lógica, por ejemplo:
            label13.Text = "No.Cuenta Propietario " + numeroDeCuenta;


         
        }



        private void btnTransferir_Click(object sender, EventArgs e)
        {
            string cuentaPrincipal = txtCuentaOrigen.Text;
            string cuentaRecibido = txtCuentaDestino.Text;
            decimal monto;

            if (!decimal.TryParse(txtMonto.Text, out monto))
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
                    // Verificar el saldo de la cuenta principal
                    decimal saldoPrincipal = ObtenerSaldo(cuentaPrincipal, connection, transaction);
                    if (saldoPrincipal < monto)
                    {
                        MessageBox.Show("Saldo insuficiente en la cuenta principal.");
                        transaction.Rollback();
                        return;
                    }

                    // Descontar el monto de la cuenta principal
                    ActualizarSaldo(cuentaPrincipal, -monto, connection, transaction);

                    // Agregar el monto a la cuenta recibida
                    ActualizarSaldo(cuentaRecibido, monto, connection, transaction);

                    transaction.Commit();

                    // Mostrar mensaje con el saldo actualizado
                    saldoPrincipal = ObtenerSaldo(cuentaPrincipal, connection, transaction);
                    MessageBox.Show($"Transferencia realizada con éxito. Tu saldo actual es: {saldoPrincipal:C}");

                    txtMonto.Clear();
                    txtCuentaOrigen.Clear();
                    txtCuentaDestino.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al realizar la transferencia: {ex.Message}");
                    transaction.Rollback();
                }
            }
        }

        private decimal ObtenerSaldo(string numeroCuenta, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT Saldo FROM DatosCliente WHERE NoCuentaPrincipal = @NoCuentaPrincipal";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@NoCuentaPrincipal", numeroCuenta);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0m;
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCuentaDestino.Clear();
            txtCuentaOrigen.Clear();
            txtMonto.Clear();
        }
    }
}