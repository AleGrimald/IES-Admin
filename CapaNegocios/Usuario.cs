using IES_Admin.CapDatos;
using MySql.Data.MySqlClient;

namespace IES_Admin.Clases
{
    public class Usuario
    {
        private string user;
        private string passw;

        public string User { get => user; set => user = value; }
        public string Passw { get => passw; set => passw = value; }

        public Usuario(string _user, string _passw)
        {
            User = _user;
            Passw = _passw;
        }


        public bool ValidarUsuario()
        {
            CDatosUsuario datosUsuario = new CDatosUsuario(User, Passw);
            MySqlDataReader reader = datosUsuario.ValidarUsuario();
            bool validar = false;

            while (reader.Read())
            {
                if ((reader[0].ToString() == User) && (reader[1].ToString() == Passw))
                {
                    validar = true;
                    return validar;
                }
                else
                {
                    validar = false;
                }
            }

            return validar;
        }
    }
}
