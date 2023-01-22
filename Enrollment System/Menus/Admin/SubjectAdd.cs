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
    public partial class SubjectAdd : Form
    {
        public SubjectAdd()
        {
            InitializeComponent();
        }

        private void SubjectAdd_Load(object sender, EventArgs e)
        {
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
            SubjectManager subjectManager = SubjectManager.getInstance();
            for (int i = 0; i < subjectManager.subjects.Count; i++)
            {
                Subject subject = subjectManager.findByIndex(i);
                cbPrerequisite.Items.Add(subject.Name);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUnits.Text.ToString()))
            {
                MessageBox.Show("Units is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int units = 0;
            try
            {
                units = Convert.ToInt32(tbUnits.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Units must be in whole numbers form!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String name, yearLevel, term, prerequisite;
            name = tbName.Text.ToString();
            yearLevel = cbYearLevel.Text.ToString();
            term = cbTerm.Text.ToString();
            prerequisite = cbPrerequisite.Text.ToString();
            
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(yearLevel))
            {
                MessageBox.Show("Year Level is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(term))
            {
                MessageBox.Show("Term is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(prerequisite))
            {
                MessageBox.Show("Prerequisite is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SubjectManager subjectManager = SubjectManager.getInstance();
            Subject subject = new Subject();
            subject.ID = subjectManager.getRecentID() + 1;
            subject.Name = name;
            subject.YearLevel = yearLevel;
            subject.Term = term;
            subject.Prerequisite = prerequisite;
            subject.Units = units;

            SubjectHelper.addSubject(subject);
            subjectManager.add(subject);
            MessageBox.Show("Subject " + subject.Name + " successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
