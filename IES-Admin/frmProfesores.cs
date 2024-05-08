using CapaNegocio;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IES_Admin
{
    public partial class frmProfesores : Form
    {
        Alumno datosAlumno = new Alumno();
        
        public frmProfesores()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarAlumnos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDni.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtMatricula.Text = "";
            rdbPrimero.Checked = false;
            rdbSegundo.Checked = false;
            rdbTercero.Checked = false;
            cmbMateria.Text = "";
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            chk4.Checked = false;
            chk5.Checked = false;
            chk6.Checked = false;
            chk7.Checked = false;

        }

        private void ListarAlumnos()
        {
            Alumno datosAlumno = new Alumno();

            dgvAlumnos.DataSource = datosAlumno.MostrarAlumno("MostrarProfesores");
            ModelarTabla();
        }

        public void ModelarTabla()
        {
            int[] columnasAncho = { 180, 180, 100};

            dgvAlumnos.AlternatingRowsDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvAlumnos.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            dgvAlumnos.BorderStyle = BorderStyle.None;
            dgvAlumnos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAlumnos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvAlumnos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvAlumnos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvAlumnos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAlumnos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAlumnos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAlumnos.Font, FontStyle.Bold);
            dgvAlumnos.ColumnHeadersHeight = 40;
            dgvAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlumnos.MultiSelect = false;
            dgvAlumnos.EnableHeadersVisualStyles = false;
            dgvAlumnos.RowHeadersVisible = false;

            for (int i = 0; i < columnasAncho.Length; i++)
            {
                dgvAlumnos.Columns[i].Width = columnasAncho[i];
            }

        }

        private void soloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void soloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void noSimbolos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //Hacer dinamico el id del profesor, traerlo desde la tabla
            Profesores objProfesor = new Profesores(2);
            MySqlDataReader reader = objProfesor.MostrarDatosProfesor();

            while (reader.Read())
            {
                txtNombre.Text = reader.GetString(1);
                txtDni.Text = reader.GetString(2);
                txtDireccion.Text = reader.GetString(3);
                txtTelefono.Text = reader.GetString(4);
                txtMatricula.Text = reader.GetString(5);
                switch (reader.GetString(6))
                {
                    case "1°":
                        rdbPrimero.Checked = true;
                        break;
                    case "2°":
                        rdbSegundo.Checked = true;
                        break;
                    case "3°":
                        rdbTercero.Checked = true;
                        break;

                    default:
                        rdbPrimero.Checked = false;
                        rdbSegundo.Checked = false;
                        rdbTercero.Checked = false;
                        break;
                }
                cmbMateria.Text = reader.GetString(7);
                switch (reader.GetString(8))
                {
                    case "1":
                        chk1.Checked = true;
                        break;
                    case "2":
                        chk2.Checked = true;
                        break;
                    case "3":
                        chk3.Checked = true;
                        break;
                    case "4":
                        chk4.Checked = true;
                        break;
                    case "5":
                        chk5.Checked = true;
                        break;
                    case "6":
                        chk6.Checked = true;
                        break;
                    case "7":
                        chk7.Checked = true;
                        break;

                    default:
                        chk1.Checked = false;
                        chk2.Checked = false;
                        chk3.Checked = false;
                        chk4.Checked = false;
                        chk5.Checked = false;
                        chk6.Checked = false;
                        chk7.Checked = false;
                        break;
                }
            }
            setBotones(true);
        }

        private void setBotones(bool _btnOnOff)
        {
            if (_btnOnOff)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
                btnListar.Enabled = false;
                btnEstadoAcademico.Enabled = false;
                btnEditar.BackColor = Color.Gold;
                btnEliminar.BackColor = Color.Tomato;
                btnCancelar.BackColor = Color.Tomato;
                btnAgregar.BackColor = Color.LightGray;
                btnListar.BackColor = Color.LightGray;
                btnEstadoAcademico.BackColor = Color.LightGray;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAgregar.Enabled = true;
                btnListar.Enabled = true;
                btnEstadoAcademico.Enabled = true;
                btnEditar.BackColor = Color.LightGray;
                btnEliminar.BackColor = Color.LightGray;
                btnCancelar.BackColor = Color.LightGray;
                btnAgregar.BackColor = Color.LimeGreen;
                btnListar.BackColor = Color.DeepSkyBlue;
                btnEstadoAcademico.BackColor = Color.MediumTurquoise;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            setBotones(false);
        }
    }
}
