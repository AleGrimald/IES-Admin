using CapaNegocio;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace IES_Admin
{
    public partial class frmProfesores : Form
    {
          
        public frmProfesores()
        {
            InitializeComponent();
            ListarProfesor();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Profesores nuevoProfesor = new Profesores("SELECT idprofesores FROM profesores");
            CheckBox[] modulos = { chk1, chk2, chk3, chk4, chk5, chk6, chk7 };
            int id;
            string nombre = txtNombre.Text;
            string dni = txtDni.Text;
            string direcc = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string matricula = txtMatricula.Text;
            string modulosTexto = "";
            string materia;
            string anio;
            string procedimiento = "AgregarProfesor";
            string[] parametro = { 
                "_id", "_nombre", "_dni", "_direccion", "_telefono", "_matricula", "_modulo","_materia","_anio" 
            };

            if (dgvAlumnos.Rows.Count <= 0)
            {
                id = 1;
            }
            else
            {
                id = int.Parse(dgvAlumnos.Rows[nuevoProfesor.IdPersona()].Cells["Id"].Value.ToString()) + 1;
                
            }

            if (rdbPrimero.Checked)
            {
                anio = rdbPrimero.Text;
            }
            else if (rdbSegundo.Checked)
            {
                anio = rdbSegundo.Text;
            }
            else
            {
                anio = rdbTercero.Text;
            }

            if (cmbMateria.SelectedItem != null)
            {
                materia = cmbMateria.SelectedItem.ToString();
            }
            else
            {
                materia = "Sin Especificar";
            }

            for (int i = 0; i < modulos.Length; i++)
            {
                if (modulos[i].Checked)
                {
                    modulosTexto += modulos[i].Text + " ";
                }
            }

            Profesores objProfesor = new Profesores(id,nombre,dni,direcc,telefono,matricula,modulosTexto,materia,anio,procedimiento,parametro);
            objProfesor.AgregarProfesor();

            ListarProfesor();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string parametro = "_idprofesor";
                string procedimiento = "EliminarProfesor";
                Profesores indiceProfesor = new Profesores("SELECT idprofesores FROM profesores");
                int id = int.Parse(dgvAlumnos.Rows[indiceProfesor.IdPersona()].Cells["Id"].Value.ToString());
                indiceProfesor = new Profesores(id, parametro, procedimiento);
                indiceProfesor.EliminarPersona();

                MessageBox.Show(
                    "Se elimino un alumno con exito!!",
                    "Sistema de Gestion Alumnos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                ListarProfesor();
                LimpiarCampos();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                setBotones(false);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarProfesor();
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

        private void ListarProfesor()
        {
            string procedimiento = "MostrarProfesores";
            Profesores datosProfesor = new Profesores(procedimiento);
            dgvAlumnos.DataSource = datosProfesor.Mostrar4Datos();
            ModelarTabla();
        }

        public void ModelarTabla()
        {
            int[] columnasAncho = {30, 170, 170, 85};

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
            int idProf = int.Parse(dgvAlumnos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            string parametro = "_id";
            string procedimiento = "MostraProfesorCompleto";
            Profesores objProfesor = new Profesores(idProf, parametro, procedimiento);
            MySqlDataReader reader = objProfesor.MostrarDatosCompletos();

            while (reader.Read())
            {
                txtNombre.Text = reader.GetString(1);
                txtDni.Text = reader.GetString(2);
                txtDireccion.Text = reader.GetString(3);
                txtTelefono.Text = reader.GetString(4);
                txtMatricula.Text = reader.GetString(5);
                switch (reader.GetString(6))
                {
                    case "1° ":
                        rdbPrimero.Checked = true;
                        break;
                    case "2° ":
                        rdbSegundo.Checked = true;
                        break;
                    case "3° ":
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
                    case "1° Año":
                        chk1.Checked = true;
                        break;
                    case "2° Año":
                        chk2.Checked = true;
                        break;
                    case "3° Año":
                        chk3.Checked = true;
                        break;
                    case "4° Año":
                        chk4.Checked = true;
                        break;
                    case "5° Año":
                        chk5.Checked = true;
                        break;
                    case "6° Año":
                        chk6.Checked = true;
                        break;
                    case "7° Año":
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
