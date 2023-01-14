using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    /**
     * A helper class which contains all the methods regarding the datase.
     * WARNING: MUST RUN ON CHILD THREADS
     * 
     */ 
    class DatabaseHelper
    {
        //Modify depending on the computer's database. WILL ONLY WORK ON AARON's PC!
        protected static String connectionURL = @"Data Source=AARON\SQLEXPRESS;Integrated Security=True";

        /*
         * A simple method which returns the connection.
         * 
        **/
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionURL);
            return connection;
        }

        /**
        * A simple code that will create the Courses table.
        * 
        * @return if the table is created successfully.
        * 
        */
        public static void createCoursesTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Courses", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Courses Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Courses Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Courses
                (
                    [ID] INT NOT NULL IDENTITY(1,1), 
                    [Name] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createSubjectsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Subjects", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Subjects Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Subjects Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Subjects
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [Name] NCHAR(30) NOT NULL,
                    [YearLevel] NCHAR(30) NOT NULL,
                    [Term] NCHAR(30) NOT NULL,
                    [Prerequisite] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createSchedulesTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Schedules", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Schedules Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Schedules Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Schedules
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [SubjectId] INT NOT NULL,
                    [startTime] NCHAR(30) NOT NULL,
                    [endTime] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }


        public static void createApplicationFormTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Applications", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Applications Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Applications Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Applications
                (
                    [Id] INT NOT NULL IDENTITY(1,1), 
                    [StudentID] INT NOT NULL,
                    [AddressID] INT NOT NULL,
                    [ContactID] INT NOT NULL,
                    [SchoolHistoryID] INT NOT NULL,
                    [GuardianID] INT NOT NULL,
                    [Course] NCHAR(30) NOT NULL,
                    [AdmitType] NCHAR(30) NOT NULL,
                    [YearLevel] NCHAR(30) NOT NULL,
                    [SchoolYear] NCHAR(30) NOT NULL,
                    [Term] NCHAR(30) NOT NULL,
                    [SubmissionDate] DATE NOT NULL,
                    [IsRegular] BIT NOT NULL,
                    [Status] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static void createApplicationSubjectsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ApplicationSubjects", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Application Subjects Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Application Subjects Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE ApplicationSubjects
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [ApplicationID] INT NOT NULL,
                    [SubjectID] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createApplicationSchedulesTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ApplicationSchedules", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Application Schedules Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Application Schedules Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE ApplicationSchedules
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [ApplicationID] INT NOT NULL,
                    [ScheduleID] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createAdressesTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Addresses", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Addresses Table exists! Proceeding...");
            }
            catch(SqlException)
            {
                Console.WriteLine("DEBUG: Addresses Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Addresses
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [StreetUnitNumber] NCHAR(30),
                    [Street] NCHAR(30),
                    [SubdivisionVillageBldg] NCHAR(30),
                    [Barangay] NCHAR(30) NOT NULL,
                    [City] NCHAR(30) NOT NULL,
                    [Province] NCHAR(30) NOT NULL,
                    [ZipCode] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createAdminTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Admins", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Admins Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Admins Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Admins
                (
                    [ID] INT NOT NULL IDENTITY(1,1), 
                    [Username] NCHAR(30) NOT NULL,
                    [Password] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createContactTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Contacts", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Contacts Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Contacts Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Contacts
                (
                    [ID] INT NOT NULL IDENTITY(1,1), 
                    [TelephoneNo] NCHAR(30),
                    [MobileNo] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }
        
        public static void createGuardianTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Guardians", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Guardians Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Guardians Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Guardians
                (
                    [Id] INT NOT NULL IDENTITY(1,1), 
                    [FirstName] NCHAR(30) NOT NULL,
                    [LastName] NCHAR(30) NOT NULL,
                    [MiddleInitial] NCHAR(30),
                    [SuffixName] NCHAR(30),
                    [MobileNumber] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    [Occupation] NCHAR(30) NOT NULL,
                    [Relation] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public static void createSchoolHistoryTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM SchoolHistory", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: SchoolHistory Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: SchoolHistory Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE SchoolHistory
                (
                    [Id] INT NOT NULL IDENTITY(1,1), 
                    [Type] NCHAR(30) NOT NULL,
                    [Name] NCHAR(30) NOT NULL,
                    [ProgramTrackSpecialization] NCHAR(30) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        /**
        * A simple code that will create the Students table.
        * 
        * @return if the table is created successfully.
        * 
        */
        public static void createStudentsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Students Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Students Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Students
                (
                    [Id] INT NOT NULL IDENTITY(1,1), 
                    [FirstName] NCHAR(30) NOT NULL,
                    [MiddleName] NCHAR(30),
                    [LastName] NCHAR(30) NOT NULL,
                    [SuffixName] NCHAR(30),
                    [Gender] NCHAR(30) NOT NULL,
                    [Status] NCHAR(30) NOT NULL,
                    [Citizenship] NCHAR(30) NOT NULL,
                    [BirthDate] DATE NOT NULL,
                    [Birthplace] NCHAR(30) NOT NULL,
                    [Religion] NCHAR(30)  NOT NULL,
                    PRIMARY KEY (ID)
                )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                connection.Close();
            }
        }

        /**
         * A group of methods that will load the database into the
         * program.
         *  
         */

        public static void loadCourses()
        {
            CourseManager courseManager = CourseManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, Name FROM Courses";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Course course = new Course();
                        course.ID = reader.GetInt32(0);
                        course.name = reader.GetString(1);

                        courseManager.add(course);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Course list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadSubjects()
        {
            SubjectManager subjectManager = SubjectManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, Name, YearLevel, Term, Prerequisite FROM Subjects";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Subject subject = new Subject();
                        subject.ID = reader.GetInt32(0);
                        subject.Name = reader.GetString(1);
                        subject.YearLevel = reader.GetString(2);
                        subject.Term = reader.GetString(3);
                        subject.Prerequisite = reader.GetString(4);

                        subjectManager.add(subject);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Course list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadSchedules()
        {
            ScheduleManager scheduleManager = ScheduleManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, SubjectId, startTime, endTime FROM Schedules";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Schedule schedule = new Schedule();
                        schedule.ID = reader.GetInt32(0);
                        schedule.SubjectId = reader.GetInt32(1);
                        schedule.startTime = reader.GetString(2);
                        schedule.endTime = reader.GetString(3);

                        scheduleManager.add(schedule);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Course list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadApplicationForms()
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, Course, AdmitType, YearLevel, 
                SchoolYear, Term, SubmissionDate, Status, IsRegular FROM Applications";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ApplicationForm applicationForm = new ApplicationForm();
                        applicationForm.ID = reader.GetInt32(0);
                        applicationForm.StudentID = reader.GetInt32(1);
                        applicationForm.AddressID = reader.GetInt32(2);
                        applicationForm.ContactID = reader.GetInt32(3);
                        applicationForm.SchoolHistoryID = reader.GetInt32(4);
                        applicationForm.GuardianID = reader.GetInt32(5);
                        applicationForm.Course = reader.GetString(6);
                        applicationForm.AdmitType = reader.GetString(7);
                        applicationForm.YearLevel = reader.GetString(8);
                        applicationForm.SchoolYear = reader.GetString(9);
                        applicationForm.Term = reader.GetString(10);
                        applicationForm.SubmissionDate = reader.GetDateTime(11);
                        applicationForm.Status = reader.GetString(12);
                        applicationForm.IsRegular = reader.GetBoolean(13);

                        applicationFormsManager.addApplicationForm(applicationForm);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Application Form list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load application form list!");
            }
        }
        
        public static void loadApplicationSubjects()
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, ApplicationID, SubjectID FROM ApplicationSubjects";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ApplicationForm application = applicationManager.find(reader.GetInt32(1));
                        if (application == null)
                            return;
                        application.SubjectIDs.Add(reader.GetInt32(2));
                        applicationManager.applicationForms[];
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Course list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadApplicationSchedules()
        {
            ScheduleManager scheduleManager = ScheduleManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, SubjectId, startTime, endTime FROM Schedules";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Schedule schedule = new Schedule();
                        schedule.ID = reader.GetInt32(0);
                        schedule.SubjectId = reader.GetInt32(1);
                        schedule.startTime = reader.GetString(2);
                        schedule.endTime = reader.GetString(3);

                        scheduleManager.add(schedule);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Course list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadAddresses()
        {
            AddressManager addressManager = AddressManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, StreetUnitNumber, Street, SubdivisionVillageBldg, Barangay, City, Province, ZipCode FROM Addresses";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Address address = new Address();

                        address.ID = reader.GetInt32(0);

                        if (!reader.IsDBNull(1))
                            address.StreetUnitNumber = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                            address.Street = reader.GetString(2);

                        if (!reader.IsDBNull(3))
                            address.SubdivisionVillageBldg = reader.GetString(3);
                        address.Barangay = reader.GetString(4);
                        address.City = reader.GetString(5);
                        address.Province = reader.GetString(6);
                        address.ZipCode = reader.GetString(7);

                        addressManager.add(address);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Address list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load address list!");
            }
        }

        public static void loadAdmins()
        {
            AdminManager adminManager = AdminManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, Username, Password FROM Admins";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Admin admin = new Admin();
                        admin.ID = reader.GetInt32(0);
                        admin.username = reader.GetString(1);
                        admin.password = reader.GetString(2);

                        adminManager.add(admin);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Admin list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load admin list!");
            }
        }

        public static void loadContacts()
        {
            ContactManager contactManager = ContactManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, TelephoneNo, MobileNo, Email FROM Contacts";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact();

                        contact.ID = reader.GetInt32(0);
                        if (!reader.IsDBNull(1))
                            contact.TelephoneNo = reader.GetString(1);
                        contact.MobileNo = reader.GetString(2);
                        contact.Email = reader.GetString(3);

                        contactManager.add(contact);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Contact list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load contact list!");
            }
        }

        public static void loadGuardians()
        {
            GuardianManager guardianManager = GuardianManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, FirstName, LastName, MiddleInitial, SuffixName, MobileNumber, Email, Occupation, Relation FROM Guardians";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guardian guardian = new Guardian();
                        guardian.ID = reader.GetInt32(0);
                        guardian.FirstName = reader.GetString(1);
                        guardian.LastName = reader.GetString(2);

                        if (!reader.IsDBNull(3))
                            guardian.MiddleInitial = reader.GetString(3);

                        if (!reader.IsDBNull(4))
                            guardian.SuffixName = reader.GetString(4);
                        guardian.MobileNumber = reader.GetString(5);
                        guardian.Email = reader.GetString(6);
                        guardian.Occupation = reader.GetString(7);
                        guardian.Relation = reader.GetString(8);

                        guardianManager.add(guardian);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: Guardian list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load guardian list!");
            }
        }

        public static void loadSchoolHistory()
        {
            SchoolHistoryManager schoolHistories = SchoolHistoryManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, Type, Name, ProgramTrackSpecialization FROM SchoolHistory";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SchoolHistory schoolHistory = new SchoolHistory();
                        schoolHistory.ID = reader.GetInt32(0);
                        schoolHistory.Type = reader.GetString(1);
                        schoolHistory.Name = reader.GetString(2);
                        schoolHistory.ProgramTrackSpecialization = reader.GetString(3);

                        schoolHistories.add(schoolHistory);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: School History list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load school history list!");
            }
        }

        public static void loadStudents()
        {
            StudentManager studentManager = StudentManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, FirstName, MiddleName, LastName, SuffixName, Gender, Status, Citizenship, BirthDate, Birthplace, Religion  FROM Students";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.ID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        if (!reader.IsDBNull(1))
                            student.MiddleName = reader.GetString(2);
                        student.LastName = reader.GetString(3);
                        if(!reader.IsDBNull(4))
                            student.SuffixName = reader.GetString(4);
                        student.Gender = reader.GetString(5);
                        student.Status = reader.GetString(6);
                        student.Citizenship = reader.GetString(7);
                        student.BirthDate = reader.GetDateTime(8);
                        student.Birthplace = reader.GetString(9);
                        student.Religion = reader.GetString(10);

                        studentManager.add(student);
                    }
                }
                connection.Close();
                Console.WriteLine("DEBUG: School History list loaded.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load school history list!");
            }
        }

        /**
         * A group of method that manages the addition of rows or data
         * in the database.
         * 
         */ 

        public static void addCourse(Course course)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(Name) VALUES(@Name)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", course.name);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addSubject(Subject subject)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Subjects(Name, YearLevel, Term, Prerequisite) VALUES(@Name, @YearLevel, @Term, @Prerequisite)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@Name", subject.YearLevel);
                command.Parameters.AddWithValue("@Name", subject.Term);
                command.Parameters.AddWithValue("@Name", subject.Prerequisite);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void addSchedule(Schedule schedule)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Schedules(SubjectId, startTime, endTime) VALUES(@SubjectId, @startTime, @endTime)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SubjectId", schedule.SubjectId);
                command.Parameters.AddWithValue("@startTime", schedule.startTime);
                command.Parameters.AddWithValue("@endTime", schedule.endTime);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void addAddress(Address address)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Addresses(StreetUnitNumber, Street, SubdivisionVillageBldg, Barangay, City, Province, ZipCode) VALUES(" +
                "@StreetUnitNumber, @Street, @SubdivisionVillageBldg, @Barangay, @City, @Province, @ZipCode)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", address.ID);
                    command.Parameters.AddWithValue("@StreetUnitNumber", address.StreetUnitNumber);
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@SubdivisionVillageBldg", address.SubdivisionVillageBldg);
                    command.Parameters.AddWithValue("@Barangay", address.Barangay);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@Province", address.Province);
                    command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addAdmin(Admin admin)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Admins(username, password) VALUES(@username, @password)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", admin.username);
                    command.Parameters.AddWithValue("@password", admin.password);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addApplicationForm(ApplicationForm applicationform)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Applications(StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, Course, AdmitType, YearLevel, SchoolYear," +
                " Term, SubmissionDate, Status, IsRegular) VALUES(@StudentID, @AddressID, @ContactID, @SchoolHistoryID, @GuardianID, @Course, @AdmitType, @YearLevel, " +
                "@SchoolYear, @Term, @SubmissionDate, @Status, @IsRegular)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", applicationform.StudentID);
                    command.Parameters.AddWithValue("@AddressID", applicationform.AddressID);
                    command.Parameters.AddWithValue("@ContactID", applicationform.ContactID);
                    command.Parameters.AddWithValue("@SchoolHistoryID", applicationform.SchoolHistoryID);
                    command.Parameters.AddWithValue("@GuardianID", applicationform.GuardianID);
                    command.Parameters.AddWithValue("@Course", applicationform.Course);
                    command.Parameters.AddWithValue("@AdmitType", applicationform.AdmitType);
                    command.Parameters.AddWithValue("@YearLevel", applicationform.YearLevel);
                    command.Parameters.AddWithValue("@SchoolYear", applicationform.SchoolYear);
                    command.Parameters.AddWithValue("@Term", applicationform.Term);
                    command.Parameters.AddWithValue("@SubmissionDate", applicationform.SubmissionDate);
                    command.Parameters.AddWithValue("@Status", applicationform.Status);
                    command.Parameters.AddWithValue("@IsRegular", applicationform.IsRegular);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addContact(Contact contact)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Contacts(TelephoneNo, MobileNo, Email) VALUES(@TelephoneNo, @MobileNo, @Email)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TelephoneNo", contact.TelephoneNo);
                    command.Parameters.AddWithValue("@MobileNo", contact.MobileNo);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addGuardian(Guardian guardian)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Guardians(FirstName, LastName, MiddleInitial, SuffixName, MobileNumber, Email, Occupation, Relation) " +
                "VALUES(@FirstName, @LastName, @MiddleInitial, @SuffixName, @MobileNumber, @Email, @Occupation, @Relation)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", guardian.FirstName);
                    command.Parameters.AddWithValue("@LastName", guardian.LastName);
                    command.Parameters.AddWithValue("@MiddleInitial", guardian.MiddleInitial);
                    command.Parameters.AddWithValue("@SuffixName", guardian.SuffixName);
                    command.Parameters.AddWithValue("@MobileNumber", guardian.MobileNumber);
                    command.Parameters.AddWithValue("@Email", guardian.Email);
                    command.Parameters.AddWithValue("@Occupation", guardian.Occupation);
                    command.Parameters.AddWithValue("@Relation", guardian.Relation);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addSchoolHistory(SchoolHistory schoolhistory)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO SchoolHistory(Type, Name, ProgramTrackSpecialization) VALUES(@Type, @Name, @ProgramTrackSpecialization)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", schoolhistory.Type);
                    command.Parameters.AddWithValue("@Name", schoolhistory.Name);
                    command.Parameters.AddWithValue("@ProgramTrackSpecialization", schoolhistory.ProgramTrackSpecialization);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }


        public static void addStudent(Student student)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Students(FirstName, MiddleName, LastName, Gender, Status, Citizenship, BirthDate, Birthplace, Religion) " +
                "VALUES(@FirstName, @MiddleName, @LastName, @Gender, @Status, @Citizenship, @BirthDate, @Birthplace, @Religion)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", student.MiddleName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Gender", student.Gender);
                    command.Parameters.AddWithValue("@Status", student.Status);
                    command.Parameters.AddWithValue("@Citizenship", student.Citizenship);
                    command.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                    command.Parameters.AddWithValue("@Birthplace", student.Birthplace);
                    command.Parameters.AddWithValue("@Religion", student.Religion);

                    command.ExecuteNonQuery();
                }
                connection.Close();
        }
    }
}
