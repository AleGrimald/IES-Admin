using IES_Admin;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace CDatos
{
    public class CDatosMaterias
    {
        private readonly CConexion con = new CConexion();
        private MySqlCommand comando;
        private DataTable tabla = new DataTable();
        private MySqlDataReader reader;
        private string procedimiento;

        public string Procedimiento { get => procedimiento; set => procedimiento = value; }

        public CDatosMaterias()
        {

        }

        public CDatosMaterias(string _procedimiento)
        {
            Procedimiento = _procedimiento;
        }

        

        public DataTable MostrarMateria()
        {
            try
            {
                comando = new MySqlCommand(Procedimiento, con.Conectar());
                comando.CommandType = CommandType.StoredProcedure;
                reader = comando.ExecuteReader();
                tabla.Load(reader);
                return tabla;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(
                    "No se pudieron cargar algunos datos\n" + e.Message,
                    "Error - Sistema IES",
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
    }
}
