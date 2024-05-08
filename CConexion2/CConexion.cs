using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IES_Admin
{
    public class CConexion
    {
        private static string server= "localhost";
        private static string db= "ies_admin";
        private static string user= "root";
        private static string pssw= "78531015aA@";
        private static string port= "3306";
        private MySqlConnection con = new MySqlConnection($"server={server};port={port};user id={user};password={pssw};database={db};");

        public MySqlConnection Conectar()
        {
            try
            {
                con.Open();
                return con;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }            
        }

        public MySqlConnection Desconectar()
        {
            try
            {
                con.Close();
                return con;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    $"No se pudo desconectar correctamente.\n Error: {e.Message}",
                    "Error al Desconectar",
                    MessageBoxButtons.OK
                    );
                throw;
            }
        }

    }
}
