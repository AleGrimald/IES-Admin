using CapaDatos;
using IES_Admin;
using MySql.Data.MySqlClient;

namespace CapaNegocio
{
    public class Profesores : Alumno
    {
        private int id;

        public new int Id { get => id; set => id = value; }

        public Profesores()
        {

        }

        public Profesores(int _id)
        {
            Id = _id;
        }

        public void MostrarProfesor()
        {
            Alumno objAlumno = new Alumno();
            objAlumno.MostrarAlumno("MostrarProfesores");
        }

        public MySqlDataReader MostrarDatosProfesor()
        {
            CDatosProfesor objDatos = new CDatosProfesor(Id);
            MySqlDataReader reader = objDatos.MostrarProfesor();

            return reader;
        }

    }
}
