using System;
using System.Windows.Forms;
using Enrollment_System.Data;
using Enrollment_System.Util;
using Enrollment_System.Enrollment;
using System.Globalization;

namespace Enrollment_System.Menus.Admin
{
    public partial class ApplicationModify : Form
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
        public ApplicationModify()
        {
            manager = ApplicationFormsManager.getInstance();
            studentManager = StudentManager.getInstance();
            addressManager = AddressManager.getInstance();
            contactManager = ContactManager.getInstance();
            guardianManager = GuardianManager.getInstance();
            requirementManager = RequirementManager.getInstance();
            historyManager = SchoolHistoryManager.getInstance();
            picturePath = "";
            PSAPath = "";
            goodMoralPath = "";
            recommendationPath = "";
            InitializeComponent();
        }

        private void ApplicationModify_Load(object sender, EventArgs e)
        {
            loadList();
            CenterToScreen();
            loadComboBoxes();
        }

        private void loadList()
        {
            cbID.Items.Clear();
            for (int i = 0; i < manager.applicationForms.Count; i++)
            {
                ApplicationForm application = manager.findByIndex(i);
                this.application = application;
                cbID.Items.Add(application.ID);
            }
        }


        private void enableFields()
        {
            cbID.Enabled = true;
            cbCourse.Enabled = true;
            cbAdmit.Enabled = true;
            cbYearLvl.Enabled = true;
            cbSY.Enabled = true;
            cbTerm.Enabled = true;
            cbRegular.Enabled = true;

            btnPicture.Enabled = true;
            btnPSA.Enabled = true;
            btnGoodMoral.Enabled = true;
            btnRecommendation.Enabled = true;

            tbFName.Enabled = true;
            tbMName.Enabled = true;
            tbLName.Enabled = true;
            tbSName.Enabled = true;
            cbGender.Enabled = true;
            cbStatus.Enabled = true;
            tbCitizenship.Enabled = true;
            tbBirthdate.Enabled = true;
            tbBirthplace.Enabled = true;
            tbReligion.Enabled = true;

            tbStreetUnit.Enabled = true;
            tbStreet.Enabled = true;
            tbSubdivison.Enabled = true;
            tbBarangay.Enabled = true;
            tbCity.Enabled = true;
            tbProvince.Enabled = true;
            tbZipCode.Enabled = true;

            tbTelephone.Enabled = true;
            tbMobile.Enabled = true;
            tbEmail.Enabled = true;

            cbSchoolType.Enabled = true;
            tbSchoolName.Enabled = true;
            tbSchoolProgram.Enabled = true;

            tb_FName_Guardian.Enabled = true;
            tb_MI_Guardian.Enabled = true;
            tb_LName_Guardian.Enabled = true;
            tb_SName_Guardian.Enabled = true;
            tb_MobileNumber_Guardian.Enabled = true;
            tb_Email_Guardian.Enabled = true;
            tb_Occupation_Guardian.Enabled = true;
            tb_Relation_Guardian.Enabled = true;
            
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
            cbRegular.Items.Add("Irregular");


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
                cbRegular.SelectedIndex = cbRegular.FindStringExact("Irregular");


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
            streetno = tbStreetUnit.Text.ToString();
            street = tbStreet.Text.ToString();
            subdivision = format(tbSubdivison.Text.ToString());
            barangay = format(tbBarangay.Text.ToString());
            city = format(tbCity.Text.ToString());
            province = format(tbProvince.Text.ToString());
            zipCode = tbZipCode.Text.ToString();
            telephone = tbTelephone.Text.ToString();
            mobile = tbMobile.Text.ToString();
            email = tbEmail.Text.ToString();
            type = cbSchoolType.Text.ToString();
            name = format(tbSchoolName.Text.ToString());
            program = tbSchoolProgram.Text.ToString();
            regular = cbRegular.Text.ToString();
            SubmissionDate = DateTime.Today;

            guardianFirstName = tb_FName_Guardian.Text.ToString();
            guardianLastName = tb_FName_Guardian.Text.ToString();
            guardianMiddleInitial = tb_FName_Guardian.Text.ToString();
            guardianSuffixName = tb_SName_Guardian.Text.ToString();
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
            student.ID = application.StudentID;
            Address address = FormData.getAddress(streetno, street, subdivision, barangay, city, province, zipCode);
            address.ID = application.AddressID;
            Contact contact = FormData.getContact(telephone, mobile, email);
            contact.ID = application.ContactID;
            SchoolHistory schoolHistory = FormData.getSchoolHistory(type, name, program);
            schoolHistory.ID = application.SchoolHistoryID;
            Guardian guardian = FormData.getGuardian(guardianFirstName, guardianLastName, guardianMiddleInitial, guardianSuffixName, guardianMobileNumber, guardianEmail, guardianOccupation, guardianRelation);
            guardian.ID = application.GuardianID;
            Requirement requirement = processRequirements();
            requirement.ID = application.RequirementID;

            application.ID = manager.getRecentID() + 1;
            student.ApplicationID = application.ID;
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

            manager.update(application);
            studentManager.update(student);
            addressManager.update(address);
            contactManager.update(contact);
            historyManager.update(schoolHistory);
            guardianManager.update(guardian);
            requirementManager.update(requirement);
            AddressHelper.updateAddress(address);
            ApplicationHelper.updateApplicationForm(application);
            ContactHelper.updateContact(contact);
            GuardianHelper.updateGuardian(guardian);
            SchoolHistoryHelper.updateSchoolHistory(schoolHistory);
            StudentHelper.updateStudent(student);
            ApplicationSystemDataHelper.updateApplicationSubject(application);
            ApplicationSystemDataHelper.updateApplicationSchedule(application);

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

        private void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: update values based on the 
            ApplicationForm application = manager.find(Convert.ToInt32(cbID.Text.ToString()));
            Console.WriteLine("Application is " + application.ID);
            Console.WriteLine("Checking for Student ID: " + application.StudentID);
            Student student = studentManager.find(application.StudentID);
            Address address = addressManager.find(application.AddressID);
            Contact contact = contactManager.find(application.ContactID);
            Guardian guardian = guardianManager.find(application.GuardianID);
            SchoolHistory schoolhistory = historyManager.find(application.SchoolHistoryID);
            //TODO: Check how requirements are handled. MUST BE ONE PER APPLICATION!
            //Requirement requirement = requirementManager.find(application.RequirementIDs);

            cbCourse.Text = application.Course;
            cbAdmit.Text = application.AdmitType;
            cbYearLvl.Text = application.YearLevel;
            cbSY.Text = application.SchoolYear;
            cbTerm.Text = application.Term;

            tbFName.Text = student.FirstName;
            tbMName.Text = student.MiddleName;
            tbLName.Text = student.LastName;
            tbSName.Text = student.SuffixName;
            cbGender.Text = student.Gender;
            cbStatus.Text = student.Status;
            tbCitizenship.Text = student.Citizenship;
            tbBirthdate.Text = student.BirthDate.ToShortDateString();
            tbBirthplace.Text = student.Birthplace;
            tbReligion.Text = student.Religion;

            tbStreetUnit.Text = address.StreetUnitNumber;
            tbStreet.Text = address.Street;
            tbSubdivison.Text = address.SubdivisionVillageBldg;
            tbBarangay.Text = address.Barangay;
            tbCity.Text = address.City;
            tbProvince.Text = address.Province;
            tbZipCode.Text = address.ZipCode;

            tbTelephone.Text = contact.TelephoneNo;
            tbMobile.Text = contact.MobileNo;
            tbEmail.Text = contact.Email;

            cbSchoolType.Text = schoolhistory.Type;
            tbSchoolName.Text = schoolhistory.Name;
            tbSchoolProgram.Text = schoolhistory.ProgramTrackSpecialization;

            tb_FName_Guardian.Text = guardian.FirstName;
            tb_MI_Guardian.Text = guardian.MiddleInitial;
            tb_LName_Guardian.Text = guardian.LastName;
            tb_SName_Guardian.Text = guardian.SuffixName;
            tb_MobileNumber_Guardian.Text = guardian.MobileNumber;
            tb_Email_Guardian.Text = guardian.Email;
            tb_Occupation_Guardian.Text = guardian.Occupation;
            tb_Relation_Guardian.Text = guardian.Relation;

            enableFields();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (verifyForm())
            {
                loadSubjects();
                MessageBox.Show("Application successsfully added", "Applicaiton Successfully Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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

        private void tb_MobileNumber_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_MobileNumber_Guardian.Text, "[^0-9]"))
            {

                tb_MobileNumber_Guardian.Text = tb_MobileNumber_Guardian.Text.Remove(tb_MobileNumber_Guardian.Text.Length - 1);
            }
        }

        private void tb_FName_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_FName_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_FName_Guardian.Text = tb_FName_Guardian.Text.Remove(tb_FName_Guardian.Text.Length - 1);
            }
        }

        private void tb_LName_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_LName_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_LName_Guardian.Text = tb_LName_Guardian.Text.Remove(tb_LName_Guardian.Text.Length - 1);
            }
        }

        private void tb_MI_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (tb_MI_Guardian.Text.Length > 3)
            {
                tb_MI_Guardian.Text = tb_MI_Guardian.Text.Remove(tb_MI_Guardian.Text.Length - 1);
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_MI_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_MI_Guardian.Text = tb_MI_Guardian.Text.Remove(tb_MI_Guardian.Text.Length - 1);
            }
        }

        private void tb_SName_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_SName_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_SName_Guardian.Text = tb_SName_Guardian.Text.Remove(tb_SName_Guardian.Text.Length - 1);
            }
        }

        private void tb_Occupation_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_Occupation_Guardian.Text, "[^A-Z,a-z ]"))
            {

                tb_Occupation_Guardian.Text = tb_Occupation_Guardian.Text.Remove(tb_Occupation_Guardian.Text.Length - 1);
            }
        }

        private void tb_Relation_Guardian_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tb_Relation_Guardian.Text, "[^A-Z,a-z ]"))
            {
                tb_Relation_Guardian.Text = tb_Relation_Guardian.Text.Remove(tb_Relation_Guardian.Text.Length - 1);
            }
        }

        private void tb_Email_Guardian_TextChanged(object sender, EventArgs e)
        {

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
    }
}
