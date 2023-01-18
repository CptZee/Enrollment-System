using System;
using System.Windows.Forms;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class SubjectScheduleFrm : Form
    {
        private ApplicationForm application;
        private ScheduleManager scheduleManager;
        private String subject;
        public SubjectScheduleFrm(ApplicationForm application, String subject)
        {
            this.subject = subject;
            this.application = application;
            scheduleManager = ScheduleManager.getInstance();
            InitializeComponent();
        }

        private void ScheduleFrm_Load(object sender, EventArgs e)
        {
            SubjectManager subjectManager = SubjectManager.getInstance();

            lblSubject.Text = subject + "'s Schedule: ";
            Subject subj = subjectManager.findByName(subject);

            for (int i = 0; i < scheduleManager.schedules.Count; i++)
            {
                Schedule schedule = scheduleManager.findByIndex(i);
                if (schedule.SubjectID == subj.ID)
                    cbSchedule.Items.Add(schedule.StartTime + " - " + schedule.EndTime + ", " + schedule.Day);
            }

            CenterToScreen();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Schedule schedule = scheduleManager.findByTime(cbSchedule.Text.ToString());
            application.ScheduleIDs.Add(schedule.ID);
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();

            applicationFormsManager.update(application);

            MessageBox.Show("Schedule Selected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
