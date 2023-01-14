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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSched = new System.Windows.Forms.Button();
            this.lvSubjects = new System.Windows.Forms.ListView();
            this.btnProceed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select a maximum of six (6) subjects to take";
            // 
            // btnSched
            // 
            this.btnSched.Location = new System.Drawing.Point(101, 282);
            this.btnSched.Name = "btnSched";
            this.btnSched.Size = new System.Drawing.Size(121, 23);
            this.btnSched.TabIndex = 3;
            this.btnSched.Text = "Select Schedule";
            this.btnSched.UseVisualStyleBackColor = true;
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
            this.btnProceed.Enabled = false;
            this.btnProceed.Location = new System.Drawing.Point(228, 282);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(121, 23);
            this.btnProceed.TabIndex = 5;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubjectsSelectionFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 315);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.lvSubjects);
            this.Controls.Add(this.btnSched);
            this.Controls.Add(this.label1);
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