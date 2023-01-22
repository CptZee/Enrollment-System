using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;

namespace Enrollment_System.Menus.Admin
{
    public partial class ApplicationViewer : Form
    {
        private ApplicationForm application;
        public ApplicationViewer(ApplicationForm application)
        {
            this.application = application;
            InitializeComponent();
        }

        private void ApplicationView_Load(object sender, EventArgs e)
        {
            loadValues(application);
            CenterToScreen();
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

        private void btnDeny_Click(object sender, EventArgs e)
        {
            application.Status = "Deny";
            ApplicationFormsManager manager = ApplicationFormsManager.getInstance();
            ApplicationHelper.updateApplicationForm(application);
            manager.update(application);
            MessageBox.Show("Application has been denied!", "Application Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            application.Status = "Approved";
            ApplicationFormsManager manager = ApplicationFormsManager.getInstance();
            ApplicationHelper.updateApplicationForm(application);
            manager.update(application);
            MessageBox.Show("Application has been approed!", "Application Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
