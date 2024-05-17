using CapaNegocio;
using CapaNegocios;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Windows.Forms;
using static Mysqlx.Crud.Order.Types;

namespace IES_Admin
{
    public partial class frmProfesores : Form
    {
        private Profesores objProfesor;
        private Materias objMateria;
          
        public frmProfesores()
        {
            InitializeComponent();
            ListarProfesor();
            ListarMaterias();
        }

        //------------------------------EVENTOS-------------------------------------


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProfesor();
            ListarProfesor();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarProfesor();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProfesor();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            SetBotones(false);
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ListarProfesorCompleto(e);
        }

        private void dgvAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CerrarDatosProfesor();
            RellenarTextbox(e);
            
        }

        private void btnCerrarDatosProfesor_Click(object sender, EventArgs e)
        {
            CerrarDatosProfesor();
        }

        
        //------------------------------METODOS-------------------------------------
        
        private void AgregarProfesor()
        {
            try
            {
                objProfesor = new Profesores("SELECT idprofesores FROM profesores");
                CheckBox[] modulos = { chk1, chk2, chk3, chk4, chk5, chk6, chk7 };               
                string nombre = txtNombre.Text;
                string dni = txtDni.Text;
                string direcc = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string matricula = txtMatricula.Text;
                int id;
                string modulosTexto = "";
                string materia = "";
                string procedimiento = "AgregarProfesor";
                string[] parametro = {
                    "_id", "_nombre", "_dni", "_direccion", "_telefono", "_matricula", "_materia", "_modulo"
                };

                if (dgvAlumnos.Rows.Count > 0)
                {
                    id = int.Parse(dgvAlumnos.Rows[objProfesor.IdPersona()].Cells["Id"].Value.ToString()) + 1;
                }
                else
                {
                    id = 1;
                }

                if (cmbMateria.SelectedItem != null)
                {
                    materia = cmbMateria.Text;
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

                objProfesor = new Profesores(id, nombre, dni, direcc, telefono, matricula, modulosTexto, materia, procedimiento, parametro);
                objProfesor.AgregarProfesor();
            }
            catch (Exception) { }
            finally
            {
                ListarProfesor();
                LimpiarCampos();
            }
        }

        private void EliminarProfesor()
        {
            try
            {
                string parametro = "_id";
                string procedimiento = "EliminarProfesor";
                int id = int.Parse(txtId.Text);
                objProfesor = new Profesores(id, parametro, procedimiento);
                objProfesor.EliminarPersona();

                MessageBox.Show(
                    "Se elimino un alumno con exito!!",
                    "Sistema de Gestion Profesores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );

                ListarProfesor();
                LimpiarCampos();
            }
            catch (Exception) { }
            finally
            {
                SetBotones(false);
                ListarProfesor();
            }
        }

        private void EditarProfesor()
        {
            try
            {
                string procedimiento = "EditarProfesor";
                string[] parametro = {"_id", "_nombre", "_dni", "_direccion", "_telefono", "_matricula", "_materia", "_modulo" };
                int id = int.Parse(txtId.Text);
                string nombre = txtNombre.Text;
                string dni = txtDni.Text;
                string direccion = txtDireccion.Text;
                string telefono = txtTelefono.Text;
                string matricula = txtMatricula.Text;
                string materia = "";

                CheckBox[] modulos = { chk1, chk2, chk3, chk4, chk5, chk6, chk7 };
                string modulosTexto = "";
                for (int i = 0; i < modulos.Length; i++)
                {
                    if (modulos[i].Checked)
                    {
                        modulosTexto += modulos[i].Text + " ";
                    }
                }

                if (cmbMateria.SelectedItem != null)
                {
                    materia = cmbMateria.Text;
                }
                else
                {
                    materia = "Sin Especificar";
                }

                objProfesor= new Profesores(id, nombre, dni, direccion, telefono, matricula, materia, modulosTexto, procedimiento, parametro);
                objProfesor.EditarProfesor();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ListarProfesor();
                LimpiarCampos();
            }
        }

        private void ListarMaterias()
        {
            try
            {
                string procedimiento = "MostrarMateria";
                objMateria = new Materias(procedimiento);
                cmbMateria.DataSource = objMateria.MostrarMateria();
                cmbMateria.DisplayMember = "nombreMateria";
                cmbMateria.ValueMember = "";
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "La tabla esta vacia o no se pudo cargar la DB.",
                    "Sistema IES",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtDni.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtMatricula.Text = "";
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
            int[] columnasAncho = { 30, 170, 170, 85 };

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

        public void ListarProfesorCompleto(DataGridViewCellEventArgs e)
        {
            try
            {
                int idProf = int.Parse(dgvAlumnos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string parametro = "_id";
                string procedimiento = "MostraProfesorCompleto";
                objProfesor = new Profesores(idProf, parametro, procedimiento);
                MySqlDataReader reader = objProfesor.MostrarDatosCompletos();

                while (reader.Read())
                {
                    lblApeNombre.Text = reader.GetString(1);
                    lblDni.Text = reader.GetString(2);
                    lblDireccion.Text = reader.GetString(3);
                    lblTelefono.Text = reader.GetString(4);
                    lblMatricula.Text = reader.GetString(5);
                    lblMaterias.Text = reader.GetString(6);
                    lblModulo.Text = reader.GetString(7);
                }
                gbDatosProfesor.Visible = true;
            }
            catch (Exception)
            {

            }
        }
        
        public void CerrarDatosProfesor()
        {
            lblApeNombre.Text = "";
            lblDni.Text = "";
            lblDireccion.Text = "";
            lblTelefono.Text = "";
            lblMaterias.Text = "";
            lblMaterias.Text = "";
            lblModulo.Text = "";
            gbDatosProfesor.Visible = false;
        }

        private void SetBotones(bool _btnOnOff)
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

        private void RellenarTextbox(DataGridViewCellEventArgs e)
        {
            try
            {
                int idProf = int.Parse(dgvAlumnos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string parametro = "_id";
                string procedimiento = "MostraProfesorCompleto";
                objProfesor = new Profesores(idProf, parametro, procedimiento);
                MySqlDataReader reader = objProfesor.MostrarDatosCompletos();

                while (reader.Read())
                {
                    txtId.Text = reader.GetInt32(0).ToString();
                    txtNombre.Text = reader.GetString(1);
                    txtDni.Text = reader.GetString(2);
                    txtDireccion.Text = reader.GetString(3);
                    txtTelefono.Text = reader.GetString(4);
                    txtMatricula.Text = reader.GetString(5);
                    cmbMateria.Text = reader.GetString(6);

                    switch (reader.GetString(7))
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
                SetBotones(true);
            }
            catch (Exception)
            {

            }
        }
            
    }
}
