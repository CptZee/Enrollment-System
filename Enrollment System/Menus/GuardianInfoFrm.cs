using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_System.Data;
using Enrollment_System.Enrollment;
using System.Windows.Forms;

namespace Enrollment_System.Menus
{
    public partial class GuardianInfoFrm : Form
    {
        private ApplicationForm application;
        public GuardianInfoFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void GuardianInfoFrm_Load(object sender, EventArgs e)
        {

        }

        private void lblPrivacy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.sti.edu/dataprivacy.asp");
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (verifyForm())
                showConfirmationFrm();
        }
        public void showConfirmationFrm()
        {
            this.Hide();
            ApplicationConfrimationFrm frm = new ApplicationConfrimationFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private Boolean verifyForm()
        {
            String firstName, lastName, middileInitial, suffixName, mobile, email, occupation, relation;
            firstName = tb_FName_Guardian.Text.ToString();
            lastName = tb_LName_Guardian.Text.ToString();
            middileInitial = tb_MI_Guardian.Text.ToString();
            suffixName = tb_SName_Guardian.Text.ToString();
            mobile = tb_MobileNumber_Guardian.Text.ToString();
            email = tb_Email_Guardian.Text.ToString();
            occupation = tb_Occupation_Guardian.Text.ToString();
            relation = tb_Relation_Guardian.Text.ToString();

            if (!cb_Privacy.Checked)
            {
                MessageBox.Show("Must accept privacy terms!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First name is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Last name is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(mobile))
            {
                MessageBox.Show("Mobile No. is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email Address is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(relation))
            {
                MessageBox.Show("Relation is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            GuardianManager guardianManager = GuardianManager.getInstance();
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            Guardian guardian = FormData.getGuardian(firstName, lastName, middileInitial, suffixName, mobile, email, occupation, relation);
            guardian.ID = guardianManager.retrieveRecentID() + 1;
            application.GuardianID = guardian.ID;
            guardianManager.add(guardian);
            applicationManager.addApplicationForm(application);
            return true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
