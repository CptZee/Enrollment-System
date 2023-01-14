using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Enrollment;

namespace Enrollment_System.Menus
{
    public partial class EnrollFrm : Form
    {
        private ApplicationForm application;
        public EnrollFrm()
        {
            InitializeComponent();
        }

        private void btnProcceed_Click(object sender, EventArgs e)
        {
            if (verifyForm())
                openGuardianInfo();
        }

        private void EnrollFrm_Load(object sender, EventArgs e)
        {
            loadComboBoxes();
        }

        private void openGuardianInfo()
        {
            this.Hide();
            GuardianInfoFrm frm = new GuardianInfoFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private void loadComboBoxes()
        {
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbStatus.Items.Add("Single");
            cbStatus.Items.Add("Married");
            cbAdmit.Items.Add("New Student");
            cbAdmit.Items.Add("Transferee");
            cbYearLvl.Items.Add("First Year Level");
            cbYearLvl.Items.Add("Second Year Level");
            cbYearLvl.Items.Add("Third Year Level");
            cbYearLvl.Items.Add("Fourth Year Level");
            cbYearLvl.Items.Add("Fourth Year Level");
            cbSY.Items.Add("2022-2023");
            cbSY.Items.Add("2023-2024");
            cbTerm.Items.Add("");
            cbSchoolType.Items.Add("Primary");
            cbSchoolType.Items.Add("Elementary");
            cbSchoolType.Items.Add("Highschool");
            cbSchoolType.Items.Add("Junior Highschool");
            cbSchoolType.Items.Add("Senior Highschool");
            cbSchoolType.Items.Add("Alternative Learning System Accrediation & Equivalency");
            cbSchoolType.Items.Add("College");
            cbSchoolType.Items.Add("Masteral");
            cbSchoolType.Items.Add("Doctorial");
        }

        private void cbSY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSY.SelectedItem.ToString().Equals("2022-2023"))
            {
                cbTerm.Items[0] = "2nd Term";
            }
            if (cbSY.SelectedItem.ToString().Equals("2023-2024"))
            {
                cbTerm.Items[0] = "1st Term";
            }
        }


        //A bit messy but does the job done for now.
        private Boolean verifyForm()
        {
            String course, admitType, yearLevel, schoolYear, term, firstName, middleName, lastName, suffixName, gender, status, citizenship, birthplace;
            String religion, streetno, street, subdivision, barangay, city, province, zipCode, telephone, mobile, email, type, name, program;
            DateTime birthdate, SubmissionDate;

            course = cbCourse.Text.ToString();
            admitType = cbAdmit.Text.ToString();
            yearLevel = cbYearLvl.Text.ToString();
            schoolYear = cbSY.Text.ToString(); 
            term = cbTerm.Text.ToString();
            firstName = tbFName.Text.ToString();
            middleName = tbMName.Text.ToString();
            lastName = tbLName.Text.ToString();
            suffixName = tbSName.Text.ToString();
            gender = cbGender.Text.ToString(); 
            status = cbStatus.Text.ToString();
            citizenship = tbCitizenship.Text.ToString();
            birthdate = tbBirthdate.Value.Date;
            birthplace = tbBirthplace.Text.ToString();
            religion = tbReligion.Text.ToString();
            streetno = tbStreetUnit.Text.ToString();
            street = tbStreet.Text.ToString();
            subdivision = tbSubdivison.Text.ToString();
            barangay = tbBarangay.Text.ToString();
            city = tbCity.Text.ToString();
            province = tbProvince.Text.ToString();
            zipCode = tbZipCode.Text.ToString();
            telephone = tbTelephone.Text.ToString();
            mobile = tbMobile.Text.ToString();
            email = tbEmail.Text.ToString();
            type = cbSchoolType.Text.ToString();
            name = tbSchoolName.Text.ToString();
            program = tbSchoolProgram.Text.ToString();
            SubmissionDate = DateTime.Today;

            if (string.IsNullOrEmpty(course))
            {
                MessageBox.Show("Course is a required field!", "Missing Field",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(admitType))
            {
                MessageBox.Show("Admit type is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(yearLevel))
            {
                MessageBox.Show("Year Level is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(schoolYear))
            {
                MessageBox.Show("School year is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(term))
            {
                MessageBox.Show("Term is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First Name is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Gender is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Status is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(citizenship))
            {
                MessageBox.Show("Citizenship is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(birthplace))
            {
                MessageBox.Show("Birthplace is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(religion))
            {
                MessageBox.Show("Religion is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(barangay))
            {
                MessageBox.Show("Street is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("City/Municipality is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(DateTime.Compare(birthdate, SubmissionDate) >= 0){
                MessageBox.Show("Invalid birthdate!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            StudentManager studentManager = StudentManager.getInstance();
            AddressManager addressManager = AddressManager.getInstance();
            ContactManager contactManager = ContactManager.getInstance();
            SchoolHistoryManager schoolHistoryManager = SchoolHistoryManager.getInstance();

            Student student = FormData.getStudent(firstName, middleName, lastName, suffixName, gender, status, citizenship, birthdate, birthplace, religion);
            student.Id = studentManager.retrieveRecentID() + 1;
            Address address = FormData.getAddress(streetno, street, subdivision, barangay, city, province, zipCode);
            address.Id = addressManager.retrieveRecentID() + 1;
            Contact contact = FormData.getContact(telephone, mobile, email);
            contact.Id = contactManager.retrieveRecentID()+ 1;
            SchoolHistory schoolHistory = FormData.getSchoolHistory(type, name, program);
            schoolHistory.Id = schoolHistoryManager.retrieveRecentID() + 1;

            studentManager.addStudent(student);
            addressManager.addAddress(address);
            contactManager.addContact(contact);
            schoolHistoryManager.addSchoolHistory(schoolHistory);

            application = new ApplicationForm();
            //TODO: Change so that it will produce incrimental none-duplicate IDs.

            application.AddressID = address.Id;
            application.StudentID = student.Id;
            application.ContactID = contact.Id;
            application.SchoolYear = schoolYear;
            application.SchoolHistoryID = schoolHistory.Id;
            application.Course = course;
            application.AdmitType = admitType;
            application.YearLevel = yearLevel;
            application.Term = term;

            return true;
        }

        private void btn_Exback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard frm = new Dashboard();
            frm.ShowDialog();
            this.Close();
        }
    }
}
