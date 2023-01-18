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
    public partial class ApplicationGuardianInfoFrm : Form
    {
        private ApplicationForm application;
        public ApplicationGuardianInfoFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void GuardianInfoFrm_Load(object sender, EventArgs e)
        {
            loadValues();
            CenterToScreen();
        }

        private void loadValues()
        {
            GuardianManager manager = GuardianManager.getInstance();
            Guardian guardian = manager.find(application.GuardianID);
            if (guardian == null)
                return;
            tb_FName_Guardian.Text = guardian.FirstName;
            tb_LName_Guardian.Text = guardian.LastName;
            tb_MI_Guardian.Text = guardian.MiddleInitial;
            tb_SName_Guardian.Text = guardian.SuffixName;
            tb_MobileNumber_Guardian.Text = guardian.MobileNumber;
            tb_Email_Guardian.Text = guardian.Email;
            tb_Occupation_Guardian.Text = guardian.Occupation;
            tb_Relation_Guardian.Text = guardian.Relation;
        }

        private void lblPrivacy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.sti.edu/dataprivacy.asp");
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (verifyForm())
                showRequirements();
        }
        public void showRequirements()
        {
            this.Hide();
            ApplicationRequirementFrm frm = new ApplicationRequirementFrm(application);
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
            guardian.ID = guardianManager.getRecentID() + 1;
            application.GuardianID = guardian.ID;
            guardianManager.add(guardian);
            applicationManager.add(application);
            return true;
        }

        private void tb_MobileNumber_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_MobileNumber_Guardian.Text, "[^0-9]"))
            {

                tb_MobileNumber_Guardian.Text = tb_MobileNumber_Guardian.Text.Remove(tb_MobileNumber_Guardian.Text.Length - 1);
            }
        }

        private void tb_FName_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_FName_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_FName_Guardian.Text = tb_FName_Guardian.Text.Remove(tb_FName_Guardian.Text.Length - 1);
            }
        }

        private void tb_LName_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_LName_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_LName_Guardian.Text = tb_LName_Guardian.Text.Remove(tb_LName_Guardian.Text.Length - 1);
            }
        }

        private void tb_MI_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_MI_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_MI_Guardian.Text = tb_MI_Guardian.Text.Remove(tb_MI_Guardian.Text.Length - 1);
            }
        }

        private void tb_SName_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_SName_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_SName_Guardian.Text = tb_SName_Guardian.Text.Remove(tb_SName_Guardian.Text.Length - 1);
            }
        }

        private void tb_Occupation_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_Occupation_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_Occupation_Guardian.Text = tb_Occupation_Guardian.Text.Remove(tb_Occupation_Guardian.Text.Length - 1);
            }
        }

        private void tb_Relation_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_Relation_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_Relation_Guardian.Text = tb_Relation_Guardian.Text.Remove(tb_Relation_Guardian.Text.Length - 1);
            }
        }
    }
}
