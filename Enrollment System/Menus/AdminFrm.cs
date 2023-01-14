using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Enrollment_System.Util;

namespace Enrollment_System.Menus
{
    public partial class AdminFrm : Form
    {
        public AdminFrm()
        {
            InitializeComponent();
        }

        private void AdminFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            AppList.ReadOnly = true;
            CourseList.ReadOnly = true;
            SubjectList.ReadOnly = true;
            ScheduleList.ReadOnly = true;
            AppList.DataSource = DatabaseHelper.getApplications().Tables[0];
            CourseList.DataSource = DatabaseHelper.getCourses().Tables[0];
            SubjectList.DataSource = DatabaseHelper.getSubjects().Tables[0];
            ScheduleList.DataSource = DatabaseHelper.getSchedules().Tables[0];

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard frm = new Dashboard();
            frm.ShowDialog();
            this.Close();
        }
    }
}
