using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EasyVet
{
    class Conexion
    {
        public MySqlConnection conexion;
    
        public Conexion()
        {
            conexion =new MySqlConnection("Server=192.168.182.145; Database=veterinario; Uid=root; Pwd=; port=3306");
        }
        public DataTable comprueboUsuario()
        {
            try 
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT dni_trabajador,usuario,contrasena FROM veterinario.empleados", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable empleados = new DataTable();
                empleados.Load(resultado);
                conexion.Close();
                return empleados;
            }
            catch(MySqlException e)
            {
                throw e;
            }



        }
    }
}
