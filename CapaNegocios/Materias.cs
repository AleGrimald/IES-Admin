using CDatos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Materias
    {
        private CDatosMaterias objMateria;
        private string procedimiento;

        public CDatosMaterias ObjMateria { get => objMateria; set => objMateria = value; }
        public string Procedimiento { get => procedimiento; set => procedimiento = value; }

        public Materias()
        {

        }

        public Materias(string _procedimiento)
        {
            Procedimiento = _procedimiento;
        }

        public DataTable MostrarMateria()
        {
            ObjMateria = new CDatosMaterias(Procedimiento);
            return ObjMateria.MostrarMateria();
        }
    }
}
