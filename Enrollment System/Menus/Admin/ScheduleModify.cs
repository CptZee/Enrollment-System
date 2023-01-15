using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class ScheduleModify : Form
    {
        private ScheduleManager manager;
        public ScheduleModify()
        {
            manager = ScheduleManager.getInstance();
            InitializeComponent();
        }

        private void ScheduleModify_Load(object sender, EventArgs e)
        {
            loadComboBoxes();
            updateList();
            CenterToScreen();
        }

        private void updateList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < manager.schedules.Count; i++)
            {
                Schedule course = manager.findByIndex(i);
                cbID.Items.Add(course.ID);
            }
        }

        private void loadComboBoxes()
        {
            SubjectManager subjectManager = SubjectManager.getInstance();
            for (int i = 0; i < subjectManager.subjects.Count; i++)
            {
                Subject subject = subjectManager.findByIndex(i);
                cbSubjectID.Items.Add(subject.ID);
            }

            cbDay.Items.Add("MONDAY");
            cbDay.Items.Add("TUESDAY");
            cbDay.Items.Add("WEDNESDAY");
            cbDay.Items.Add("THURSDAY");
            cbDay.Items.Add("FRIDAY");
            cbDay.Items.Add("SATURDAY");

            cbStartTime.Items.Add("TBA");
            cbStartTime.Items.Add("7:00AM");
            cbStartTime.Items.Add("7:30AM");
            cbStartTime.Items.Add("8:00AM");
            cbStartTime.Items.Add("8:30AM");
            cbStartTime.Items.Add("9:00AM");
            cbStartTime.Items.Add("9:30AM");
            cbStartTime.Items.Add("10:00AM");
            cbStartTime.Items.Add("10:30AM");
            cbStartTime.Items.Add("11:00AM");
            cbStartTime.Items.Add("11:30AM");
            cbStartTime.Items.Add("12:00PM");
            cbStartTime.Items.Add("12:30PM");
            cbStartTime.Items.Add("1:00PM");
            cbStartTime.Items.Add("1:30PM");
            cbStartTime.Items.Add("2:00PM");
            cbStartTime.Items.Add("2:30PM");
            cbStartTime.Items.Add("3:00PM");
            cbStartTime.Items.Add("3:30PM");
            cbStartTime.Items.Add("4:00PM");
            cbStartTime.Items.Add("4:30PM");
            cbStartTime.Items.Add("5:00PM");
            cbStartTime.Items.Add("5:30AM");
            cbStartTime.Items.Add("6:00PM");
            cbStartTime.Items.Add("6:30PM");

            cbEndTime.Items.Add("TBA");

        }


        //TODO: Make it so that the lower hour of the start time will be removed
        private void cbStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStartTime.Text.ToString().Equals("TBA"))
                return;
            cbEndTime.Items.Add("7:30AM");
            cbEndTime.Items.Add("8:00AM");
            cbEndTime.Items.Add("8:30AM");
            cbEndTime.Items.Add("9:00AM");
            if (cbStartTime.Text.ToString().Equals("7:00AM"))
                return;
            cbEndTime.Items.Add("9:30AM");
            if (cbStartTime.Text.ToString().Equals("7:30AM"))
                return;
            cbEndTime.Items.Add("10:00AM");
            if (cbStartTime.Text.ToString().Equals("8:30AM"))
                return;
            cbEndTime.Items.Add("10:30AM");
            if (cbStartTime.Text.ToString().Equals("8:30AM"))
                return;
            cbEndTime.Items.Add("11:00AM");
            if (cbStartTime.Text.ToString().Equals("9:00AM"))
                return;
            cbEndTime.Items.Add("11:30AM");
            if (cbStartTime.Text.ToString().Equals("9:30AM"))
                return;
            cbEndTime.Items.Add("12:00PM");
            if (cbStartTime.Text.ToString().Equals("10:00AM"))
                return;
            cbEndTime.Items.Add("12:30PM");
            if (cbStartTime.Text.ToString().Equals("10:30AM"))
                return;
            cbEndTime.Items.Add("1:00PM");
            if (cbStartTime.Text.ToString().Equals("11:00AM"))
                return;
            cbEndTime.Items.Add("1:30PM");
            if (cbStartTime.Text.ToString().Equals("11:30AM"))
                return;
            cbEndTime.Items.Add("2:00PM");
            if (cbStartTime.Text.ToString().Equals("12:00PM"))
                return;
            cbEndTime.Items.Add("2:30PM");
            if (cbStartTime.Text.ToString().Equals("12:30PM"))
                return;
            cbEndTime.Items.Add("3:00PM");
            if (cbStartTime.Text.ToString().Equals("1:00PM"))
                return;
            cbEndTime.Items.Add("3:30PM");
            if (cbStartTime.Text.ToString().Equals("1:30PM"))
                return;
            cbEndTime.Items.Add("4:00PM");
            if (cbStartTime.Text.ToString().Equals("2:00PM"))
                return;
            cbEndTime.Items.Add("4:30PM");
            if (cbStartTime.Text.ToString().Equals("2:30PM"))
                return;
            cbEndTime.Items.Add("5:00PM");
            if (cbStartTime.Text.ToString().Equals("3:00PM"))
                return;
            cbEndTime.Items.Add("5:30AM");
            if (cbStartTime.Text.ToString().Equals("3:30PM"))
                return;
            cbEndTime.Items.Add("6:00PM");
            if (cbStartTime.Text.ToString().Equals("4:00PM"))
                return;
            cbEndTime.Items.Add("6:30PM");
            cbEndTime.Items.Add("7:00PM");
        }

        private void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Schedule schedule = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            cbSubjectID.Text = "" + schedule.SubjectID;
            cbDay.Text = schedule.Day;
            cbStartTime.Text = schedule.StartTime;
            cbEndTime.Text = schedule.EndTime;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Schedule schedule = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            schedule.SubjectID = Convert.ToInt32(cbID.Text.ToString());
            schedule.Day = cbDay.Text.ToString();
            schedule.StartTime = cbStartTime.Text.ToString();
            schedule.EndTime = cbEndTime.Text.ToString();
            manager.update(schedule);
            DatabaseHelper.updateSchedule(schedule);

            MessageBox.Show("Schedule " + schedule.ID + " successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateList();
        }
    }
}
