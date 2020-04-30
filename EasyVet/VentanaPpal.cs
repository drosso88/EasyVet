using System;
using System.Data;
using System.Windows.Forms;


namespace EasyVet
{

    //Interfaz y datos en BBDD por Rocio. Clases y Metodos por Igor

    public partial class VentanaPpal : Form
    {
        Conexion miConexion = new Conexion();
        DataTable busquedaPerro = new DataTable();
        DataTable empleados = new DataTable();
        Login miLogin = new Login();
        
        public VentanaPpal()
        {
            InitializeComponent();
            dameTiempo();
            empleados = miConexion.dameTodo();
            foreach (DataRow empleado in empleados.Rows)
            {
                comboBox5.Items.Add(empleado["nombre"].ToString() + " " + empleado["apellido_1"].ToString());
            }
        }
      
        
       // IGOR: metodo que guarda el día y hora de la cita

        public String dameTiempo()
        {
            String fecha = monthCalendar1.ToString();
            fecha = fecha.Substring(58, 11);
            String miFecha = "";

            miFecha = fecha.Substring(7, 4) + "-" + fecha.Substring(4, 2) + "-" + fecha.Substring(1, 2) + " ";
            miFecha += comboBox6.Text;
            Console.WriteLine("longitud" + miFecha);

            return miFecha;

        }

        public String dameNombreEmpleado()
        {
            String nombre = comboBox5.Text;
            int espacio = nombre.IndexOf(' ');
            if (nombre.Length > 0)
            {
                String dameNombre = nombre.Substring(0, espacio);

                return dameNombre;
            }
            return "no has seleccionado veterinario";
        }
        public String dameApellidoEmpleado()
        {
            String nombre = comboBox5.Text;
            int espacio = nombre.IndexOf(' ');
            if (nombre.Length > 0)
            {
                String dameApellido = nombre.Substring(espacio + 1);

                return dameApellido;
            }
            return "No has seleccionado veterinario";
        }

        //IGOR tienda
        public String elijoCategoria()
        {
           
            String resultado = "";
                if(checkBox5.Checked)
            {
                resultado = "antiparasi";
            }
                if(checkBox10.Checked)
            {
                resultado = "collar ant";
            }
                if(checkBox6.Checked)
            {
                resultado = "analgesia";
            }
                if(checkBox8.Checked)
            {
                resultado = "pomadas";
            }
                if(checkBox7.Checked)
            {
                resultado = "antibiotic";
            }
                if(checkBox14.Checked)
            {
                resultado = "Juguetes";
            }
                if(checkBox16.Checked)
            {
                resultado = "Piensos";
            }
                if(checkBox15.Checked)
            {
                resultado = "Collares, ";
            }
                if(checkBox13.Checked)
            {
                resultado = "Golosinas";
            }
                if(checkBox11.Checked)
            {
                resultado = "otros";
            }
                if(checkBox9.Checked)
            {
                resultado = "otros2";
            }



            return resultado;
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
         
        //Rocio
        private void button5_Click(object sender, EventArgs e)
        {
            String resultado = miConexion.insertoCliente(textBox1.Text, textBox2.Text, textBox16.Text, textBox4.Text, textBox3.Text);
            String resultado1 = miConexion.insertoMascota(textBox7.Text, comboBox4.Text, textBox9.Text, comboBox1.Text, textBox11.Text,textBox3.Text);
            Agenda.Show();
            MessageBox.Show( "mascota y propietario añadidos");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        //Igor// al pulsar el extendible se manda una solicitud a la base de datos para seleccionar todos los 
        //profesionales de la empresa , con lo que en teorio este combobox se rellenar con la info de la bbdd
        //(pero en teoria hasta cerdos vuelan)
        {
            dataGridView1.DataSource = miConexion.buscoMascota(textBox12.Text,textBox13.Text,textBox14.Text,comboBox3.Text,comboBox2.Text,textBox15.Text);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView3.DataSource = miConexion.dameCategorias(elijoCategoria());
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            //String resultado = miConexion.pidoCita(dameNombreEmpleado(),dameApellidoEmpleado(), textBox3.Text, textBox7.Text, dameTiempo());
            //MessageBox.Show(resultado);
           


        }
    }
}
