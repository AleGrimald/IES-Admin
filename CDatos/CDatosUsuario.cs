using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace IES_Admin.CapDatos
{
    public class CDatosUsuario
    {
        private string user;
        private string passw;
        

        public string User { get => user; set => user = value; } 
        public string Passw { get => passw; set => passw = value; }

        public CDatosUsuario(string _user, string _passw)
        {
            User = _user;
            Passw = _passw;
        }

        public MySqlDataReader ValidarUsuario()
        {
            try
            {
                CConexion cn = new CConexion();
                MySqlDataReader reader;
                MySqlCommand comando = new MySqlCommand("MostrarUsuario", cn.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("id", User);
                comando.Parameters.AddWithValue("passw", Passw);
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
