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
            timer.Interval = (1 * 15000);
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
            DashboardFrm frm = new DashboardFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            CourseAdd frm = new CourseAdd();
            frm.ShowDialog();
        }

        private void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            CourseRemove frm = new CourseRemove();
            frm.ShowDialog();
        }

        private void btnModifyCourse_Click(object sender, EventArgs e)
        {
            CourseModify frm = new CourseModify();
            frm.ShowDialog();
        }

        private void btnAddSubj_Click(object sender, EventArgs e)
        {
            SubjectAdd frm = new SubjectAdd();
            frm.ShowDialog();
        }

        private void btnRemoveSubj_Click(object sender, EventArgs e)
        {
            SubjectRemove frm = new SubjectRemove();
            frm.ShowDialog();
        }

        private void btnModifySubj_Click(object sender, EventArgs e)
        {
            SubjectModify frm = new SubjectModify();
            frm.ShowDialog();
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            ScheduleAdd frm = new ScheduleAdd();
            frm.ShowDialog();
        }

        private void btnRemoveSchedule_Click(object sender, EventArgs e)
        {
            ScheduleRemove frm = new ScheduleRemove();
            frm.ShowDialog();
        }

        private void btnModifySchedule_Click(object sender, EventArgs e)
        {
            ScheduleModify frm = new ScheduleModify();
            frm.ShowDialog();
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            ApplicationAdd frm = new ApplicationAdd();
            frm.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ApplicationView frm = new ApplicationView();
            frm.ShowDialog();
        }

        private void btnRemoveApp_Click(object sender, EventArgs e)
        {
            ApplicationRemove frm = new ApplicationRemove();
            frm.ShowDialog();
        }

        private void btnModifyApp_Click(object sender, EventArgs e)
        {
            ApplicationModify frm = new ApplicationModify();
            frm.ShowDialog();
        }

        private void btnApproveApp_Click(object sender, EventArgs e)
        {
            //TODO: ADD A function that approves the application.
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            updateTables(sender, e);
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            updateTables(sender, e);
        }

        private void btnRefresh3_Click(object sender, EventArgs e)
        {
            updateTables(sender, e);
        }

        private void btnRefresh4_Click(object sender, EventArgs e)
        {
            updateTables(sender, e);
        }
    }
}
