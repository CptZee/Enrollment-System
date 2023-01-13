using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enrollment_System.Util;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class ApplicationConfrimationFrm : Form
    {
        private ApplicationForm application;
        public ApplicationConfrimationFrm(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void btnStartOver_Click(object sender, EventArgs e)
        {
            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            GuardianManager guardianManager = GuardianManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();

            studentManager.removeRecent();
            addressManager.removeRecent();
            contactManager.removeRecent();
            guardianManager.removeRecent();
            schoolHistoryManager.removeRecent();

            this.Hide();
            EnrollFrm frm = new EnrollFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            GuardianManager guardianManager = GuardianManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();


            application.SubmissionDate = DateTime.Today;
            DatabaseHelper.addAddress(addressManager.find(application.AddressID));
            DatabaseHelper.addApplicationForm(application);
            DatabaseHelper.addContact(contactManager.find(application.ContactID));
            DatabaseHelper.addGuardian(guardianManager.find(application.GuardianID));
            DatabaseHelper.addSchoolHistory(schoolHistoryManager.find(application.SchoolHistoryID));
            DatabaseHelper.addStudent(studentManager.find(application.StudentID));

            applicationManager.addApplicationForm(application);
        }

        private void ApplicationConfrimationFrm_Load(object sender, EventArgs e)
        {
            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();

            lbl_Course.Text = application.Course;
            lbl_Yearlevel.Text = application.YearLevel;
            lbl_Schoolyear.Text = application.SchoolYear;
            lbl_Term.Text = application.Term;
            lbl_Name.Text = studentManager.find(application.StudentID).FirstName + " " + studentManager.find(application.StudentID).MiddleName + " " 
                + studentManager.find(application.StudentID).LastName;
            lbl_Gender.Text = studentManager.find(application.StudentID).Gender;
            lbl_Status.Text = studentManager.find(application.StudentID).Status;
            lbl_Citizenship.Text = studentManager.find(application.StudentID).Citizenship;
            lbl_Birthday.Text = studentManager.find(application.StudentID).BirthDate.ToShortDateString();
            lbl_Birthplace.Text = studentManager.find(application.StudentID).Birthplace;
            lbl_Religion.Text = studentManager.find(application.StudentID).Religion;
            lbl_Address.Text = addressManager.find(application.AddressID).StreetUnitNumber + ", " + addressManager.find(application.AddressID).Street + ", " +
                addressManager.find(application.AddressID).Barangay + ", " + addressManager.find(application.AddressID).City + ", " + addressManager.find(application.AddressID).Province +
                addressManager.find(application.AddressID).ZipCode;
            lbl_TelephoneNo.Text = contactManager.find(application.ContactID).TelephoneNo;
            lbl_MobileNo.Text = contactManager.find(application.ContactID).MobileNo;
            lbl_EmailAdd.Text = contactManager.find(application.ContactID).Email;
            lbl_SchoolType.Text = schoolHistoryManager.find(application.SchoolHistoryID).Type;
            lbl_NameofSchool.Text = schoolHistoryManager.find(application.SchoolHistoryID).Name;
            lbl_ProgramTrackSpecialization.Text = schoolHistoryManager.find(application.SchoolHistoryID).ProgramTrackSpecialization;


        }
    }
}
