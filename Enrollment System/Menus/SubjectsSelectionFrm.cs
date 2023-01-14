using System;
using System.Windows.Forms;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class SubjectsSelectionFrm : Form
    {
        public SubjectsSelectionFrm(ApplicationForm application)
        {
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
                lvSubjects.Items.Add(subject.Name);
            }
        }
    }
}
