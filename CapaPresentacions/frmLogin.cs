using IES_Admin.Clases;
using System;
using System.Windows.Forms;

namespace IES_Admin
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
            imgVer.Hide();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text, passw = txtPssw.Text;
            Usuario datosUser = new Usuario(user, passw);

            if (datosUser.ValidarUsuario())
            {
                MessageBox.Show("Bienvenido a IES-Admin", "Login Exitoso!!", MessageBoxButtons.OK);
                this.Hide();
                frmAdmin frmAdmin = new frmAdmin();
                frmAdmin.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecto", "Login Fallido!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void imgNoVer_Click(object sender, EventArgs e)
        {
            txtPssw.UseSystemPasswordChar=false;
            imgNoVer.Hide();
            imgVer.Show();
        }

        private void imgVer_Click(object sender, EventArgs e)
        {
            txtPssw.UseSystemPasswordChar = true;
            imgVer.Hide();
            imgNoVer.Show();
        }
    }

}
