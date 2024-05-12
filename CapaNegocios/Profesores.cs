using IES_Admin;
using MySql.Data.MySqlClient;
using System.Data;

namespace CapaNegocio
{
    public class Profesores : Persona
    {
        private string matricula;
        private string modulo;
        private int id;
        private string materia;
        private string anio;
        private CDatosPersona objProfesor = new CDatosPersona();
        
        public string Modulo { get => modulo; set => modulo = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public int Id { get => id; set => id = value; }
        public string Materia { get => materia; set => materia = value; }
        public string Anio { get => anio; set => anio = value; }
        public CDatosPersona ObjProfesor { get => objProfesor;}

        public Profesores()
        {

        }

        public Profesores(string _procedimiento)
        {
            Procedimiento = _procedimiento;
        }

        public Profesores(int _id)
        {
            Id = _id;
        }

        public Profesores(int _id, string _parametro, string _procedimiento)
        {
            Id = _id;
            ParametroSimple = _parametro;
            Procedimiento = _procedimiento;
        }

        public Profesores(int _id,string _nombre,string _dni,string _direcc,string _telefono,string _matricula,string _modulosTexto,string _materia,string _anio,string _procedimiento, string[] _parametro)
        {
            Id = _id;
            Nombre = _nombre;
            Dni = _dni;
            Direccion = _direcc;
            Telefono = _telefono;
            Matricula = _matricula;
            Modulo = _modulosTexto;
            Materia = _materia;
            Anio = _anio;
            Procedimiento = _procedimiento;
            Parametro = _parametro;
        }

        public DataTable Mostrar4Datos()
        {
            return ObjProfesor.Mostrar(Procedimiento);
        }

        public MySqlDataReader MostrarDatosCompletos()
        {
            MySqlDataReader reader = ObjProfesor.MostrarProfesor(Id, ParametroSimple, Procedimiento);
            return reader;
        }

        public void AgregarProfesor()
        {
            dynamic[] arrDatosProfesor = { Id, Nombre, Dni, Direccion, Telefono, Matricula, Modulo, Materia, Anio };
            ObjProfesor.Agregar(arrDatosProfesor, Parametro, Procedimiento);
        }

    }
}
