using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES_Admin
{
    public class Persona
    {
        private string nombre;
        private string dni;
        private string direccion;
        private string telefono;
        private string procedimiento;
        private string[] parametro;
        private string parametroSimple;
        private readonly CDatosPersona datos = new CDatosPersona();
        private int id;


        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Procedimiento { get => procedimiento; set => procedimiento = value; }
        public string[] Parametro { get => parametro; set => parametro = value; }
        public string ParametroSimple { get => parametroSimple; set => parametroSimple = value; }
        public int Id { get => id; set => id = value; }

        public Persona(){
        }


        public int IdPersona()
        {
            DataTable tabla = datos.IdTabla(Procedimiento);
            int indiceUltimaFila = tabla.Rows.Count - 1;
            return indiceUltimaFila;
        }

        public void EliminarPersona()
        {
            datos.Eliminar(Id, ParametroSimple, Procedimiento);
        }
    }
}
