using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace IES_Admin
{
    public class CDatosPersona
    {
        private CConexion con = new CConexion();
        private MySqlDataReader reader;
        private DataTable tabla = new DataTable();
        private MySqlCommand comando;

        public CDatosPersona()
        {

        }

        public DataTable Mostrar(string _procedimiento)
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
                return tabla;
            }
            finally
            {
                con.Desconectar();
            }
        }

        public MySqlDataReader MostrarProfesor(int _id, string _parametro, string _procedimiento)
        {
            try
            {
                DataTable tabla = new DataTable();
                CConexion cn = new CConexion();
                MySqlDataReader reader;
                MySqlCommand comando = new MySqlCommand(_procedimiento, cn.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue(_parametro, _id);
                reader = comando.ExecuteReader();
                return reader;
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
        }

        public DataTable IdTabla(string _procedimiento)
        {
            try
            {
                comando = new MySqlCommand(_procedimiento, con.Conectar());
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

        public void Agregar(dynamic[] _arrDatosAlumno,string[] _parametros, string _procedimiento)
        {
            
            try
            {
                comando = new MySqlCommand(_procedimiento, con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < _parametros.Length; i++)
                {
                    comando.Parameters.AddWithValue(_parametros[i], _arrDatosAlumno[i]);
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

        public void Editar(dynamic[] _arrDatosAlumno, string[] _parametro, string _procedimiento)
        {
            try
            {
                comando = new MySqlCommand(_procedimiento, con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < _parametro.Length; i++)
                {
                    comando.Parameters.AddWithValue(_parametro[i], _arrDatosAlumno[i]);
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

        public void Eliminar(int _id, string _parametroSimple, string _procedimiento)
        {
            try
            {
                comando = new MySqlCommand(_procedimiento, con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue(_parametroSimple, _id);

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
