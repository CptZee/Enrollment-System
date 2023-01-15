using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class ScheduleRemove : Form
    {
        private ScheduleManager manager;
        public ScheduleRemove()
        {
            manager = ScheduleManager.getInstance();
            InitializeComponent();
        }

        private void ScheduleRemove_Load(object sender, EventArgs e)
        {
            updateList();
            CenterToScreen();
        }

        private void updateList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < manager.schedules.Count; i++)
            {
                Schedule schedule = manager.findByIndex(i);
                cbID.Items.Add(schedule.ID);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cbID.Text.ToString()))
            {
                MessageBox.Show("ID is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ID = 0;
            try
            {
                ID = Convert.ToInt32(cbID.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("ID must be in whole numbers form!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Schedule schedule = manager.find(ID);
            if (schedule == null)
            {
                MessageBox.Show("Schedule does not exist! Check the ID of the schedule that you are trying to remove!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DatabaseHelper.removeSchedule(schedule);

            manager.remove(ID);
            MessageBox.Show("Schedule " + schedule.ID + " successfully removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateList();
        }
    }
}
