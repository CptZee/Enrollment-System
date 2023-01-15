using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class SubjectModify : Form
    {
        private SubjectManager manager;
        public SubjectModify()
        {
            manager = SubjectManager.getInstance();
            InitializeComponent();
        }

        private void SubjectModify_Load(object sender, EventArgs e)
        {
            updateList();
            loadComboBoxes();
            CenterToScreen();
        }

        private void loadComboBoxes()
        {
            cbYearLevel.Items.Add("First Year Level");
            cbYearLevel.Items.Add("Second Year Level");
            cbYearLevel.Items.Add("Third Year Level");
            cbYearLevel.Items.Add("Fourth Year Level");
            cbTerm.Items.Add("1st Term");
            cbTerm.Items.Add("2nd Term");
            cbPrerequisite.Items.Add("None");

        }

        private void updateList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < manager.subjects.Count; i++)
            {
                Subject subject = manager.findByIndex(i);
                cbID.Items.Add(subject.ID);
            }
        }

        private void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subject subject = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            tbName.Text = subject.Name;
            cbYearLevel.Text = subject.YearLevel;
            cbTerm.Text = subject.Term;
            cbPrerequisite.Text = subject.Prerequisite;
            tbUnits.Text = "" + subject.Units;

            for (int i = 0; i < manager.subjects.Count; i++)
            {
                Subject s = manager.findByIndex(i);
                if (s == subject)
                    return;
                cbPrerequisite.Items.Add(s.Name);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUnits.Text.ToString()))
            {
                MessageBox.Show("Units is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Subject subject = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            subject.Name = tbName.Text.ToString();
            subject.YearLevel = cbYearLevel.Text.ToString();
            subject.Term = cbTerm.Text.ToString();
            subject.Prerequisite = cbPrerequisite.Text.ToString();
            try
            {
                subject.Units = Convert.ToInt32(tbUnits.Text.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("Units must be in whole numbers form!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            manager.update(subject);
            DatabaseHelper.updateSubject(subject);

            MessageBox.Show("Subject " + subject.ID + " successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateList();
        }
    }
}
