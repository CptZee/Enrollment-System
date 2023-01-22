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
            ApplicationForm application = applicationManager.getRecent();

            loadValues(application);
        }

        private void loadValues(ApplicationForm application)
        {

            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            GuardianManager guardianManager = GuardianManager.getInstance();
            RequirementManager requirementManager = RequirementManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();
            Student student = studentManager.find(application.StudentID);
            Address address = addressManager.find(application.AddressID);
            Contact contact = contactManager.find(application.ContactID);
            SchoolHistory schoolHistory = schoolHistoryManager.find(application.SchoolHistoryID);
            Guardian guardian = guardianManager.find(application.GuardianID);
            Requirement requirement = requirementManager.find(application.RequirementID);

            lbl_Course.Text = application.Course;
            lbl_Schoolyear.Text = application.SchoolYear;
            if (application.IsRegular)
                lblStudentType.Text = "Regular";
            else
                lblStudentType.Text = "Irregular";
            lbl_Yearlevel.Text = application.YearLevel;
            lbl_Term.Text = application.Term;
            lblStudentID.Text = "" + application.StudentID;
            lblStudentFirstName.Text = student.FirstName;
            lblStudentlMiddleName.Text = student.MiddleName;
            lblStudentLastName.Text = student.LastName;
            lblStudentSuffixName.Text = student.SuffixName;
            lblStudentGender.Text = student.Gender;
            lblStudentStatus.Text = student.Status;
            lblStudentCitizenship.Text = student.Citizenship;
            lblStudentBirthday.Text = student.BirthDate.ToShortDateString();
            lblStudentBirthplace.Text = student.Birthplace;
            lblStudentReligion.Text = student.Religion;
            lblAddressStreetNo.Text = address.StreetUnitNumber;
            lblAddressStreet.Text = address.Street;
            lblAddressSubdivision.Text = address.SubdivisionVillageBldg;
            lblAddressBarangay.Text = address.Barangay;
            lblAddressCity.Text = address.City;
            lblAddressProvince.Text = address.Province;
            lblAddressZipCode.Text = address.ZipCode;
            lblContactTelephoneNo.Text = contact.TelephoneNo;
            lblContactMobileNo.Text = contact.MobileNo;
            lblContactEmailAdd.Text = contact.Email;
            lblHistoryNameofSchool.Text = schoolHistory.Name;
            lblHistorySchoolType.Text = schoolHistory.Type;
            lblHistoryProgramTrackSpecialization.Text = schoolHistory.ProgramTrackSpecialization;
            lblGuardianFirstName.Text = guardian.FirstName;
            lblGuardianMiddleName.Text = guardian.MiddleInitial;
            lblGuardianLastName.Text = guardian.LastName;
            lblGuardianSuffixName.Text = guardian.SuffixName;
            lblGuardianMobile.Text = guardian.MobileNumber;
            lblGuardianEmail.Text = guardian.Email;
            lblGuardianOccupation.Text = guardian.Occupation;
            lblGuardianRelation.Text = guardian.Relation;
            lblReqPicture.Text = requirement.PicturePath;
            lblReqPSA.Text = requirement.PSAPath;
            lblReqGoodMoral.Text = requirement.GoodMoralPath;
            lblReqRecommendation.Text = requirement.RecommendationPath;
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
            RequirementManager requirementManager = RequirementManager.getInstance();

            ApplicationForm application = applicationManager.getRecent();
            application.SubmissionDate = DateTime.Today;
            application.Status = "Unpaid";
            
            if (application.IsRegular)
                insertSubjects(application);
            applicationManager.update(application);
            AddressHelper.addAddress(addressManager.find(application.AddressID));
            ApplicationHelper.addApplicationForm(application);
            ContactHelper.addContact(contactManager.find(application.ContactID));
            GuardianHelper.addGuardian(guardianManager.find(application.GuardianID));
            SchoolHistoryHelper.addSchoolHistory(schoolHistoryManager.find(application.SchoolHistoryID));
            StudentHelper.addStudent(studentManager.find(application.StudentID));
            RequirementHelper.addRequirement(requirementManager.find(application.RequirementID));
            ApplicationSystemDataHelper.addApplicationSubject(application);
            //ApplicationSystemDataHelper.addApplicationSchedule(application); //Commented for now
            

            MessageBox.Show("Application with the ID of " + application.ID + " and Student ID of " + application.StudentID + " has been successfully submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
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

        private void lblStudentType_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Schoolyear_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentGender_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
