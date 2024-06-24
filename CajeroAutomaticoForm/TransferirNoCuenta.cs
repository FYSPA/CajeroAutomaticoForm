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

        private string _cuentaOrigen;

        public string NumeroDeCuenta { get; }

        public TransferirNoCuenta(string numeroDeCuenta)
        {
            InitializeComponent();
            // Usa el número de cuenta en tu lógica, por ejemplo:
            label1.Text = "Transferencia para la cuenta " + numeroDeCuenta;

        }

      

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            String cuentaDestino = txtCuentaDestino.Text;
            decimal monto = decimal.Parse(txtMonto.Text);

            TransferirDinero(_cuentaOrigen, cuentaDestino, monto);

            this.Close();
        }

        private void TransferirDinero(string cuentaOrigen, string cuentaDestino, decimal monto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                // Iniciar una transacción para garantizar la consistencia de los saldos
                SqlTransaction transaction = null;
                try
                {
                    conexion.Open();
                    transaction = conexion.BeginTransaction();

                    // Actualizar el saldo de la cuenta de origen
                    string consultaOrigen = "UPDATE Clientes SET saldo = saldo - @monto WHERE cuenta = @NoCuentaPrincipal";
                    using (SqlCommand comandoOrigen = new SqlCommand(consultaOrigen, conexion, transaction))
                    {
                        comandoOrigen.Parameters.AddWithValue("@monto", monto);
                        comandoOrigen.Parameters.AddWithValue("@NoCuentaPrincipal", cuentaOrigen);
                        comandoOrigen.ExecuteNonQuery();
                    }

                    // Actualizar el saldo de la cuenta de destino
                    string consultaDestino = "UPDATE Clientes SET saldo = saldo + @monto WHERE cuenta = @NoCuentaPrincipal";
                    using (SqlCommand comandoDestino = new SqlCommand(consultaDestino, conexion, transaction))
                    {
                        comandoDestino.Parameters.AddWithValue("@monto", monto);
                        comandoDestino.Parameters.AddWithValue("@NoCuentaPrincipal", cuentaDestino);
                        comandoDestino.ExecuteNonQuery();
                    }

                    // Confirmar la transacción si todo está correcto
                    transaction.Commit();

                    MessageBox.Show($"Transferencia exitosa de {monto:C} de la cuenta {cuentaOrigen} a la cuenta {cuentaDestino}.", "Transferencia Exitosa");
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaction?.Rollback();
                    MessageBox.Show($"Error al realizar la transferencia: {ex.Message}", "Error");
                }
            }
        }


     
    }

   }

