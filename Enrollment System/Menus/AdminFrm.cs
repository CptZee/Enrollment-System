using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Enrollment_System.Util;
using Enrollment_System.Menus.Admin;

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
            updateTables(sender, e);

            Timer timer = new Timer();
            timer.Interval = (1 * 3000);
            timer.Tick += new System.EventHandler(this.updateTables);
            timer.Start();
        }

        private void updateTables(object sender, EventArgs e)
        {
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

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            CourseAdd frm = new CourseAdd();
            frm.ShowDialog();
        }

        private void btnModifyCourse_Click(object sender, EventArgs e)
        {
            CourseModify frm = new CourseModify();
            frm.ShowDialog();
        }
    }
}
