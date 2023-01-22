using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class ApplicationRemove : Form
    {
        private ApplicationFormsManager applicationFormsManager;
        public ApplicationRemove()
        {
            applicationFormsManager = ApplicationFormsManager.getInstance();
            InitializeComponent();
        }

        private void ApplicationRemove_Load(object sender, EventArgs e)
        {
            updateList();
            CenterToScreen();
        }

        private void updateList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < applicationFormsManager.applicationForms.Count; i++)
            {
                ApplicationForm subject = applicationFormsManager.findByIndex(i);
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

            ApplicationForm application = applicationFormsManager.find(ID);
            if(application == null)
            {
                MessageBox.Show("Application does not exist! Check the ID of the application that you are trying to remove!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ApplicationHelper.removeApplication(application);
            AddressHelper.removeAddress(application.AddressID);
            ContactHelper.removeContact(application.ContactID);
            GuardianHelper.removeGuardian(application.GuardianID);
            SchoolHistoryHelper.removeSchoolHistory(application.SchoolHistoryID);
            RequirementManager manager = RequirementManager.getInstance();
            Requirement requirement = manager.find(application.RequirementID);
            if(requirement != null)
                RequirementHelper.removeRequirement(requirement);
            manager.remove(requirement.ID);

            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            GuardianManager guardianManager = GuardianManager.getInstance();
            SchoolHistoryManager schoolHistoryManger = SchoolHistoryManager.getInstance();

            addressManager.remove(application.AddressID);
            contactManager.remove(application.ContactID);
            guardianManager.remove(application.GuardianID);
            schoolHistoryManger.remove(application.SchoolHistoryID);
            
            applicationFormsManager.remove(ID);
            updateList();
            this.Close();
        }
    }
}
