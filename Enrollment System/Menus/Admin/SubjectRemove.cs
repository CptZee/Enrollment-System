using System;
using System.Linq;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class SubjectRemove : Form
    {
        private SubjectManager manager;
        public SubjectRemove()
        {
            manager = SubjectManager.getInstance();
            InitializeComponent();
        }

        private void SubjectRemove_Load(object sender, EventArgs e)
        {
            updateList();
            CenterToScreen();
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

            Subject subject = manager.find(ID);
            if (subject == null)
            {
                MessageBox.Show("Subject does not exist! Check the ID of the subject that you are trying to remove!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SubjectHelper.removeSubject(subject);

            manager.remove(ID);
            MessageBox.Show("Subject " + subject.ID + " successfully removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updateList();
            this.Close();
        }
    }
}
