using System;
using System.Drawing;
using System.Windows.Forms;
using static Mysqlx.Notice.SessionStateChanged.Types;

namespace IES_Admin
{
    public partial class frmAlumno : Form
    {
        private string[] listaCarrera = {"Desarrollo de Software", "Tecnicatura en Programacion" };

        public frmAlumno()
        {
            InitializeComponent();
            ListarAlumnos();
            foreach (string item in listaCarrera)
            {
                cmbCarrera.Items.Add(item);
            }
        }

        private void formAlumno_Load(object sender, EventArgs e)
        {

        }

        //Metodos del CRUD
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Alumno nuevoAlumno = new Alumno("SELECT idalumno FROM alumno");
                string nombre = txtNombre.Text;
                string dni = txtDni.Text;
                string edad = txtEdad.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string legajo = txtLegajo.Text;
                string carrera;
                DateTime fecha = dtpFecha.Value.Date;
                string anio;
                int id;
                string[] parametro = { 
                    "nombre", "dni", "edad", "direccion", "telefono", "legajo", "carrera", "fecha", "anio", "idalumno" 
                };


                if (cmbCarrera.SelectedItem != null)
                {
                    carrera = cmbCarrera.SelectedItem.ToString();
                }
                else
                {
                    carrera = "Sin Especificar";
                }

                if (nuevoAlumno.IdPersona() >= 0)
                {
                    id = int.Parse(dgvAlumnos.Rows[nuevoAlumno.IdPersona()].Cells["idalumno"].Value.ToString())+1;
                }
                else
                {
                    id = 1;
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

                if (nombre=="" || dni == "" || edad == "" || direccion== "" || telefono == "" || legajo == "" || anio == "")
                {
                    MessageBox.Show(
                        "Falta llenar algunos campos",
                        "Sistema de Gestion Alumnos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
                else
                {
                    nuevoAlumno = new Alumno(nombre, dni, edad, direccion, telefono, legajo, carrera, fecha, anio, id, "AgregarAlumno",parametro);
                    nuevoAlumno.AgregarAlumno();

                    MessageBox.Show(
                        "Se agrego un alumno con exito!!",
                        "Sistema de Gestion Alumnos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );

                    ListarAlumnos();
                    LimpiarCampos();
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Algo anda mal 🙄",
                    "Revisa que todas las casillas esten llenas.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string dni = txtDni.Text;
                string edad = txtEdad.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string legajo = txtLegajo.Text;
                string carrera = cmbCarrera.SelectedItem.ToString();
                DateTime fecha = dtpFecha.Value.Date;
                string anio;
                int id = int.Parse(txtId.Text);
                string[] parametro = { "_nombre", "_dni", "_edad", "_direccion", "_telefono", "_legajo", "_carrera", "_fecha", "_anio", "_idalumno" };
                string procedimiento = "EditarAlumno";

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

                Alumno editarAlumno = new Alumno(nombre, dni, edad, direccion, telefono, legajo, carrera, fecha, anio, id, procedimiento, parametro );
                editarAlumno.EditarAlumno();

                MessageBox.Show(
                    "Se edito un alumno con exito!!",
                    "Sistema de Gestion Alumnos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                ListarAlumnos();
                LimpiarCampos();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Algo anda mal 🙄",
                    "Revisa que todas las casillas esten llenas.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                throw;
            }
            finally
            {
                setBotones(false);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string parametro = "_idalumno";
                string procedimiento = "EliminarAlumno";
                Alumno indiceAlumno = new Alumno("SELECT idalumno FROM alumno");
                int id = int.Parse(dgvAlumnos.Rows[indiceAlumno.IdPersona()].Cells["idalumno"].Value.ToString());
                indiceAlumno = new Alumno(id, parametro, procedimiento);
                indiceAlumno.EliminarPersona();

                MessageBox.Show(
                    "Se elimino un alumno con exito!!",
                    "Sistema de Gestion Alumnos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                ListarAlumnos();
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
        
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDni.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtLegajo.Text = "";
            cmbCarrera.Text = "Seleccione una opcion";
            dtpFecha.Text = "";
            rdbPrimero.Checked = true;
            txtId.Text = "";
        }

        //Metodos de Validacion y Modelado

        private void ListarAlumnos()
        {
            string procedimiento = "MostrarAlumnos";
            Alumno datosAlumno = new Alumno(procedimiento);          
            dgvAlumnos.DataSource = datosAlumno.MostrarAlumno();
            ModelarTabla();
        }

        public void ModelarTabla()
        {
            int[] columnasAncho = { 185, 70, 50, 185, 83, 60, 145, 120, 50 };

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
            dgvAlumnos.RowHeadersVisible= false;

            try
            {
                for (int i = 0; i < columnasAncho.Length; i++)
                {
                    dgvAlumnos.Columns[i].Width = columnasAncho[i];
                }
            }
            catch (Exception)
            {

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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAlumnos.Rows[e.RowIndex];
                
                txtNombre.Text = row.Cells[0].Value.ToString();
                txtDni.Text = row.Cells[1].Value.ToString();
                txtEdad.Text = row.Cells[2].Value.ToString();
                txtDireccion.Text = row.Cells[3].Value.ToString();
                txtTelefono.Text = row.Cells[4].Value.ToString();
                txtLegajo.Text = row.Cells[5].Value.ToString();
                cmbCarrera.Text = row.Cells[6].Value.ToString();
                dtpFecha.Text = row.Cells[7].Value.ToString();
                txtId.Text = row.Cells[9].Value.ToString();

                switch (row.Cells[8].Value.ToString())
                {
                    case "1° Año":
                        rdbPrimero.Checked = true;
                        break;
                    case "2° Año":
                        rdbSegundo.Checked = true;
                        break;
                    case "3° Año":
                        rdbTercero.Checked = true;
                        break;

                    default:
                        rdbPrimero.Checked = false;
                        rdbSegundo.Checked = false;
                        rdbTercero.Checked = false;
                        break;
                }

                setBotones(true);
            }
        }

        private void setBotones(bool _btnOnOff)
        {
            if (_btnOnOff)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
                btnAgregar.Enabled = false;
                btnEstadoAcademico.Enabled = false;
                btnEditar.BackColor = Color.Gold;
                btnEliminar.BackColor = Color.Tomato;
                btnCancelar.BackColor = Color.Tomato;
                btnAgregar.BackColor = Color.LightGray;
                btnEstadoAcademico.BackColor = Color.LightGray;
            }
            else
            {
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                btnAgregar.Enabled = true;
                btnEstadoAcademico.Enabled = true;
                btnEditar.BackColor = Color.LightGray;
                btnEliminar.BackColor = Color.LightGray;
                btnCancelar.BackColor = Color.LightGray;
                btnAgregar.BackColor = Color.LimeGreen;
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
