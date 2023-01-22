namespace Enrollment_System.Menus
{
    partial class StatusFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusFrm));
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(127, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(166, 55);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Purple;
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHome.Location = new System.Drawing.Point(96, 154);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(90, 32);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.Purple;
            this.btnPayment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPayment.Location = new System.Drawing.Point(236, 154);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(90, 32);
            this.btnPayment.TabIndex = 3;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // StatusFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 227);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatusFrm";
            this.Text = "Application Status";
            this.Load += new System.EventHandler(this.ApplicationStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPayment;
    }
}