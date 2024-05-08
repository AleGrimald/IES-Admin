using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IES_Admin
{
    public partial class frmAdmin : Form
    {

        public frmAdmin()
        {
            InitializeComponent();

        }

        private void formAdmin_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            frmAlumno frmAlumno = new frmAlumno();
            frmAlumno.Show();
        }

        private void btnMostrarAlumno_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {
            frmAlumno frmAlumno = new frmAlumno();
            frmAlumno.Show();
        }

        private void btnMostrarProfesor_Click(object sender, EventArgs e)
        {
            frmMaterias frmMaterias = new frmMaterias();
            frmMaterias.Show();
        }

        private void btnEditarProfesor_Click(object sender, EventArgs e)
        {
            frmProfesores frmProfesores = new frmProfesores();
            frmProfesores.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
