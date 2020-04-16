using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace EasyVet
{
    public partial class Login : Form
    {

        Conexion miConexion = new Conexion();
        DataTable empleados = new DataTable();
       
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String textoContrasena = textBox2.Text;
            string myHash = BCrypt.Net.BCrypt.HashPassword(textoContrasena, BCrypt.Net.BCrypt.GenerateSalt());
            String resultado = miConexion.comprueboUsuario(textBox1.Text, myHash);
            MessageBox.Show(resultado);
            if (resultado != "error de usuario/contraseña")
            {
                this.Hide();
                VentanaPpal ventana = new VentanaPpal();
                ventana.Show();
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
