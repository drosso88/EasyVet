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

            conexion = new MySqlConnection("Server=192.168.182.160; Database=veterinario; Uid=root; Pwd=; port=3306");


        }
        //metodo para la conexion del login. Hecho por Igor
        public String comprueboUsuario(String usuario, String contrasena)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT *FROM veterinario.empleado WHERE usuario= @usuario", conexion);

                consulta.Parameters.AddWithValue("@usuario", usuario);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    String contrasenaObtenida = resultado.GetString("contrasena");
                    bool correcta = BCrypt.Net.BCrypt.Verify(contrasena, contrasenaObtenida);
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
        //metodo para añadir Cliente. Por Igor
        public String insertoCliente(String nombre, String apellido_1, String apellido_2, String telefono, String email)
        {
            try
            {
                conexion.Open();

                MySqlCommand consulta =
                    new MySqlCommand("SET foreign_key_checks=0;INSERT INTO veterinario.cliente(cliente_id,nombre,apellido_1,apellido_2,telefono,email,fecha_alta) VALUES" +
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
            catch (Exception e)
            {
                throw e;
            }

        }
        //metodo para añadir Cliente. Por Rocio
        public String insertoMascota(String nombre, String especie, String raza,String sexo, String fecha_nacimiento, String email)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand(
                   "SET foreign_key_checks=0;INSERT INTO veterinario.mascota(mascota_id,nombre, especie,raza,sexo,fecha_nacimiento,propietario)" +
                   "VALUES(NULL,@nombre,@especie, @raza, @sexo, @fecha_nacimiento,(SELECT cliente_id FROM veterinario.cliente  WHERE email=@email))", conexion);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@especie", especie);
                consulta.Parameters.AddWithValue("@raza", raza);
                consulta.Parameters.AddWithValue("@sexo", sexo);
                consulta.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                consulta.Parameters.AddWithValue("@email", email);
                consulta.ExecuteNonQuery();

                conexion.Close();
                return "se ha insertado mascota";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Rocio
        public String insertoUsuario(String dni_trabajador,String nombre, String apellido_1, String apellido_2,String ocupacion,String direccion, String telefono, String email, String codigo_postal,  String usuario, String contrasena)
        {
            try
            {
                conexion.Open();

                MySqlCommand consulta =
                    new MySqlCommand("SET foreign_key_checks=0;INSERT INTO veterinario.empleado(empleado_id,dni_trabajador,nombre,apellido_1,apellido_2,ocupacion," +
                    "direccion,telefono,email,codigo_postal,usuario,contrasena,fecha_alta) VALUES" +
                    "(NULL,@dni_trabajador,@nombre,@apellido_1,@apellido_2,@ocupacion,@direccion, @telefono, @email, @codigo_postal, @usuario,@contrasena,NULL);", conexion);
                consulta.Parameters.AddWithValue("@dni_trabajador", dni_trabajador);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@apellido_1", apellido_1);
                consulta.Parameters.AddWithValue("@apellido_2", apellido_2);
                consulta.Parameters.AddWithValue("@ocupacion", ocupacion);
                consulta.Parameters.AddWithValue("@direccion", direccion);
                consulta.Parameters.AddWithValue("@codigo_postal", codigo_postal);
                consulta.Parameters.AddWithValue("@telefono", telefono);
                consulta.Parameters.AddWithValue("@email", email);
                consulta.Parameters.AddWithValue("@usuario", usuario);
                consulta.Parameters.AddWithValue("@contrasena", contrasena);
               

                consulta.ExecuteNonQuery();
                conexion.Close();

                return "Empleado contratado!!!";
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public DataTable buscoMascota(String nombre,String raza, String email,String especie,String sexo,String telefono)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM mascota,cliente WHERE mascota.propietario=cliente.cliente_id AND" +
                    "(mascota.nombre=@nombre OR mascota.raza=@raza OR mascota.sexo=@sexo OR mascota.especie=@especie OR cliente.email=@email OR cliente.telefono=@telefono)",conexion);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@raza", raza);
                consulta.Parameters.AddWithValue("@email", email);
                consulta.Parameters.AddWithValue("@especie", especie);
                consulta.Parameters.AddWithValue("@sexo", sexo);
                consulta.Parameters.AddWithValue("@telefono", telefono);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable busquedaPerro = new DataTable();
                busquedaPerro.Load(resultado);

                conexion.Close();

                return busquedaPerro;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}


