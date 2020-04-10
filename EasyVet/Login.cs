using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            String usuarioIntroducido = textBox1.Text;
            String contrasenaIntroducida = textBox2.Text;
            ////////////////////////////
            empleados = miConexion.comprueboUsuario();
            String usuarioAlmacenda = empleados.Rows[0]["usuario"].ToString();
            String contrasenaAlmacenada = empleados.Rows[0]["contrasena"].ToString();
            Console.WriteLine(contrasenaAlmacenada);
            if (usuarioIntroducido == usuarioAlmacenda && contrasenaIntroducida == contrasenaAlmacenada)
            {
                //Rocio: tester para comprobar estética mientras diseño
                VentanaPpal ventana = new VentanaPpal();
                ventana.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
