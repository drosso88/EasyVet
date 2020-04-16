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
            conexion =new MySqlConnection("Server=192.168.182.147; Database=veterinario; Uid=root; Pwd=; port=3306");
        }
        //metodo para la conexion del login. Hecho por Igor
        public String comprueboUsuario(String usuario, String contrasena)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT *FROM veterinario.empleado WHERE usuario= @usuario and contrasena=@contrasena", conexion);

                consulta.Parameters.AddWithValue("@usuario", usuario);
                consulta.Parameters.AddWithValue("@contrasena", contrasena);

                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    return resultado.GetString(0);
                }

                conexion.Close();
                return "error de usuario/contraseña";
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public String insertoCliente(String nombre, String apellido_1,String apellido_2, String telefono,String email)
            {
            try
            {
                conexion.Open();
                
                MySqlCommand consulta =
                    new MySqlCommand ("SET foreign_key_checks=0;INSERT INTO veterinario.cliente(id_cliente,nombre,apellido_1,apellido_2,telefono,email,fecha_alta) VALUES" +
                    "(NULL,@nombre,@apellido_1,@apellido_2,@telefono,@email,NULL);", conexion);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@apellido_1", apellido_1);
                consulta.Parameters.AddWithValue("@apellido_2", apellido_2);
                consulta.Parameters.AddWithValue("@telefono", telefono);
                consulta.Parameters.AddWithValue("@email", email);

                consulta.ExecuteNonQuery();
                conexion.Close();

                return "Ha sido insertado cliente y";
            }
            catch(Exception e)
            {
                throw e;
            }

            }
        public String insertoMascota(String nombre, String raza, String fecha_nacimiento, String email)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand(
                   "SET foreign_key_checks=0;INSERT INTO veterinario.mascota(id_mascota,nombre,raza,fecha_nacimiento,propietario)" +
                   "VALUES(NULL,@nombre,@raza,@fecha_nacimiento,(SELECT id_cliente FROM veterinario.cliente  WHERE email=@email))", conexion);
                consulta.Parameters.AddWithValue("@email", email);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@raza", raza);
                consulta.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                consulta.ExecuteNonQuery();

                conexion.Close();
                return "se ha insertado mascota";
            }
            catch (Exception e)
            {
                throw e;
            }
        }      
        
    }
}
