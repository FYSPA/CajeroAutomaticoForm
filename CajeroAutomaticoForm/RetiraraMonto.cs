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
    public partial class RetiraraMonto : Form
    {
        static string cadenaconexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=DBCajeroAutomatico;Integrated Security=True;";
        SqlConnection conexion = new SqlConnection(cadenaconexion);

        private string _usuario;
        private string _clave;

        public RetiraraMonto()
        {
            InitializeComponent();
        }

        public RetiraraMonto(string usu, string clav)
        {
            InitializeComponent();
            _usuario = usu;
            _clave = clav;
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            decimal monto;
            if (decimal.TryParse(txtRetiraMonto.Text, out monto) && monto > 0)
            {
                RetirarSaldo(_usuario, _clave, monto);
            }
            else
            {
                MessageBox.Show("Ingrese un monto válido.", "Error");
            }
        }


        private void RetirarSaldo(string usuario, string clave, decimal monto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaconexion))
            {
                string querySaldo = @"
        SELECT dc.Saldo 
        FROM Clientes c
        INNER JOIN DatosCliente dc ON c.Id_Cliente = dc.Id_Cliente
        WHERE c.Usuario = @Usuario AND c.Clabe = @Clabe";

                SqlCommand commandSaldo = new SqlCommand(querySaldo, conexion);
                commandSaldo.Parameters.AddWithValue("@Usuario", usuario);
                commandSaldo.Parameters.AddWithValue("@Clabe", clave);

                try
                {
                    conexion.Open();
                    object result = commandSaldo.ExecuteScalar();
                    if (result != null)
                    {
                        decimal saldo = Convert.ToDecimal(result);
                        if (saldo >= monto)
                        {
                            string queryRetiro = @"
                    UPDATE DatosCliente
                    SET Saldo = Saldo - @Monto
                    WHERE ID_Cliente = (
                        SELECT Id_Cliente FROM Clientes
                        WHERE Usuario = @Usuario AND Clabe = @Clabe
                    )";

                            SqlCommand commandRetiro = new SqlCommand(queryRetiro, conexion);
                            commandRetiro.Parameters.AddWithValue("@Monto", monto);
                            commandRetiro.Parameters.AddWithValue("@Usuario", usuario);
                            commandRetiro.Parameters.AddWithValue("@Clabe", clave);
                            commandRetiro.ExecuteNonQuery();

                            MessageBox.Show($"Retiro exitoso. Su nuevo saldo es: {saldo - monto:C}", "Saldo Actual");
                        }
                        else
                        {
                            MessageBox.Show("Saldo insuficiente.", "Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o clave incorrectos.", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al retirar saldo: {ex.Message}", "Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Cierra el formulario actual (RetiraraMonto)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtRetiraMonto.Clear();
        }
    }
}