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
    public partial class NuevoUsuario : Form
    {
        Conexion miConexion = new Conexion();
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
           // String resultado = miConexion.insertoUsuario(nombre.Text, ap1.Text, ap2.Text, cp.Text, direccion.Text,email.Text, telefono.Text, contraseña.Text);
            //MessageBox.Show(resultado);
        }
    }


      
    }

