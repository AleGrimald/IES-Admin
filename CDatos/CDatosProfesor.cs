using IES_Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CDatosProfesor
    {
        private int id;

        public int Id { get => id; set => id= value; }

        public CDatosProfesor() { 
        }

        public CDatosProfesor(int _id)
        {
            Id = _id;
        }

        public MySqlDataReader MostrarProfesor()
        {
            try
            {
                CConexion cn = new CConexion();
                MySqlDataReader reader;
                MySqlCommand comando = new MySqlCommand("MostraDatosProfesor", cn.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("_id", Id);
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
    }
}
