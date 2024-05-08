namespace IES_Admin
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.gbProfesores = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnMostrarProfesor = new System.Windows.Forms.Button();
            this.btnAgregarProfesor = new System.Windows.Forms.Button();
            this.btnEditarProfesor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gbProfesores.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProfesores
            // 
            this.gbProfesores.BackColor = System.Drawing.Color.SteelBlue;
            this.gbProfesores.Controls.Add(this.label3);
            this.gbProfesores.Controls.Add(this.label2);
            this.gbProfesores.Controls.Add(this.label1);
            this.gbProfesores.Controls.Add(this.dateTimePicker1);
            this.gbProfesores.Controls.Add(this.btnMostrarProfesor);
            this.gbProfesores.Controls.Add(this.btnAgregarProfesor);
            this.gbProfesores.Controls.Add(this.btnEditarProfesor);
            this.gbProfesores.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gbProfesores.ForeColor = System.Drawing.SystemColors.Window;
            this.gbProfesores.Location = new System.Drawing.Point(18, 18);
            this.gbProfesores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbProfesores.Name = "gbProfesores";
            this.gbProfesores.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbProfesores.Size = new System.Drawing.Size(784, 685);
            this.gbProfesores.TabIndex = 4;
            this.gbProfesores.TabStop = false;
            this.gbProfesores.Text = "Administracion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 80);
            this.label2.TabIndex = 8;
            this.label2.Text = "- Listado de Alumnos\r\n- Estado Academico\r\n- Inscripcion\r\n- Modificacion\r\n- Elimin" +
    "acion\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 64);
            this.label1.TabIndex = 7;
            this.label1.Text = "- Horarios de materias\r\n- Condiciones de la materia\r\n- Correlatividades\r\n\r\n";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(312, 32);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(462, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // btnMostrarProfesor
            // 
            this.btnMostrarProfesor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMostrarProfesor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMostrarProfesor.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.btnMostrarProfesor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMostrarProfesor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMostrarProfesor.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarProfesor.Image")));
            this.btnMostrarProfesor.Location = new System.Drawing.Point(46, 112);
            this.btnMostrarProfesor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMostrarProfesor.Name = "btnMostrarProfesor";
            this.btnMostrarProfesor.Size = new System.Drawing.Size(345, 157);
            this.btnMostrarProfesor.TabIndex = 0;
            this.btnMostrarProfesor.UseVisualStyleBackColor = false;
            this.btnMostrarProfesor.Click += new System.EventHandler(this.btnMostrarProfesor_Click);
            // 
            // btnAgregarProfesor
            // 
            this.btnAgregarProfesor.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAgregarProfesor.Font = new System.Drawing.Font("MS Reference Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnAgregarProfesor.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarProfesor.Image")));
            this.btnAgregarProfesor.Location = new System.Drawing.Point(46, 298);
            this.btnAgregarProfesor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarProfesor.Name = "btnAgregarProfesor";
            this.btnAgregarProfesor.Size = new System.Drawing.Size(345, 157);
            this.btnAgregarProfesor.TabIndex = 1;
            this.btnAgregarProfesor.UseVisualStyleBackColor = false;
            this.btnAgregarProfesor.Click += new System.EventHandler(this.btnAgregarProfesor_Click);
            // 
            // btnEditarProfesor
            // 
            this.btnEditarProfesor.BackColor = System.Drawing.Color.Gold;
            this.btnEditarProfesor.Font = new System.Drawing.Font("MS Reference Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnEditarProfesor.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarProfesor.Image")));
            this.btnEditarProfesor.Location = new System.Drawing.Point(46, 485);
            this.btnEditarProfesor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditarProfesor.Name = "btnEditarProfesor";
            this.btnEditarProfesor.Size = new System.Drawing.Size(345, 157);
            this.btnEditarProfesor.TabIndex = 2;
            this.btnEditarProfesor.UseVisualStyleBackColor = false;
            this.btnEditarProfesor.Click += new System.EventHandler(this.btnEditarProfesor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 112);
            this.label3.TabIndex = 9;
            this.label3.Text = "- Listado de Profesores\r\n- Inscripcion\r\n- Modificacion\r\n- Eliminacion\r\n- Horarios" +
    "\r\n- Materias Asignadas\r\n\r\n";
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(820, 722);
            this.Controls.Add(this.gbProfesores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IES Yerba Buena - Admin";
            this.Load += new System.EventHandler(this.formAdmin_Load);
            this.gbProfesores.ResumeLayout(false);
            this.gbProfesores.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbProfesores;
        private System.Windows.Forms.Button btnEditarProfesor;
        private System.Windows.Forms.Button btnAgregarProfesor;
        private System.Windows.Forms.Button btnMostrarProfesor;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}