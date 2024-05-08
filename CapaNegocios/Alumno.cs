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
        private string id;
        private readonly CDatosAlumno datosAlumno = new CDatosAlumno();

        public string Legajo { get => legajo; set => legajo = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Materia { get => materia; set => materia = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public string Anio { get => anio; set => anio = value; }
        public CDatosAlumno DatosAlumno { get => datosAlumno; }
        public string Id { get => id; set => id = value; }

        public Alumno()
        {

        }

        public Alumno(string _id)
        {
            Id = _id;
        }

        public Alumno(string _nombre, string _dni, string _edad, string _direccion, string _telefono, string _legajo, string _carrera, DateTime _fecha, string _anio, string _id)
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
        }

        public void AgregarAlumno()
        {
            DatosAlumno.AgregarAlumno(Nombre,Dni,Edad,Direccion,Telefono,Legajo,Carrera,FechaInicio,Anio, Id);
        }

        public void EditarAlumno()
        {
            DatosAlumno.EditarAlumno(Nombre, Dni, Edad, Direccion, Telefono, Legajo, Carrera, FechaInicio, Anio,Id);
        }

        public DataTable MostrarAlumno(string _procedimiento)
        { 
            return DatosAlumno.MostrarAlumnos(_procedimiento);
        }

        public void EliminarAlumno()
        {
            DatosAlumno.EliminarAlumno(Id);
        }

        public int IdAlumno()
        {
            DataTable tabla = DatosAlumno.IdAlumno();
            int indiceUltimaFila = tabla.Rows.Count-1;

            return indiceUltimaFila;
        }
    }
}
