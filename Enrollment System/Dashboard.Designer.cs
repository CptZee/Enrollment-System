namespace Enrollment_System
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdmin = new Enrollment_System.Resources.Rbutton();
            this.btnEnroll = new Enrollment_System.Resources.Rbutton();
            this.btnStatus = new Enrollment_System.Resources.Rbutton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Enrollment_System.Properties.Resources.Untitled_design;
            this.pictureBox1.Location = new System.Drawing.Point(-11, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1371, 743);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdmin.Location = new System.Drawing.Point(860, 445);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(316, 51);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnEnroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnroll.ForeColor = System.Drawing.Color.White;
            this.btnEnroll.Location = new System.Drawing.Point(860, 332);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(316, 58);
            this.btnEnroll.TabIndex = 2;
            this.btnEnroll.Text = "ENROLL";
            this.btnEnroll.UseVisualStyleBackColor = false;
            this.btnEnroll.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.ForeColor = System.Drawing.Color.White;
            this.btnStatus.Location = new System.Drawing.Point(860, 226);
            this.btnStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(316, 54);
            this.btnStatus.TabIndex = 1;
            this.btnStatus.Text = "CHECK STATUS";
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 729);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Text = "Enrollment System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private Resources.Rbutton btnStatus;
        private Resources.Rbutton btnEnroll;
        private Resources.Rbutton btnAdmin;
    }
}

