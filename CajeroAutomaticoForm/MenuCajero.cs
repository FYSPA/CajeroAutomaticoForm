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

        private string _usuario;

        public MenuCajero()
        {
            InitializeComponent();

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



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
