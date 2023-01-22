namespace Enrollment_System.Menus
{
    partial class SubjectsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectsFrm));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lvSubjects = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Purple;
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnConfirm.Location = new System.Drawing.Point(175, 303);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(97, 34);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lvSubjects
            // 
            this.lvSubjects.HideSelection = false;
            this.lvSubjects.Location = new System.Drawing.Point(10, 81);
            this.lvSubjects.Name = "lvSubjects";
            this.lvSubjects.Size = new System.Drawing.Size(428, 216);
            this.lvSubjects.TabIndex = 6;
            this.lvSubjects.UseCompatibleStateImageBehavior = false;
            this.lvSubjects.View = System.Windows.Forms.View.List;
            this.lvSubjects.SelectedIndexChanged += new System.EventHandler(this.lvSubjects_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Enrollment_System.Properties.Resources._1232;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 103);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // SubjectsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(450, 347);
            this.Controls.Add(this.lvSubjects);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectsFrm";
            this.Text = "Student Subjects Details";
            this.Load += new System.EventHandler(this.SubjectsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ListView lvSubjects;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}