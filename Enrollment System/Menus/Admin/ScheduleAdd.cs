using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class ScheduleAdd : Form
    {
        public ScheduleAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int subjectID = Convert.ToInt32(cbSubjectID.Text);
            String startTime, endTime, day;
            startTime = cbStartTime.Text.ToString();
            endTime = cbEndTime.Text.ToString();
            day = cbDay.Text.ToString();

            if (string.IsNullOrEmpty(cbSubjectID.Text.ToString()))
            {
                MessageBox.Show("Subject ID is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(startTime))
            {
                MessageBox.Show("Start time is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(endTime))
            {
                MessageBox.Show("End time is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(day))
            {
                MessageBox.Show("Day is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScheduleManager scheduleManager = ScheduleManager.getInstance();
            Schedule schedule = new Schedule();
            schedule.ID = scheduleManager.getRecentID() + 1;
            schedule.SubjectID = subjectID;
            schedule.StartTime = startTime;
            schedule.EndTime = endTime;
            schedule.Day = day;


            ScheduleHelper.addSchedule(schedule);
            scheduleManager.add(schedule);

            MessageBox.Show("Schedule for subject with the ID of " + subjectID + " successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

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

        private void ScheduleAdd_Load(object sender, EventArgs e)
        {
            loadComboBoxes();
            CenterToScreen();
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
    }
}
