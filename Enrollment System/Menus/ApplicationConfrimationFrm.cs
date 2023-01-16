using System;
using System.Windows.Forms;
using Enrollment_System.Util;
using Enrollment_System.Data;

namespace Enrollment_System.Menus
{
    public partial class ApplicationConfrimationFrm : Form
    {
        private ApplicationFormsManager applicationManager;
        public ApplicationConfrimationFrm()
        {
            applicationManager = ApplicationFormsManager.getInstance();
            InitializeComponent();
        }


        private void ApplicationConfrimationFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();
            ApplicationForm application = applicationManager.getRecent();

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
            ApplicationFrm frm = new ApplicationFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            GuardianManager guardianManager = GuardianManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();

            ApplicationForm application = applicationManager.getRecent();
            application.SubmissionDate = DateTime.Today;
            application.Status = "Unpaid";
            
            if (application.IsRegular)
                insertSubjects(application);
            applicationManager.add(application);
            DatabaseHelper.addAddress(addressManager.find(application.AddressID));
            DatabaseHelper.addApplicationForm(application);
            DatabaseHelper.addContact(contactManager.find(application.ContactID));
            DatabaseHelper.addGuardian(guardianManager.find(application.GuardianID));
            DatabaseHelper.addSchoolHistory(schoolHistoryManager.find(application.SchoolHistoryID));
            DatabaseHelper.addStudent(studentManager.find(application.StudentID));
            DatabaseHelper.addApplicationSubject(application);
            DatabaseHelper.addApplicationSchedule(application);
            

            MessageBox.Show("Application with the ID of " + application.ID + " has been successfully submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            StatusFrm frm = new StatusFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private void insertSubjects(ApplicationForm application)
        {
            SubjectManager manager = SubjectManager.getInstance();
            for(int i = 0; i < manager.subjects.Count; i++)
            {
                Subject subject = manager.findByIndex(i);
                if (!subject.YearLevel.Equals(application.YearLevel))
                    return;

                if (!subject.Term.Equals(application.Term))
                    return;
                application.SubjectIDs.Add(subject.ID);
            }
        }
    }
}
