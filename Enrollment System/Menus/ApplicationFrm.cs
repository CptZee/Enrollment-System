using System;
using System.Globalization;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Enrollment;
using Enrollment_System.Util;

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
            new ApplicationGuardianInfoFrm(application).ShowDialog();
            this.Show();
        }

        private void openSubjectsSelection()
        {
            this.Hide();
            new SubjectsSelectionFrm(application).ShowDialog();
            this.Show();
        }

        private String format(String text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string loweredText = textInfo.ToLower(text);
            string[] splitedText = loweredText.Split(' ');
            bool first = true;
            String formated = "";

            foreach (string s in splitedText)
            {
                if (first)
                {
                    formated = formated + textInfo.ToTitleCase(s);
                    first = false;
                }
                else
                    formated = formated + s;
            }
            return formated;
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
            cbRegular.Items.Add("Irregular");
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
            firstName = format(tbFName.Text.ToString());
            middleName = format(tbMName.Text.ToString());
            lastName = format(tbLName.Text.ToString());
            suffixName = format(tbSName.Text.ToString());
            gender = cbGender.Text.ToString(); 
            status = cbStatus.Text.ToString();
            citizenship = format(tbCitizenship.Text.ToString());
            birthdate = tbBirthdate.Value.Date;
            birthplace = format(tbBirthplace.Text.ToString());
            religion = format(tbReligion.Text.ToString());
            streetno = format(tbStreetUnit.Text.ToString());
            street = format(tbStreet.Text.ToString());
            subdivision = format(tbSubdivison.Text.ToString());
            barangay = format(tbBarangay.Text.ToString());
            city = format(tbCity.Text.ToString());
            province = format(tbProvince.Text.ToString());
            zipCode = format(tbZipCode.Text.ToString());
            telephone = format(tbTelephone.Text.ToString());
            mobile = format(tbMobile.Text.ToString());
            email = format(tbEmail.Text.ToString());
            type = cbSchoolType.Text.ToString();
            name = format(tbSchoolName.Text.ToString());
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
            contact.ID = contactManager.getRecentID() + 1;
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

            if (application == null)
            {
                MessageBox.Show("Student ID not found! Please check your student ID!", "Student ID not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            loadExistingStudentComboBoxes(application);

            cbExCourse.SelectedIndex = cbExCourse.FindStringExact(application.Course);
            cbExYearLevel.SelectedIndex = cbExYearLevel.FindStringExact(application.YearLevel);
            if(application.IsRegular)
                cbExRegular.SelectedIndex = cbExRegular.FindStringExact("Regular");
            else
                cbExRegular.SelectedIndex = cbExRegular.FindStringExact("Irregular");


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
            cbExRegular.Items.Add("Irregular");

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
            firstName = format(tbExFirstName.Text.ToString());
            middleName = format(tbExMiddleName.Text.ToString());
            lastName = format(tbExLastName.Text.ToString());
            suffixName = format(tbExSuffixName.Text.ToString());
            gender = cbExGender.Text.ToString();
            status = cbExStatus.Text.ToString();
            citizenship = format(tbExCitizenship.Text.ToString());
            birthdate = tbExBirthdate.Value.Date;
            birthplace = format(tbExBirthplace.Text.ToString());
            religion = format(tbExReligion.Text.ToString());
            streetno = format(tbExStreetNo.Text.ToString());
            street = format(tbExStreet.Text.ToString());
            subdivision = format(tbExVillage.Text.ToString());
            barangay = format(tbExBarangay.Text.ToString());
            city = format(tbExCity.Text.ToString());
            province = format(tbExProvince.Text.ToString());
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
            address.ID = application.AddressID;
            student.ID = application.StudentID;
            contact.ID = application.ContactID;
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

        private void tbZipCode_TextChanged(object sender, EventArgs e)
        {
            if (tbZipCode.Text.Length > 4)
            {
                tbZipCode.Text = tbZipCode.Text.Remove(tbZipCode.Text.Length - 1);
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbZipCode.Text, "[^0-9]"))
            {
                tbZipCode.Text = tbZipCode.Text.Remove(tbZipCode.Text.Length - 1);
            }
        }

        private void tbTelephone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbTelephone.Text, "[^0-9]"))
            {

                tbTelephone.Text = tbTelephone.Text.Remove(tbTelephone.Text.Length - 1);
            }
        }

        private void tbMobile_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbMobile.Text, "[^0-9]"))
            {

                tbMobile.Text = tbMobile.Text.Remove(tbMobile.Text.Length - 1);
            }
        }

        private void tbExZipCode_TextChanged(object sender, EventArgs e)
        {
            if (tbExZipCode.Text.Length > 4)
            {
                tbExZipCode.Text = tbExZipCode.Text.Remove(tbExZipCode.Text.Length - 1);
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExZipCode.Text, "[^0-9]"))
            {

                tbExZipCode.Text = tbExZipCode.Text.Remove(tbExZipCode.Text.Length - 1);
            }
        }

        private void tbExTelephone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExTelephone.Text, "[^0-9]"))
            {

                tbExTelephone.Text = tbExTelephone.Text.Remove(tbExTelephone.Text.Length - 1);
            }
        }

        private void tbExMobile_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExMobile.Text, "[^0-9]"))
            {

                tbExMobile.Text = tbExMobile.Text.Remove(tbExMobile.Text.Length - 1);
            }
        }

        private void tbExFirstName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExFirstName.Text, "[^A-Z,a-z ]"))
            {

                tbExFirstName.Text = tbExFirstName.Text.Remove(tbExFirstName.Text.Length - 1);
            }
        }

        private void tbExMiddleName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExMiddleName.Text, "[^A-Z,a-z ]"))
            {

                tbExMiddleName.Text = tbExMiddleName.Text.Remove(tbExMiddleName.Text.Length - 1);
            }
        }

        private void tbExLastName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExLastName.Text, "[^A-Z,a-z ]"))
            {

                tbExLastName.Text = tbExLastName.Text.Remove(tbExLastName.Text.Length - 1);
            }
        }

        private void tbExSuffixName_TextChanged(object sender, EventArgs e)
        {
            if (tbExSuffixName.Text.Length > 3)
            {
                tbExSuffixName.Text = tbExSuffixName.Text.Remove(tbExSuffixName.Text.Length - 1);
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExSuffixName.Text, "[^A-Z,a-z ]"))
            {

                tbExSuffixName.Text = tbExSuffixName.Text.Remove(tbExSuffixName.Text.Length - 1);
            }
        }

        private void tbExCitizenship_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExCitizenship.Text, "[^A-Z,a-z ]"))
            {

                tbExCitizenship.Text = tbExCitizenship.Text.Remove(tbExCitizenship.Text.Length - 1);
            }
        }

        private void tbExBirthplace_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExBirthplace.Text, "[^A-Z,a-z ]"))
            {

                tbExBirthplace.Text = tbExBirthplace.Text.Remove(tbExBirthplace.Text.Length - 1);
            }
        }

        private void tbExReligion_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExReligion.Text, "[^A-Z,a-z ]"))
            {

                tbExReligion.Text = tbExReligion.Text.Remove(tbExReligion.Text.Length - 1);
            }
        }

        private void tbExCity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExCity.Text, "[^A-Z,a-z ]"))
            {

                tbExCity.Text = tbExCity.Text.Remove(tbExCity.Text.Length - 1);
            }
        }

        private void tbExProvince_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExProvince.Text, "[^A-Z,a-z ]"))
            {

                tbExProvince.Text = tbExProvince.Text.Remove(tbExProvince.Text.Length - 1);
            }
        }

        private void tbExID_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbExID.Text, "[^0-9]"))
            {

                tbExID.Text = tbExID.Text.Remove(tbExID.Text.Length - 1);
            }
            if (tbExID.Text.Length > 7)
            {
                tbExID.Text = tbExID.Text.Remove(tbExID.Text.Length - 1);
           }
        }

        private void tbFName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbFName.Text, "[^A-Z,a-z ]"))
            {

                tbFName.Text = tbFName.Text.Remove(tbFName.Text.Length - 1);
            }
        }

        private void tbMName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbMName.Text, "[^A-Z,a-z ]"))
            {

                tbMName.Text = tbMName.Text.Remove(tbMName.Text.Length - 1);
            }
        }

        private void tbLName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbLName.Text, "[^A-Z,a-z ]"))
            {

                tbLName.Text = tbLName.Text.Remove(tbLName.Text.Length - 1);
            }
        }

        private void tbCitizenship_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbCitizenship.Text, "[^A-Z,a-z ]"))
            {

                tbCitizenship.Text = tbCitizenship.Text.Remove(tbCitizenship.Text.Length - 1);
            }
        }

        private void tbBirthplace_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbBirthplace.Text, "[^A-Z,a-z ]"))
            {

                tbBirthplace.Text = tbBirthplace.Text.Remove(tbBirthplace.Text.Length - 1);
            }
        }

        private void tbReligion_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbReligion.Text, "[^A-Z,a-z ]"))
            {

                tbReligion.Text = tbReligion.Text.Remove(tbReligion.Text.Length - 1);
            }
        }

        private void tbCity_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbCity.Text, "[^A-Z,a-z ]"))
            {

                tbCity.Text = tbCity.Text.Remove(tbReligion.Text.Length - 1);
            }
        }

        private void tbProvince_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbProvince.Text, "[^A-Z,a-z ]"))
            {
                tbProvince.Text = tbProvince.Text.Remove(tbProvince.Text.Length - 1);
            }
        }

        private void tbSName_TextChanged(object sender, EventArgs e)
        {
            if (tbSName.Text.Length > 3)
            {
                tbSName.Text = tbSName.Text.Remove(tbSName.Text.Length - 1);
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbSName.Text, "[^A-Z,a-z ]"))
            {

                tbSName.Text = tbSName.Text.Remove(tbSName.Text.Length - 1);
            }
        }
    }
}
