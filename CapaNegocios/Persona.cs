using System;
using System.Collections.Generic;
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

        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public Persona(){
        }
        public Persona(string _nombre, string _dni, string _direccion, string _telefono) { 
            this.Nombre = _nombre;
            this.Dni = _dni;
            this.Direccion = _direccion;
            this.Telefono = _telefono;
        }
    }
}
