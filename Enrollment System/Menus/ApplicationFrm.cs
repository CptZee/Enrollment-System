using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Enrollment;

namespace Enrollment_System.Menus
{
    public partial class ApplicationFrm : Form
    {
        private ApplicationForm application;
        private ApplicationFormsManager applicationFormsManager;
        private StudentManager studentManager;
        private AddressManager addressManager;
        private ContactManager contactManager;
        private SchoolHistoryManager schoolHistoryManager;
        public ApplicationFrm()
        {
            applicationFormsManager = ApplicationFormsManager.getInstance();
            studentManager = StudentManager.getInstance();
            addressManager = AddressManager.getInstance();
            contactManager = ContactManager.getInstance();
            schoolHistoryManager = SchoolHistoryManager.getInstance();
            InitializeComponent();
        }

        private void btnProcceed_Click(object sender, EventArgs e)
        {
            if (verifyForm())
                if (cbRegular.Text.ToString().Equals("Regular")) {
                    loadSubjects();
                    openGuardianInfo();
                }
                else
                    openSubjectsSelection();
        }

        private void EnrollFrm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            updateDatabase();
            loadComboBoxes();
        }
        private void updateDatabase()
        {
            Enrollment_System.loadTables();
        }

        private void loadSubjects()
        {
            SubjectManager subjectManager = SubjectManager.getInstance();
            for (int i = 0; i < subjectManager.subjects.Count; i++)
            {
                Subject subject = subjectManager.findByIndex(i);
                if (!subject.Term.Equals(application.Term))
                    return;
                if (!subject.YearLevel.Equals(application.YearLevel))
                    return;
                application.SubjectIDs.Add(subject.ID);
            }
        }

        private void openGuardianInfo()
        {
            this.Hide();
            ApplicationGuardianInfoFrm frm = new ApplicationGuardianInfoFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private void openSubjectsSelection()
        {
            this.Hide();
            SubjectsSelectionFrm frm = new SubjectsSelectionFrm(application);
            frm.ShowDialog();
            this.Close();
        }

        private void loadComboBoxes()
        {
            CourseManager courseManager = CourseManager.getInstance();
            for(int i = 0; i < courseManager.courses.Count; i++)
            {
                Course course = courseManager.findByIndex(i);
                cbCourse.Items.Add(course.Name);
            }
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbStatus.Items.Add("Single");
            cbStatus.Items.Add("Married");
            cbAdmit.Items.Add("New Student");
            cbAdmit.Items.Add("Transferee");
            cbYearLvl.Items.Add("Fourth Year Level");
            cbYearLvl.Items.Add("Third Year Level");
            cbYearLvl.Items.Add("Second Year Level");
            cbYearLvl.Items.Add("First Year Level");
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
            cbRegular.Items.Add("Regular");
            cbRegular.Items.Add("Iregular");
        }

        //A bit messy but does the job done for now.
        private Boolean verifyForm()
        {
            String course, admitType, yearLevel, schoolYear, term, firstName, middleName, lastName, suffixName, gender, status, citizenship, birthplace;
            String religion, streetno, street, subdivision, barangay, city, province, zipCode, telephone, mobile, email, type, name, program, regular;
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
            regular = cbRegular.Text.ToString();
            SubmissionDate = DateTime.Today;

            if (string.IsNullOrEmpty(course))
            {
                MessageBox.Show("Course is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Barangay is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrEmpty(regular))
            {
                MessageBox.Show("Student Type is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Compare(birthdate, SubmissionDate) >= 0)
            {
                MessageBox.Show("Invalid birthdate!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            Student student = FormData.getStudent(firstName, middleName, lastName, suffixName, gender, status, citizenship, birthdate, birthplace, religion);
            student.ID = studentManager.getRecentID() + 1;
            Address address = FormData.getAddress(streetno, street, subdivision, barangay, city, province, zipCode);
            address.ID = addressManager.getRecentID() + 1;
            Contact contact = FormData.getContact(telephone, mobile, email);
            contact.ID = contactManager.getRecentID()+ 1;
            SchoolHistory schoolHistory = FormData.getSchoolHistory(type, name, program);
            schoolHistory.ID = schoolHistoryManager.getRecentID() + 1;

            application = new ApplicationForm();

            application.ID = applicationFormsManager.getRecentID() + 1;
            student.ApplicationID = application.ID;
            application.AddressID = address.ID;
            application.StudentID = student.ID;
            application.ContactID = contact.ID;
            application.SchoolYear = schoolYear;
            application.SchoolHistoryID = schoolHistory.ID;
            application.Course = course;
            application.AdmitType = admitType;
            application.YearLevel = yearLevel;
            application.Term = term;
            if (regular.Equals("Regular"))
                application.IsRegular = true;
            else
                application.IsRegular = false;

            studentManager.add(student);
            addressManager.add(address);
            contactManager.add(contact);
            schoolHistoryManager.add(schoolHistory);
            return true;
        }

        private void btn_Exback_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardFrm frm = new DashboardFrm();
            frm.ShowDialog();
            this.Close();
        }

        private void cbSY_SelectedIndexChanged_1(object sender, EventArgs e)
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


        /**
         * Existing Student Application Form Section
         * 
         */

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbExID.Text.ToString()))
            {
                MessageBox.Show("Student ID field is required!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int ID = 0;
            try
            {
                ID = Convert.ToInt32(tbExID.Text.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("ID must be in whole numbers form!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stud = studentManager.find(ID);
            if(stud == null)
            {
                MessageBox.Show("Student not found! Please check your ID.", "Student not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loadValues(stud); 
        }


        private void cbExSY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExSY.SelectedItem.ToString().Equals("2022-2023"))
            {
                cbExTerm.Items[0] = "2nd Term";
            }
            if (cbExSY.SelectedItem.ToString().Equals("2023-2024"))
            {
                cbExTerm.Items[0] = "1st Term";
            }

        }

        private void btnExProceed_Click(object sender, EventArgs e)
        {
            if (verifyExistingForm())
                if (cbExRegular.Text.ToString().Equals("Regular"))
                {
                    loadSubjects();
                    openGuardianInfo();
                }
                else
                    openSubjectsSelection();
        }

        private void loadValues(Student student)
        {
            enableFields();
            ApplicationForm application = applicationFormsManager.find(student.ApplicationID);
            loadExistingStudentComboBoxes(application);

            cbExCourse.SelectedIndex = cbExCourse.FindStringExact(application.Course);
            cbExYearLevel.SelectedIndex = cbExYearLevel.FindStringExact(application.YearLevel);
            if(application.IsRegular)
                cbExRegular.SelectedIndex = cbExRegular.FindStringExact("Regular");
            else
                cbExRegular.SelectedIndex = cbExRegular.FindStringExact("Iregular");


            tbExFirstName.Text = student.FirstName;
            tbExMiddleName.Text = student.MiddleName;
            tbExLastName.Text = student.LastName;
            tbSubdivison.Text = student.SuffixName;
            cbExGender.SelectedIndex = cbExGender.FindStringExact(student.Gender);
            cbExStatus.SelectedIndex = cbExStatus.FindStringExact(student.Status);
            tbExCitizenship.Text = student.Citizenship;
            tbExBirthdate.Text = student.BirthDate.ToShortDateString();
            tbExBirthplace.Text = student.Birthplace;
            tbExReligion.Text = student.Religion;

            Address address = addressManager.find(application.AddressID);
            tbExStreetNo.Text = address.StreetUnitNumber;
            tbExStreet.Text = address.Street;
            tbExVillage.Text = address.SubdivisionVillageBldg;
            tbExBarangay.Text = address.Barangay;
            tbExCity.Text = address.City;
            tbExProvince.Text = address.Province;
            tbExZipCode.Text = address.ZipCode;

            Contact contact = contactManager.find(application.ContactID);
            tbExTelephone.Text = contact.TelephoneNo;
            tbExMobile.Text = contact.MobileNo;
            tbExEmail.Text = contact.Email;
        }

        private void enableFields()
        {
            cbExCourse.Enabled = true;
            cbExYearLevel.Enabled = true;
            cbExSY.Enabled = true;
            cbExRegular.Enabled = true;
            cbExTerm.Enabled = true;
            tbExFirstName.Enabled = true;
            tbExMiddleName.Enabled = true;
            tbExLastName.Enabled = true;
            tbExSuffixName.Enabled = true;
            tbSubdivison.Enabled = true;
            tbExCitizenship.Enabled = true;
            tbExBirthdate.Enabled = true;
            tbExBirthplace.Enabled = true;
            tbExReligion.Enabled = true;
            tbExStreetNo.Enabled = true;
            tbExStreet.Enabled = true;
            tbExVillage.Enabled = true;
            tbExBarangay.Enabled = true;
            tbExCity.Enabled = true;
            tbExProvince.Enabled = true;
            tbExZipCode.Enabled = true;
            tbExTelephone.Enabled = true;
            tbExMobile.Enabled = true;
            tbExEmail.Enabled = true;
            cbExGender.Enabled = true;
            cbExStatus.Enabled = true;
        }

        private void loadExistingStudentComboBoxes(ApplicationForm application)
        {
            CourseManager courseManager = CourseManager.getInstance();
            for (int i = 0; i < courseManager.courses.Count; i++)
            {
                Course course = courseManager.findByIndex(i);
                cbExCourse.Items.Add(course.Name);
            }
            cbExGender.Items.Add("Male");
            cbExGender.Items.Add("Female");
            cbExStatus.Items.Add("Single");
            cbExStatus.Items.Add("Married");
            cbExSY.Items.Add("2022-2023");
            cbExSY.Items.Add("2023-2024");
            cbExTerm.Items.Add("");
            cbExRegular.Items.Add("Regular");
            cbExRegular.Items.Add("Iregular");

            if (application.Course.Equals(cbExCourse.Text.ToString()) && application.SchoolYear.Equals("Fourth Year Level"))
                return;
            cbExYearLevel.Items.Add("Fourth Year Level");
            if (application.Course.Equals(cbExCourse.Text.ToString()) && application.SchoolYear.Equals("Third Year Level"))
                return;
            cbExYearLevel.Items.Add("Third Year Level");
            if (application.Course.Equals(cbExCourse.Text.ToString()) && application.SchoolYear.Equals("Second Year Level"))
                return;
            cbExYearLevel.Items.Add("Second Year Level");
            if (application.Course.Equals(cbExCourse.Text.ToString()) && application.SchoolYear.Equals("First Year Level"))
                return;
            cbExYearLevel.Items.Add("First Year Level");

        }


        private Student stud;
        //A bit messy but does the job done for now.
        private Boolean verifyExistingForm()
        {
            String course, schoolYear, term, firstName, middleName, lastName, suffixName, gender, status, citizenship, birthplace;
            String religion, streetno, street, subdivision, barangay, city, province, zipCode, telephone, mobile, email, regular;
            DateTime birthdate, SubmissionDate;

            course = cbExCourse.Text.ToString();
            schoolYear = cbExSY.Text.ToString();
            term = cbExTerm.Text.ToString();
            firstName = tbExFirstName.Text.ToString();
            middleName = tbExMiddleName.Text.ToString();
            lastName = tbExLastName.Text.ToString();
            suffixName = tbExSuffixName.Text.ToString();
            gender = cbExGender.Text.ToString();
            status = cbExStatus.Text.ToString();
            citizenship = tbExCitizenship.Text.ToString();
            birthdate = tbExBirthdate.Value.Date;
            birthplace = tbExBirthplace.Text.ToString();
            religion = tbExReligion.Text.ToString();
            streetno = tbExStreetNo.Text.ToString();
            street = tbExStreet.Text.ToString();
            subdivision = tbExVillage.Text.ToString();
            barangay = tbExBarangay.Text.ToString();
            city = tbExCity.Text.ToString();
            province = tbExProvince.Text.ToString();
            zipCode = tbExZipCode.Text.ToString();
            telephone = tbExTelephone.Text.ToString();
            mobile = tbExMobile.Text.ToString();
            email = tbExEmail.Text.ToString();
            regular = cbExRegular.Text.ToString();
            SubmissionDate = DateTime.Today;

            if (string.IsNullOrEmpty(course))
            {
                MessageBox.Show("Course is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Barangay is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrEmpty(regular))
            {
                MessageBox.Show("Student Type is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Compare(birthdate, SubmissionDate) >= 0)
            {
                MessageBox.Show("Invalid birthdate!", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            Student student = FormData.getStudent(firstName, middleName, lastName, suffixName, gender, status, citizenship, birthdate, birthplace, religion);
            Address address = FormData.getAddress(streetno, street, subdivision, barangay, city, province, zipCode);
            Contact contact = FormData.getContact(telephone, mobile, email);

            application = applicationFormsManager.find(stud.ApplicationID);
            application.ID = application.ID + 1;
            student.ApplicationID = application.ID;
            application.AddressID = address.ID;
            application.StudentID = student.ID;
            application.ContactID = contact.ID;
            application.SchoolYear = schoolYear;
            application.Course = course;
            application.Term = term;
            if (regular.Equals("Regular"))
                application.IsRegular = true;
            else
                application.IsRegular = false;

            studentManager.add(student);
            addressManager.add(address);
            contactManager.add(contact);
            return true;
        }
       
    }
}
