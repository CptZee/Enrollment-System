namespace Enrollment_System.Menus
{
    partial class SubjectsSelectionFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectsSelectionFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSched = new System.Windows.Forms.Button();
            this.lvSubjects = new System.Windows.Forms.ListView();
            this.btnProceed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select a maximum of six (6) subjects to take";
            // 
            // btnSched
            // 
            this.btnSched.BackColor = System.Drawing.Color.Purple;
            this.btnSched.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnSched.Location = new System.Drawing.Point(94, 285);
            this.btnSched.Name = "btnSched";
            this.btnSched.Size = new System.Drawing.Size(121, 33);
            this.btnSched.TabIndex = 3;
            this.btnSched.Text = "Select Schedule";
            this.btnSched.UseVisualStyleBackColor = false;
            this.btnSched.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lvSubjects
            // 
            this.lvSubjects.HideSelection = false;
            this.lvSubjects.Location = new System.Drawing.Point(16, 60);
            this.lvSubjects.Name = "lvSubjects";
            this.lvSubjects.Size = new System.Drawing.Size(428, 216);
            this.lvSubjects.TabIndex = 4;
            this.lvSubjects.UseCompatibleStateImageBehavior = false;
            this.lvSubjects.View = System.Windows.Forms.View.List;
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.Purple;
            this.btnProceed.Enabled = false;
            this.btnProceed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnProceed.Location = new System.Drawing.Point(234, 285);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(121, 33);
            this.btnProceed.TabIndex = 5;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubjectsSelectionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 330);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.lvSubjects);
            this.Controls.Add(this.btnSched);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectsSelectionFrm";
            this.Text = "Subjects Selection Form";
            this.Load += new System.EventHandler(this.SubjectsSelectionFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSched;
        private System.Windows.Forms.ListView lvSubjects;
        private System.Windows.Forms.Button btnProceed;
    }
}