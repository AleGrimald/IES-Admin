namespace IES_Admin
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPssw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgVer = new System.Windows.Forms.PictureBox();
            this.imgNoVer = new System.Windows.Forms.PictureBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNoVer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Name = "label1";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtUser, "txtUser");
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Name = "txtUser";
            // 
            // txtPssw
            // 
            resources.ApplyResources(this.txtPssw, "txtPssw");
            this.txtPssw.ForeColor = System.Drawing.Color.Black;
            this.txtPssw.Name = "txtPssw";
            this.txtPssw.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // imgVer
            // 
            resources.ApplyResources(this.imgVer, "imgVer");
            this.imgVer.Name = "imgVer";
            this.imgVer.TabStop = false;
            this.imgVer.Click += new System.EventHandler(this.imgVer_Click);
            // 
            // imgNoVer
            // 
            resources.ApplyResources(this.imgNoVer, "imgNoVer");
            this.imgNoVer.Name = "imgNoVer";
            this.imgNoVer.TabStop = false;
            this.imgNoVer.Click += new System.EventHandler(this.imgNoVer_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.btnIngresar, "btnIngresar");
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // frmLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.imgNoVer);
            this.Controls.Add(this.imgVer);
            this.Controls.Add(this.txtPssw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNoVer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPssw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox imgVer;
        private System.Windows.Forms.PictureBox imgNoVer;
        private System.Windows.Forms.Button btnIngresar;
    }
}

