namespace Enrollment_System.Menus
{
    partial class AdminFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminFrm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnView = new System.Windows.Forms.Button();
            this.btnApproveApp = new System.Windows.Forms.Button();
            this.btnRefreshApp = new System.Windows.Forms.Button();
            this.btnModifyApp = new System.Windows.Forms.Button();
            this.btnRemoveApp = new System.Windows.Forms.Button();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AppList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRefreshCourse = new System.Windows.Forms.Button();
            this.btnModifyCourse = new System.Windows.Forms.Button();
            this.btnRemoveCourse = new System.Windows.Forms.Button();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CourseList = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRefreshSubj = new System.Windows.Forms.Button();
            this.btnModifySubj = new System.Windows.Forms.Button();
            this.btnRemoveSubj = new System.Windows.Forms.Button();
            this.btnAddSubj = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SubjectList = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnRefreshSched = new System.Windows.Forms.Button();
            this.btnModifySched = new System.Windows.Forms.Button();
            this.btnRemoveSched = new System.Windows.Forms.Button();
            this.btnAddSched = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ScheduleList = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CourseList)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectList)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleList)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(896, 414);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnView);
            this.tabPage1.Controls.Add(this.btnApproveApp);
            this.tabPage1.Controls.Add(this.btnRefreshApp);
            this.tabPage1.Controls.Add(this.btnModifyApp);
            this.tabPage1.Controls.Add(this.btnRemoveApp);
            this.tabPage1.Controls.Add(this.btnAddApp);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.AppList);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(869, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Applications";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(774, 81);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 13;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // btnApproveApp
            // 
            this.btnApproveApp.Location = new System.Drawing.Point(774, 168);
            this.btnApproveApp.Name = "btnApproveApp";
            this.btnApproveApp.Size = new System.Drawing.Size(75, 23);
            this.btnApproveApp.TabIndex = 12;
            this.btnApproveApp.Text = "Approve";
            this.btnApproveApp.UseVisualStyleBackColor = true;
            // 
            // btnRefreshApp
            // 
            this.btnRefreshApp.Location = new System.Drawing.Point(774, 377);
            this.btnRefreshApp.Name = "btnRefreshApp";
            this.btnRefreshApp.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshApp.TabIndex = 11;
            this.btnRefreshApp.Text = "Refresh";
            this.btnRefreshApp.UseVisualStyleBackColor = true;
            // 
            // btnModifyApp
            // 
            this.btnModifyApp.Location = new System.Drawing.Point(774, 139);
            this.btnModifyApp.Name = "btnModifyApp";
            this.btnModifyApp.Size = new System.Drawing.Size(75, 23);
            this.btnModifyApp.TabIndex = 10;
            this.btnModifyApp.Text = "Modify";
            this.btnModifyApp.UseVisualStyleBackColor = true;
            // 
            // btnRemoveApp
            // 
            this.btnRemoveApp.Location = new System.Drawing.Point(774, 110);
            this.btnRemoveApp.Name = "btnRemoveApp";
            this.btnRemoveApp.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveApp.TabIndex = 9;
            this.btnRemoveApp.Text = "Remove";
            this.btnRemoveApp.UseVisualStyleBackColor = true;
            // 
            // btnAddApp
            // 
            this.btnAddApp.Location = new System.Drawing.Point(774, 52);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(75, 23);
            this.btnAddApp.TabIndex = 8;
            this.btnAddApp.Text = "Add";
            this.btnAddApp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Applications";
            // 
            // AppList
            // 
            this.AppList.AllowUserToAddRows = false;
            this.AppList.AllowUserToDeleteRows = false;
            this.AppList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppList.Location = new System.Drawing.Point(6, 52);
            this.AppList.Name = "AppList";
            this.AppList.ReadOnly = true;
            this.AppList.Size = new System.Drawing.Size(744, 348);
            this.AppList.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRefreshCourse);
            this.tabPage2.Controls.Add(this.btnModifyCourse);
            this.tabPage2.Controls.Add(this.btnRemoveCourse);
            this.tabPage2.Controls.Add(this.btnAddCourse);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.CourseList);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(869, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Courses";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRefreshCourse
            // 
            this.btnRefreshCourse.Location = new System.Drawing.Point(777, 377);
            this.btnRefreshCourse.Name = "btnRefreshCourse";
            this.btnRefreshCourse.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshCourse.TabIndex = 7;
            this.btnRefreshCourse.Text = "Refresh";
            this.btnRefreshCourse.UseVisualStyleBackColor = true;
            // 
            // btnModifyCourse
            // 
            this.btnModifyCourse.Location = new System.Drawing.Point(777, 110);
            this.btnModifyCourse.Name = "btnModifyCourse";
            this.btnModifyCourse.Size = new System.Drawing.Size(75, 23);
            this.btnModifyCourse.TabIndex = 6;
            this.btnModifyCourse.Text = "Modify";
            this.btnModifyCourse.UseVisualStyleBackColor = true;
            // 
            // btnRemoveCourse
            // 
            this.btnRemoveCourse.Location = new System.Drawing.Point(777, 81);
            this.btnRemoveCourse.Name = "btnRemoveCourse";
            this.btnRemoveCourse.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCourse.TabIndex = 5;
            this.btnRemoveCourse.Text = "Remove";
            this.btnRemoveCourse.UseVisualStyleBackColor = true;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(777, 52);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(75, 23);
            this.btnAddCourse.TabIndex = 4;
            this.btnAddCourse.Text = "Add";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 47);
            this.label2.TabIndex = 3;
            this.label2.Text = "Courses";
            // 
            // CourseList
            // 
            this.CourseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CourseList.Location = new System.Drawing.Point(6, 52);
            this.CourseList.Name = "CourseList";
            this.CourseList.Size = new System.Drawing.Size(744, 348);
            this.CourseList.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnRefreshSubj);
            this.tabPage3.Controls.Add(this.btnModifySubj);
            this.tabPage3.Controls.Add(this.btnRemoveSubj);
            this.tabPage3.Controls.Add(this.btnAddSubj);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.SubjectList);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(869, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Subjects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRefreshSubj
            // 
            this.btnRefreshSubj.Location = new System.Drawing.Point(777, 377);
            this.btnRefreshSubj.Name = "btnRefreshSubj";
            this.btnRefreshSubj.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSubj.TabIndex = 11;
            this.btnRefreshSubj.Text = "Refresh";
            this.btnRefreshSubj.UseVisualStyleBackColor = true;
            // 
            // btnModifySubj
            // 
            this.btnModifySubj.Location = new System.Drawing.Point(777, 110);
            this.btnModifySubj.Name = "btnModifySubj";
            this.btnModifySubj.Size = new System.Drawing.Size(75, 23);
            this.btnModifySubj.TabIndex = 10;
            this.btnModifySubj.Text = "Modify";
            this.btnModifySubj.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSubj
            // 
            this.btnRemoveSubj.Location = new System.Drawing.Point(777, 81);
            this.btnRemoveSubj.Name = "btnRemoveSubj";
            this.btnRemoveSubj.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSubj.TabIndex = 9;
            this.btnRemoveSubj.Text = "Remove";
            this.btnRemoveSubj.UseVisualStyleBackColor = true;
            // 
            // btnAddSubj
            // 
            this.btnAddSubj.Location = new System.Drawing.Point(777, 52);
            this.btnAddSubj.Name = "btnAddSubj";
            this.btnAddSubj.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubj.TabIndex = 8;
            this.btnAddSubj.Text = "Add";
            this.btnAddSubj.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 47);
            this.label3.TabIndex = 3;
            this.label3.Text = "Subjects";
            // 
            // SubjectList
            // 
            this.SubjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubjectList.Location = new System.Drawing.Point(6, 52);
            this.SubjectList.Name = "SubjectList";
            this.SubjectList.Size = new System.Drawing.Size(744, 348);
            this.SubjectList.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnRefreshSched);
            this.tabPage4.Controls.Add(this.btnModifySched);
            this.tabPage4.Controls.Add(this.btnRemoveSched);
            this.tabPage4.Controls.Add(this.btnAddSched);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.ScheduleList);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(869, 406);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Schedules";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnRefreshSched
            // 
            this.btnRefreshSched.Location = new System.Drawing.Point(777, 377);
            this.btnRefreshSched.Name = "btnRefreshSched";
            this.btnRefreshSched.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSched.TabIndex = 11;
            this.btnRefreshSched.Text = "Refresh";
            this.btnRefreshSched.UseVisualStyleBackColor = true;
            // 
            // btnModifySched
            // 
            this.btnModifySched.Location = new System.Drawing.Point(777, 110);
            this.btnModifySched.Name = "btnModifySched";
            this.btnModifySched.Size = new System.Drawing.Size(75, 23);
            this.btnModifySched.TabIndex = 10;
            this.btnModifySched.Text = "Modify";
            this.btnModifySched.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSched
            // 
            this.btnRemoveSched.Location = new System.Drawing.Point(777, 81);
            this.btnRemoveSched.Name = "btnRemoveSched";
            this.btnRemoveSched.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSched.TabIndex = 9;
            this.btnRemoveSched.Text = "Remove";
            this.btnRemoveSched.UseVisualStyleBackColor = true;
            // 
            // btnAddSched
            // 
            this.btnAddSched.Location = new System.Drawing.Point(777, 52);
            this.btnAddSched.Name = "btnAddSched";
            this.btnAddSched.Size = new System.Drawing.Size(75, 23);
            this.btnAddSched.TabIndex = 8;
            this.btnAddSched.Text = "Add";
            this.btnAddSched.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 47);
            this.label4.TabIndex = 3;
            this.label4.Text = "Schedules";
            // 
            // ScheduleList
            // 
            this.ScheduleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleList.Location = new System.Drawing.Point(6, 52);
            this.ScheduleList.Name = "ScheduleList";
            this.ScheduleList.Size = new System.Drawing.Size(744, 348);
            this.ScheduleList.TabIndex = 1;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(409, 432);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 1;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // AdminFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(920, 459);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminFrm";
            this.Text = "Admin Menu";
            this.Load += new System.EventHandler(this.AdminFrm_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CourseList)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectList)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView AppList;
        private System.Windows.Forms.DataGridView CourseList;
        private System.Windows.Forms.DataGridView SubjectList;
        private System.Windows.Forms.DataGridView ScheduleList;
        private System.Windows.Forms.Button btnApproveApp;
        private System.Windows.Forms.Button btnRefreshApp;
        private System.Windows.Forms.Button btnModifyApp;
        private System.Windows.Forms.Button btnRemoveApp;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.Button btnRefreshCourse;
        private System.Windows.Forms.Button btnModifyCourse;
        private System.Windows.Forms.Button btnRemoveCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshSubj;
        private System.Windows.Forms.Button btnModifySubj;
        private System.Windows.Forms.Button btnRemoveSubj;
        private System.Windows.Forms.Button btnAddSubj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefreshSched;
        private System.Windows.Forms.Button btnModifySched;
        private System.Windows.Forms.Button btnRemoveSched;
        private System.Windows.Forms.Button btnAddSched;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnView;
    }
}