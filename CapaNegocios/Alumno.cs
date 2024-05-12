using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace IES_Admin
{
    public class Alumno : Persona
    {
        private string legajo;
        private string carrera;
        private string edad;
        private string materia;
        private DateTime fechaInicio;
        private string anio;
        private readonly CDatosPersona datosAlumno = new CDatosPersona();

        public string Legajo { get => legajo; set => legajo = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Materia { get => materia; set => materia = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string Anio { get => anio; set => anio = value; }
        public CDatosPersona DatosAlumno { get => datosAlumno; }

        public Alumno()
        {

        }

        public Alumno(string _procedimiento)
        {
            Procedimiento = _procedimiento;
        }

        public Alumno(int _id, string _parametro, string _procedimiento)
        {
            Id = _id;
            ParametroSimple = _parametro;
            Procedimiento = _procedimiento;
        }

        public Alumno(string _nombre, string _dni, string _edad, string _direccion, string _telefono, string _legajo, string _carrera, DateTime _fecha, string _anio, int _id, string _procedimiento, string[] _parametro)
        {
            Nombre = _nombre;
            Dni = _dni;
            Edad = _edad;
            Direccion = _direccion;
            Telefono = _telefono;
            Legajo = _legajo;
            Carrera = _carrera;
            FechaInicio = _fecha;
            Anio = _anio;
            Id = _id;
            Procedimiento = _procedimiento;
            Parametro = _parametro;
        }

        public void AgregarAlumno()
        {
            dynamic[] arrDatosAlumno = { Nombre, Dni, Edad, Direccion, Telefono, Legajo, Carrera, FechaInicio, Anio, Id };
            DatosAlumno.Agregar(arrDatosAlumno,Parametro, Procedimiento);
        }

        public void EditarAlumno()
        {
            dynamic[] arrDatosAlumno = { Nombre, Dni, Edad, Direccion, Telefono, Legajo, Carrera, FechaInicio, Anio, Id };
            DatosAlumno.Editar(arrDatosAlumno, Parametro, Procedimiento);
        }

        public DataTable MostrarAlumno()
        { 
            return DatosAlumno.Mostrar(Procedimiento);
        }

    }
}
