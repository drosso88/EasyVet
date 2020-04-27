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
    
    public partial class VentanaPpal : Form
    {
        Conexion miConexion = new Conexion();
       // DataTable mascota = new DataTable();
        public VentanaPpal()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void Profil_Click(object sender, EventArgs e)
        {
            //Rocio: tester para comprobar estética mientras diseño
            //perfilVet ventana = new perfilVet();
            //ventana.Show()
            Perfil perfil = new Perfil();
            perfil.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String resultado = miConexion.insertoCliente(textBox1.Text, textBox2.Text, textBox16.Text, textBox4.Text, textBox3.Text);
            String resultado1 = miConexion.insertoMascota(textBox7.Text,textBox9.Text, comboBox1.Text, textBox11.Text,textBox3.Text);
           // MessageBox.Show( resultado1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String resultado2 = miConexion.buscoMascotas(textBox12.Text,textBox13.Text,textBox14.Text,);
        }
    }
}
