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
    public partial class ApplicationRemove : Form
    {
        public ApplicationRemove()
        {
            InitializeComponent();
        }

        private void ApplicationRemove_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text.ToString()))
            {
                MessageBox.Show("ID is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ID = 0;
            try
            {
                ID = Convert.ToInt32(tbID.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("ID must be in whole numbers form!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            ApplicationForm application = applicationFormsManager.find(ID);
            if(application == null)
            {
                MessageBox.Show("Application does not exist! Check the ID of the application that you are trying to remove!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DatabaseHelper.removeApplication(application);
            DatabaseHelper.removeAddress(application.AddressID);
            DatabaseHelper.removeContact(application.ContactID);
            DatabaseHelper.removeGuardian(application.GuardianID);
            DatabaseHelper.removeSchoolHistory(application.SchoolHistoryID);
            for (int i = 0; i < application.RequirementIDs.Count; i++)
            {
                RequirementManager manager = RequirementManager.getInstance();
                Requirement requirement = manager.findByIndex(i);
                DatabaseHelper.removeRequirement(requirement);
                manager.remove(requirement.ID);
            }

            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            GuardianManager guardianManager = GuardianManager.getInstance();
            SchoolHistoryManager schoolHistoryManger = SchoolHistoryManager.getInstance();

            addressManager.remove(application.AddressID);
            contactManager.remove(application.ContactID);
            guardianManager.remove(application.GuardianID);
            schoolHistoryManger.remove(application.SchoolHistoryID);
            
            applicationFormsManager.remove(ID);

            
        }
    }
}
