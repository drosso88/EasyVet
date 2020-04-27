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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String resultado = miConexion.insertoUsuario(dni.Text, nombre.Text, ap1.Text, textBox8.Text, cargo.Text, direccion.Text, telefono.Text, email.Text, cp.Text, nombre.Text + ap1.Text, contrasena.Text);
            MessageBox.Show(resultado);
            this.Hide();
        }
    }


      
    }

