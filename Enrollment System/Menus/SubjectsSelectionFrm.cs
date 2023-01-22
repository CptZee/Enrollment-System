using System;
using System.Windows.Forms;
using System.Collections;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus
{
    public partial class SubjectsSelectionFrm : Form
    {
        private ApplicationForm application;
        public SubjectsSelectionFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void SubjectsSelectionFrm_Load(object sender, EventArgs e)
        {
            loadSubjectList();
            CenterToScreen();
        }

        private void loadSubjectList()
        {
            SubjectManager subjectManager = SubjectManager.getInstance();
            for(int i = 0; i < subjectManager.subjects.Count; i++)
            {
                Subject subject = subjectManager.findByIndex(i);
                if (!subject.Term.Equals(application.Term))
                    return;
                if (!subject.YearLevel.Equals(application.YearLevel))
                    return;
                lvSubjects.Items.Add(subject.Name);
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if(lvSubjects.SelectedItems.Count > 6)
            {
                MessageBox.Show("Selected subjects are too many!", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lvSubjects.SelectedItems.Count == 0)
            {
                MessageBox.Show("No subject is selected!", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < lvSubjects.SelectedItems.Count; i++)
            {
                SubjectManager manager = SubjectManager.getInstance();
                list.Add(lvSubjects.SelectedItems[i]);
                Subject subject = manager.findByName(lvSubjects.SelectedItems[i].ToString());
                if (subject != null)
                {
                    application.SubjectIDs.Add(subject.ID);
                }
            }

            btnSched.Enabled = false;
            openScheduleForms();
            btnProceed.Enabled = true;
        }

        private void openScheduleForms()
        {
            for (int i = 0; i < lvSubjects.SelectedItems.Count; i++)
            {
                SubjectScheduleFrm frm = new SubjectScheduleFrm(application, lvSubjects.SelectedItems[i].Text);
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationGuardianInfoFrm frm = new ApplicationGuardianInfoFrm(application);
            frm.ShowDialog();
            this.Close();
        }
    }
}
