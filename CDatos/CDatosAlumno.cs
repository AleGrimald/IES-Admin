using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace IES_Admin
{
    public class CDatosAlumno
    {
        private CConexion con = new CConexion();
        private MySqlDataReader reader;
        private DataTable tabla = new DataTable();
        private MySqlCommand comando;

        public DataTable MostrarAlumnos(string _procedimiento)
        {
            try
            {
                comando = new MySqlCommand(_procedimiento, con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                reader = comando.ExecuteReader();
                tabla.Load(reader);

                return tabla;
            }catch (MySqlException e){
                MessageBox.Show(
                    $"No se pudo conectar a la Base de Datos.\n {e.Message}",
                    "Error de Conexion.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public DataTable IdAlumno()
        {
            try
            {
                comando = new MySqlCommand("SELECT idalumno FROM alumno", con.Conectar());
                MySqlDataReader reader = comando.ExecuteReader();
                tabla.Load(reader);
                return tabla;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    $"No se pudo conectar a la Base de Datos.\n {e.Message}",
                    "Error de Conexion.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public void AgregarAlumno(string _nombre, string _dni, string _edad, string _direccion, string _telefono, string _legajo, string _carrera, DateTime _fecha, string _anio, string _id)
        {
            
            try
            {
                int id = int.Parse(_id) +1;
                string[] parametros = { "nombre", "dni", "edad", "direccion", "telefono", "legajo", "carrera", "fecha", "anio", "idalumno"};
                dynamic[] valores = { _nombre, _dni, _edad, _direccion, _telefono, _legajo, _carrera, _fecha, _anio, id };
                comando = new MySqlCommand("AgregarAlumno", con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parametros.Length; i++)
                {
                    comando.Parameters.AddWithValue(parametros[i], valores[i]);
                }

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    $"Error de Conexion con la Base de Datos.\n Error: {e.Message}",
                    "Error de Conexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public void EditarAlumno(string _nombre, string _dni, string _edad, string _direccion, string _telefono, string _legajo, string _carrera, DateTime _fecha, string _anio, string _id)
        {
            try
            {
                int id = int.Parse(_id);
                string[] parametros = { "_nombre", "_dni", "_edad", "_direccion", "_telefono", "_legajo", "_carrera", "_fecha", "_anio", "_idalumno" };
                dynamic[] valores = { _nombre, _dni, _edad, _direccion, _telefono, _legajo, _carrera, _fecha, _anio, id };
                comando = new MySqlCommand("EditarAlumno", con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parametros.Length; i++)
                {
                    comando.Parameters.AddWithValue(parametros[i], valores[i]);
                }

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    $"Error de Conexion con la Base de Datos.\n Error: {e.Message}",
                    "Error de Conexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public void EliminarAlumno(string _id)
        {
            try
            {
                int id = int.Parse(_id);
                comando = new MySqlCommand("EliminarAlumno", con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("_idalumno", id);

                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    $"No se pudo conectar a la Base de Datos.\n {e.Message}",
                    "Error de Conexion.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }
            finally
            {
                con.Desconectar();
            }
        }

    }
}
