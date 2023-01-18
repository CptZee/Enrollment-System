using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;
using Enrollment_System.Enrollment;

namespace Enrollment_System.Menus.Admin
{
    public partial class ApplicationAdd : Form
    {
        private ApplicationFormsManager manager;
        private StudentManager studentManager;
        private AddressManager addressManager;
        private ContactManager contactManager;
        private GuardianManager guardianManager;
        private SchoolHistoryManager historyManager;
        private RequirementManager requirementManager;

        private ApplicationForm application;

        private String picturePath, PSAPath, goodMoralPath, recommendationPath;
        public ApplicationAdd()
        {
            manager = ApplicationFormsManager.getInstance();
            studentManager = StudentManager.getInstance();
            addressManager = AddressManager.getInstance();
            contactManager = ContactManager.getInstance();
            guardianManager = GuardianManager.getInstance();
            requirementManager = RequirementManager.getInstance();
            picturePath = "";
            PSAPath = "";
            goodMoralPath = "";
            recommendationPath = "";
            InitializeComponent();
        }

        private void ApplicationAdd_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            loadStudentIDs();
            loadComboBoxes();
            updateDatabase();
        }


        private void updateDatabase()
        {
            Enrollment_System.loadTables();
        }

        private void cbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = 0;
            try
            {
                ID = Convert.ToInt32(cbStudentID.Text.ToString());
            }
            catch (FormatException)
            {
                return;
            }
            Student stud = studentManager.find(ID);

            //loadValues(stud);
        }

        private void loadStudentIDs()
        {
            cbStudentID.Items.Clear();
            for (int i = 0; i < studentManager.students.Count; i++)
            {
                Student course = studentManager.findByIndex(i);
                cbStudentID.Items.Add(course.ID);
            }
        }

        private void loadComboBoxes()
        {
            CourseManager courseManager = CourseManager.getInstance();
            for (int i = 0; i < courseManager.courses.Count; i++)
            {
                Course course = courseManager.findByIndex(i);
                cbCourse.Items.Add(course.Name);
            }
            cbSchoolType.Items.Add("Primary");
            cbSchoolType.Items.Add("Elementary");
            cbSchoolType.Items.Add("Highschool");
            cbSchoolType.Items.Add("Junior Highschool");
            cbSchoolType.Items.Add("Senior Highschool");
            cbSchoolType.Items.Add("Alternative Learning System Accrediation & Equivalency");
            cbSchoolType.Items.Add("College");
            cbSchoolType.Items.Add("Masteral");
            cbSchoolType.Items.Add("Doctorial");
            cbAdmit.Items.Add("New Student");
            cbAdmit.Items.Add("Transferee");
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbStatus.Items.Add("Single");
            cbStatus.Items.Add("Married");
            cbSY.Items.Add("2022-2023");
            cbSY.Items.Add("2023-2024");
            cbTerm.Items.Add("");
            cbRegular.Items.Add("Regular");
            cbRegular.Items.Add("Iregular");


            if (application != null)
                if (application.Course.Equals(cbCourse.Text.ToString()) && application.SchoolYear.Equals("Fourth Year Level"))
                return;
            cbYearLvl.Items.Add("Fourth Year Level");

            if (application != null)
                if (application.Course.Equals(cbCourse.Text.ToString()) && application.SchoolYear.Equals("Third Year Level"))
                return;
            cbYearLvl.Items.Add("Third Year Level");

            if (application != null)
                if (application.Course.Equals(cbCourse.Text.ToString()) && application.SchoolYear.Equals("Second Year Level"))
                return;
            cbYearLvl.Items.Add("Second Year Level");

            if (application != null)
                if (application.Course.Equals(cbCourse.Text.ToString()) && application.SchoolYear.Equals("First Year Level"))
                return;
            cbYearLvl.Items.Add("First Year Level");

        }

        private void loadValues(Student student)
        {
            application = manager.find(student.ApplicationID);

            cbCourse.SelectedIndex = cbCourse.FindStringExact(application.Course);
            cbYearLvl.SelectedIndex = cbYearLvl.FindStringExact(application.YearLevel);
            if (application.IsRegular)
                cbRegular.SelectedIndex = cbRegular.FindStringExact("Regular");
            else
                cbRegular.SelectedIndex = cbRegular.FindStringExact("Iregular");


            tbFName.Text = student.FirstName;
            tbMName.Text = student.MiddleName;
            tbLName.Text = student.LastName;
            tbSubdivison.Text = student.SuffixName;
            cbGender.SelectedIndex = cbGender.FindStringExact(student.Gender);
            cbStatus.SelectedIndex = cbStatus.FindStringExact(student.Status);
            tbCitizenship.Text = student.Citizenship;
            tbBirthdate.Text = student.BirthDate.ToShortDateString();
            tbBirthplace.Text = student.Birthplace;
            tbReligion.Text = student.Religion;

            Address address = addressManager.find(application.AddressID);
            tbStreetUnit.Text = address.StreetUnitNumber;
            tbStreet.Text = address.Street;
            tbSubdivison.Text = address.SubdivisionVillageBldg;
            tbBarangay.Text = address.Barangay;
            tbCity.Text = address.City;
            tbProvince.Text = address.Province;
            tbZipCode.Text = address.ZipCode;

            Contact contact = contactManager.find(application.ContactID);
            tbTelephone.Text = contact.TelephoneNo;
            tbMobile.Text = contact.MobileNo;
            tbEmail.Text = contact.Email;
        }

        //A bit messy but does the job done for now.
        private Boolean verifyForm()
        {
            String course, admitType, yearLevel, schoolYear, term, firstName, middleName, lastName, suffixName, gender, status, citizenship, birthplace;
            String religion, streetno, street, subdivision, barangay, city, province, zipCode, telephone, mobile, email, type, name, program, regular;
            String guardianFirstName, guardianLastName, guardianMiddleInitial, guardianSuffixName, guardianMobileNumber, guardianEmail, guardianOccupation, guardianRelation;
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

            guardianFirstName = tb_FName_Guardian.Text.ToString();
            guardianLastName = tb_FName_Guardian.Text.ToString();
            guardianMiddleInitial = tb_FName_Guardian.Text.ToString();
            guardianSuffixName= tb_SName_Guardian.Text.ToString();
            guardianMobileNumber = tb_MobileNumber_Guardian.Text.ToString();
            guardianEmail = tb_Email_Guardian.Text.ToString();
            guardianOccupation = tb_Occupation_Guardian.Text.ToString();
            guardianRelation = tb_Relation_Guardian.Text.ToString();

            

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

            if (string.IsNullOrEmpty(guardianFirstName))
            {
                MessageBox.Show("Guardian First Name is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(guardianLastName))
            {
                MessageBox.Show("Guardian Last Name is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(guardianEmail))
            {
                MessageBox.Show("Guardian Email is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(guardianMobileNumber))
            {
                MessageBox.Show("Guardian Mobile Number is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(guardianOccupation))
            {
                MessageBox.Show("Guardian Occupation is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(guardianRelation))
            {
                MessageBox.Show("Guardian Relation is a required field!", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            historyManager = SchoolHistoryManager.getInstance();

            Student student = FormData.getStudent(firstName, middleName, lastName, suffixName, gender, status, citizenship, birthdate, birthplace, religion);
            student.ID = studentManager.getRecentID() + 1;
            Address address = FormData.getAddress(streetno, street, subdivision, barangay, city, province, zipCode);
            address.ID = addressManager.getRecentID() + 1;
            Contact contact = FormData.getContact(telephone, mobile, email);
            contact.ID = contactManager.getRecentID() + 1;
            SchoolHistory schoolHistory = FormData.getSchoolHistory(type, name, program);
            schoolHistory.ID = historyManager.getRecentID() + 1;
            Guardian guardian = FormData.getGuardian(guardianFirstName, guardianLastName, guardianMiddleInitial, guardianSuffixName, guardianMobileNumber, guardianEmail, guardianOccupation, guardianRelation);
            guardian.ID = guardianManager.getRecentID() + 1;
            Requirement requirement = processRequirements();
            requirement.ID = requirementManager.getRecentID() + 1;
            

            application = new ApplicationForm();

            application.ID = manager.getRecentID() + 1;
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
            application.SubmissionDate = DateTime.Today;
            application.Status = "Unpaid";
            if (regular.Equals("Regular"))
                application.IsRegular = true;
            else
                application.IsRegular = false;

            studentManager.add(student);
            addressManager.add(address);
            contactManager.add(contact);
            historyManager.add(schoolHistory);
            guardianManager.add(guardian);
            requirementManager.add(requirement);
            DatabaseHelper.addAddress(address);
            DatabaseHelper.addApplicationForm(application);
            DatabaseHelper.addContact(contact);
            DatabaseHelper.addGuardian(guardian);
            DatabaseHelper.addSchoolHistory(schoolHistory);
            DatabaseHelper.addStudent(student);
            DatabaseHelper.addApplicationSubject(application);
            DatabaseHelper.addApplicationSchedule(application);

            //TODO: Add database helper that insert the values to the database.

            return true;
        }

        private Requirement processRequirements()
        {
            Requirement requirement = new Requirement();
            requirement.PicturePath = picturePath;
            requirement.PSAPath = PSAPath;
            requirement.GoodMoralPath = goodMoralPath;
            requirement.RecommendationPath = recommendationPath;

            return requirement;
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

        private void btnPicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Picture(*.png; *.jpeg;)|*.png; *.jpeg;";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        picturePath = openFileDialog1.FileName;
                        lblPicture.Text = picturePath;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload picture.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPSA_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc;)|*.pdf; *.doc;";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        PSAPath = openFileDialog1.FileName;
                        lblPSA.Text = PSAPath;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGoodMoral_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc;)|*.pdf; *.doc;";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        goodMoralPath = openFileDialog1.FileName;
                        lblGoodMoral.Text = goodMoralPath;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void tb_MobileNumber_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_MobileNumber_Guardian.Text, "[^0-9]"))
            {

                tb_MobileNumber_Guardian.Text = tb_MobileNumber_Guardian.Text.Remove(tb_MobileNumber_Guardian.Text.Length - 1);
            }
        }

        private void tbZipCode_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbZipCode.Text, "[^0-9]"))
            {

                tbZipCode.Text = tbZipCode.Text.Remove(tbZipCode.Text.Length - 1);
            }
        }

        private void btnRecommendation_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc;)|*.pdf; *.doc;";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        recommendationPath = openFileDialog1.FileName;
                        lblPicture.Text = recommendationPath;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (verifyForm()) {
                loadSubjects();
                MessageBox.Show("Application successsfully added", "Applicaiton Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
