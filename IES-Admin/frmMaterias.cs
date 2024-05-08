using System;
using System.Windows.Forms;

namespace IES_Admin
{
    public partial class frmMaterias : Form
    {
        public frmMaterias()
        {
            InitializeComponent();
        }

        private void formMaterias_Load(object sender, EventArgs e)
        {

        }

        private void btnListarMaterias_Click(object sender, EventArgs e)
        {
            bool flag = gbHorarioMatarias.Visible;

            if (gbCondicionMaterias.Visible || gbCorrelatividades.Visible)
            {
                gbCondicionMaterias.Visible = false;
                gbCorrelatividades.Visible = false;
                gbHorarioMatarias.Visible = true;
            }
            else
            {
                gbHorarioMatarias.Visible = !flag;
            }
            
        }

        private void btnCondicionMaterias_Click(object sender, EventArgs e)
        {
            bool flag = gbCondicionMaterias.Visible;

            if (gbHorarioMatarias.Visible || gbCorrelatividades.Visible)
            {
                gbHorarioMatarias.Visible = false;
                gbCorrelatividades.Visible = false;
                gbCondicionMaterias.Visible = true;
            }
            else
            {
                gbCondicionMaterias.Visible = !flag;
            }

        }

        private void btnCorrelatividadMaterias_Click(object sender, EventArgs e)
        {
            bool flag = gbCorrelatividades.Visible;

            if (gbHorarioMatarias.Visible || gbCondicionMaterias.Visible)
            {
                gbHorarioMatarias.Visible = false;
                gbCondicionMaterias.Visible = false;
                gbCorrelatividades.Visible = true;
            }
            else
            {
                gbCorrelatividades.Visible = !flag;
            }
        }
    }
}
