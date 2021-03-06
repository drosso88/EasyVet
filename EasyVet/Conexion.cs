﻿using System;
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

        bool correcta = false;
        public Conexion()
        {

            conexion = new MySqlConnection("Server=192.168.182.167; Database=veterinario; Uid=root; Pwd=; port=3306");


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
                    correcta = BCrypt.Net.BCrypt.Verify(contrasena, contrasenaObtenida);
                    if (correcta)
                    {
                        return resultado.GetString(0);
                    }
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
        public String insertoMascota(String nombre, String especie, String raza, String sexo, String fecha_nacimiento, String email)
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
        public String insertoUsuario(String dni_trabajador, String nombre, String apellido_1, String apellido_2, String ocupacion, String direccion, String telefono, String email, String codigo_postal, String usuario, String contrasena)
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
        //metodo que bisca mascotas filtrando, Igor
        public DataTable buscoMascota(String nombre, String raza, String email, String especie, String sexo, String telefono)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM mascota,cliente WHERE mascota.propietario=cliente.cliente_id AND" +
                    "(mascota.nombre=@nombre OR mascota.raza=@raza OR mascota.sexo=@sexo OR mascota.especie=@especie OR cliente.email=@email OR cliente.telefono=@telefono)", conexion);
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
            catch (Exception e)
            {
                throw e;
            }
        }
        //metodo hecho por igor 
        public DataTable dameProfesional(int num)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT nombre,apellido_1 FROM empleado where empleado_id=@num", conexion);
                consulta.Parameters.AddWithValue("@num", num);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable empleado = new DataTable();
                empleado.Load(resultado);
                conexion.Close();
                return empleado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       

        public DataTable dameCategorias(String categoria)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM tienda WHERE categoria=@categoria", conexion);
                consulta.Parameters.AddWithValue("@categoria", categoria);
                DataTable tienda_seleccionada = new DataTable();
                MySqlDataReader resultado = consulta.ExecuteReader();
                tienda_seleccionada.Load(resultado);
                conexion.Close();
                return tienda_seleccionada;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public DataTable dameTodo()
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM empleado", conexion);
                MySqlDataReader resultado = consulta.ExecuteReader();
                DataTable todo = new DataTable();
                todo.Load(resultado);
                conexion.Close();
                return todo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String pidoCita(String nombre_empleado,String apellido, String email,String nombre,String fecha)
        {
            try
            {
                conexion.Open();

                MySqlCommand consulta =
                    new MySqlCommand("SET foreign_key_checks=0;INSERT INTO veterinario.cita(cita_id,cod_empleado,cod_cliente,cod_mascota,fecha) VALUES" +
                    "(NULL,(SELECT empleado_id FROM veterinario.empleado  WHERE nombre  like @nombre_empleado and apellido_1 like @apellido)," +
                    "(SELECT cliente_id FROM veterinario.cliente  WHERE email like @email)," +
                    "(SELECT mascota_id FROM mascota,cliente where mascota.propietario=cliente.cliente_id and cliente.email like @email),@fecha)", conexion);
                consulta.Parameters.AddWithValue("@nombre_empleado", nombre_empleado);
                consulta.Parameters.AddWithValue("@apellido", apellido);
                consulta.Parameters.AddWithValue("@email", email);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@fecha", fecha);


                consulta.ExecuteNonQuery();
                conexion.Close();

                return "la cita concertada";
            }
            catch (Exception e)
            {
                throw e;
            }


           
        }
    }
}


