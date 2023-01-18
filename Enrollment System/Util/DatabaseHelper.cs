using System;
using Enrollment_System.Data;
using System.Data.SqlClient;
using System.Data;

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
        protected static String applicationsURL = @"Data Source=AARON\SQLEXPRESS;Initial Catalog=Applications;Integrated Security=True";
        protected static String systemURL = @"Data Source=AARON\SQLEXPRESS;Initial Catalog=System;Integrated Security=True";

        /*
         * A simple method which returns the connection.
         * 
        **/
        protected static SqlConnection getApplicationConnection()
        {
            SqlConnection connection = new SqlConnection(applicationsURL);
            return connection;
        }
        protected static SqlConnection getSystemConnection()
        {
            SqlConnection connection = new SqlConnection(systemURL);
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
                    [Name] NCHAR(255) NOT NULL,
                    [YearLevel] NCHAR(30) NOT NULL,
                    [Term] NCHAR(30) NOT NULL,
                    [Prerequisite] NCHAR(30) NOT NULL,
                    [Units] INT NOT NULL,
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
                    [SubjectID] INT NOT NULL,
                    [StartTime] NCHAR(30) NOT NULL,
                    [EndTime] NCHAR(30) NOT NULL,
                    [Day] NCHAR(30) NOT NULL,
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
                    [SubjectID] INT NOT NULL,
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
                    [SubjectID] INT NOT NULL,
                    [Schedule] NCHAR(30) NOT NULL,
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

        public static void createApplicationRequirementsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ApplicationRequirements", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Application Requirements Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Application Requirements Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE ApplicationRequirements
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [ApplicationID] INT NOT NULL,
                    [RequirementID] INT NOT NULL,
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

        public static void createRequirementsTable()
        {
            SqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Requirements", connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DEBUG: Requirements Table exists! Proceeding...");
            }
            catch (SqlException)
            {
                Console.WriteLine("DEBUG: Requirements Table doesn't exist! Creating one...");
                String query = @"CREATE TABLE Requirements
                (
                    [ID] INT NOT NULL IDENTITY(1,1),
                    [PicturePath] NCHAR(255) NOT NULL,
                    [PSAPath] NCHAR(255) NOT NULL,
                    [GoodMoralPath] NCHAR(255) NOT NULL,
                    [RecommendationPath] NCHAR(255) NOT NULL,
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
                    [ID] INT NOT NULL IDENTITY(1,1), 
                    [ApplicationID] INT NOT NULL, 
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
         * A group of methods that will load the database and
         * store them as DataSets
         */
        public static DataSet getCourses()
        {

            String select = "SELECT * FROM Courses";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getSubjects()
        {

            String select = "SELECT * FROM Subjects";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getSchedules()
        {

            String select = "SELECT * FROM Schedules";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet getApplications()
        {

            String select = "SELECT * FROM Applications";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        /**
         * A group of methods that will load the database into the
         * program.
         *  
         */

        public static void loadCourses()
        {
            CourseManager courseManager = CourseManager.getInstance();
            courseManager.clear();
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
                        course.Name = reader.GetString(1).Trim();

                        courseManager.add(course);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadSubjects()
        {
            SubjectManager subjectManager = SubjectManager.getInstance();
            subjectManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, Name, YearLevel, Term, Prerequisite, Units FROM Subjects";
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
                        subject.Name = reader.GetString(1).Trim();
                        subject.YearLevel = reader.GetString(2).Trim();
                        subject.Term = reader.GetString(3).Trim();
                        subject.Prerequisite = reader.GetString(4).Trim();
                        subject.Units = reader.GetInt32(5);

                        subjectManager.add(subject);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load subject list!");
            }
        }

        public static void loadSchedules()
        {
            ScheduleManager scheduleManager = ScheduleManager.getInstance();
            scheduleManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, SubjectID, StartTime, EndTime, Day FROM Schedules";
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
                        schedule.SubjectID = reader.GetInt32(1);
                        schedule.StartTime = reader.GetString(2).Trim();
                        schedule.EndTime = reader.GetString(3).Trim();
                        schedule.Day = reader.GetString(4).Trim();

                        scheduleManager.add(schedule);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load schedule list!");
            }
        }

        public static void loadApplicationForms()
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            applicationFormsManager.clear();
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
                        applicationForm.Course = reader.GetString(6).Trim();
                        applicationForm.AdmitType = reader.GetString(7).Trim();
                        applicationForm.YearLevel = reader.GetString(8).Trim();
                        applicationForm.SchoolYear = reader.GetString(9).Trim();
                        applicationForm.Term = reader.GetString(10).Trim();
                        applicationForm.SubmissionDate = reader.GetDateTime(11);
                        applicationForm.Status = reader.GetString(12).Trim();
                        applicationForm.IsRegular = reader.GetBoolean(13);

                        applicationFormsManager.add(applicationForm);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load application form list!");
            }
        }
        
        /**
         * WARNING: loadApplications() must be called before this!
         */ 
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
                        applicationManager.update(application);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }
        
        /**
         * WARNING: loadApplications() must be called before this!
         */
        public static void loadApplicationSchedules()
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, ApplicationID, SubjectID FROM ApplicationSchedules";
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
                        application.ScheduleIDs.Add(reader.GetInt32(2));
                        applicationManager.update(application);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load application schedule list!");
            }
        }

        /**
         * WARNING: loadApplications() must be called before this!
         */
        public static void loadApplicationRequirements()
        {
            ApplicationFormsManager applicationManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, ApplicationID, RequirementID FROM ApplicationRequirements";
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
                        application.RequirementID = reader.GetInt32(2);
                        applicationManager.update(application);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load course list!");
            }
        }

        public static void loadRequirements()
        {
            RequirementManager requirementManager = RequirementManager.getInstance();
            requirementManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, PicturePath, PSAPath, GoodMoralPath, RecommendationPath FROM Requirements";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Requirement requirement = new Requirement();

                        requirement.ID = reader.GetInt32(0);

                        if (!reader.IsDBNull(1))
                            requirement.PicturePath = reader.GetString(1).Trim();

                        if (!reader.IsDBNull(2))
                            requirement.PSAPath = reader.GetString(2);

                        if (!reader.IsDBNull(3))
                            requirement.GoodMoralPath = reader.GetString(3).Trim();

                        if (!reader.IsDBNull(4))
                            requirement.RecommendationPath = reader.GetString(3).Trim();

                        requirementManager.add(requirement);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load requirement list!");
            }
        }

        public static void loadAddresses()
        {
            AddressManager addressManager = AddressManager.getInstance();
            addressManager.clear();
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
                            address.StreetUnitNumber = reader.GetString(1).Trim();

                        if (!reader.IsDBNull(2))
                            address.Street = reader.GetString(2);

                        if (!reader.IsDBNull(3))
                            address.SubdivisionVillageBldg = reader.GetString(3).Trim();
                        address.Barangay = reader.GetString(4).Trim();
                        address.City = reader.GetString(5).Trim();
                        address.Province = reader.GetString(6).Trim();
                        address.ZipCode = reader.GetString(7).Trim();

                        addressManager.add(address);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load address list!");
            }
        }

        public static void loadAdmins()
        {
            AdminManager adminManager = AdminManager.getInstance();
            adminManager.clear();
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
                        admin.Username = reader.GetString(1).Trim();
                        admin.Password = reader.GetString(2).Trim();

                        adminManager.add(admin);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load admin list!");
            }
        }

        public static void loadContacts()
        {
            ContactManager contactManager = ContactManager.getInstance();
            contactManager.clear();
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
                            contact.TelephoneNo = reader.GetString(1).Trim();
                        contact.MobileNo = reader.GetString(2).Trim();
                        contact.Email = reader.GetString(3).Trim();

                        contactManager.add(contact);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load contact list!");
            }
        }

        public static void loadGuardians()
        {
            GuardianManager guardianManager = GuardianManager.getInstance();
            guardianManager.clear();
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
                        guardian.FirstName = reader.GetString(1).Trim();
                        guardian.LastName = reader.GetString(2).Trim();

                        if (!reader.IsDBNull(3))
                            guardian.MiddleInitial = reader.GetString(3).Trim();

                        if (!reader.IsDBNull(4))
                            guardian.SuffixName = reader.GetString(4).Trim();
                        guardian.MobileNumber = reader.GetString(5).Trim();
                        guardian.Email = reader.GetString(6).Trim();
                        guardian.Occupation = reader.GetString(7).Trim();
                        guardian.Relation = reader.GetString(8).Trim();

                        guardianManager.add(guardian);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load guardian list!");
            }
        }

        public static void loadSchoolHistory()
        {
            SchoolHistoryManager schoolHistories = SchoolHistoryManager.getInstance();
            schoolHistories.clear();
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
                        schoolHistory.Type = reader.GetString(1).Trim();
                        schoolHistory.Name = reader.GetString(2).Trim();
                        schoolHistory.ProgramTrackSpecialization = reader.GetString(3).Trim();

                        schoolHistories.add(schoolHistory);
                    }
                }
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to load school history list!");
            }
        }

        public static void loadStudents()
        {
            StudentManager studentManager = StudentManager.getInstance();
            studentManager.clear();
            SqlConnection connection = GetConnection();
            String query = @"SELECT ID, ApplicationID, FirstName, MiddleName, LastName, SuffixName, Gender, Status, Citizenship, BirthDate, Birthplace, Religion  FROM Students";
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
                        student.ApplicationID = reader.GetInt32(1);
                        student.FirstName = reader.GetString(2).Trim();
                        if (!reader.IsDBNull(1))
                            student.MiddleName = reader.GetString(3).Trim();
                        student.LastName = reader.GetString(4).Trim();
                        if(!reader.IsDBNull(5))
                            student.SuffixName = reader.GetString(5).Trim();
                        student.Gender = reader.GetString(6).Trim();
                        student.Status = reader.GetString(7).Trim();
                        student.Citizenship = reader.GetString(8).Trim();
                        student.BirthDate = reader.GetDateTime(9);
                        student.Birthplace = reader.GetString(10).Trim();
                        student.Religion = reader.GetString(11).Trim();

                        studentManager.add(student);
                    }
                }
                connection.Close();
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
                    command.Parameters.AddWithValue("@Name", course.Name);
                    command.ExecuteNonQuery();
                }
                connection.Close();
        }

        public static void addSubject(Subject subject)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Subjects(Name, YearLevel, Term, Prerequisite, Units) VALUES(@Name, @YearLevel, @Term, @Prerequisite, @Units)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@YearLevel", subject.YearLevel);
                command.Parameters.AddWithValue("@Term", subject.Term);
                command.Parameters.AddWithValue("@Prerequisite", subject.Prerequisite);
                command.Parameters.AddWithValue("@Units", subject.Units);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void addSchedule(Schedule schedule)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Schedules(SubjectID, StartTime, EndTime, Day) VALUES(@SubjectID, @StartTime, @EndTime, @Day)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SubjectID", schedule.SubjectID);
                command.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                command.Parameters.AddWithValue("@EndTime", schedule.EndTime);
                command.Parameters.AddWithValue("@Day", schedule.Day);
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

        public static void addApplicationSubject(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            connection.Open();
            for (int i = 0; i < application.SubjectIDs.Count; i++)
            {
                String query = "INSERT INTO ApplicationSubjects(ApplicationID, SubjectID) VALUES(@ApplicationID, @SubjectID)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@SubjectID", application.SubjectIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void addApplicationSchedule(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO ApplicationSchedules(ApplicationID, ScheduleID) VALUES(@ApplicationID, @ScheduleID)";
            connection.Open();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@ScheduleID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void addApplicationRequirements(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO ApplicationRequirements(ApplicationID, RequirementID) VALUES(@ApplicationID, @RequirementID)";
            connection.Open();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@RequirementID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void addRequirement(Requirement requirement)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Requirements(PicturePath, PSAPath, GoodMoralPath, RecommendationPath) VALUES(@PicturePath, " +
                "@PSAPath, @GoodMoralPath, @RecommendationPath)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PicturePath", requirement.PicturePath);
                command.Parameters.AddWithValue("@PSAPath", requirement.PSAPath);
                command.Parameters.AddWithValue("@GoodMoralPath", requirement.GoodMoralPath);
                command.Parameters.AddWithValue("@RecommendationPath", requirement.RecommendationPath);
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
                    command.Parameters.AddWithValue("@username", admin.Username);
                    command.Parameters.AddWithValue("@password", admin.Password);
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
            String query = "INSERT INTO Students(ApplicationID, FirstName, MiddleName, LastName, Gender, Status, Citizenship, BirthDate, Birthplace, Religion) " +
                "VALUES(@ApplicationID, @FirstName, @MiddleName, @LastName, @Gender, @Status, @Citizenship, @BirthDate, @Birthplace, @Religion)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", student.ApplicationID);
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

        /**
         * A group of method that manages the addition of rows or data
         * in the database.
         * 
         */
        public static void removeCourse(Course course)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Courses WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", course.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
        public static void removeSubject(Subject subject)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Subjects WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", subject.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeSchedule(Schedule schedule)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Schedules WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schedule.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeApplication(ApplicationForm applicationForm)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Applications WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", applicationForm.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        //TODO: Add a function to remove subjects, schedules, and requirements from the application.

        public static void removeRequirement(Requirement requirement)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Requirement WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", requirement.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAddress(Address address)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Addresses WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", address.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAdmin(Admin admin)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Admins WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", admin.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeContact(Contact contact)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Contacts WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", contact.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeGuardian(Guardian guardian)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Guardians WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", guardian.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeSchoolHistory(SchoolHistory schoolHistory)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM SchoolHistory WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schoolHistory.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeStudent(Student student)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Students WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", student.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        //Same stuff but with IDs
        public static void removeRequirement(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Requirement WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAddress(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Addresses WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeAdmin(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Admins WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeContact(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Contacts WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeGuardian(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Guardians WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeSchoolHistory(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM SchoolHistory WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeStudent(int ID)
        {
            SqlConnection connection = GetConnection();
            String query = "DELETE FROM Students WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        /**
         * A group of method that manages the update of rows or data
         * in the database.
         */
        public static void updateCourses(Course course)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Courses SET Name = @Name WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", course.ID);
                command.Parameters.AddWithValue("@Name", course.Name);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateSubject(Subject subject)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Subjects SET Name = @Name, YearLevel = @YearLevel, Term = @Term, Prerequisite = Prerequisite, Units = Units WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", subject.ID);
                command.Parameters.AddWithValue("@Name", subject.Name);
                command.Parameters.AddWithValue("@YearLevel", subject.YearLevel);
                command.Parameters.AddWithValue("@Term", subject.Term);
                command.Parameters.AddWithValue("@Prerequisite", subject.Prerequisite);
                command.Parameters.AddWithValue("@Units", subject.Units);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateSchedule(Schedule schedule)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Schedules SET SubjectID = @SubjectID, StartTime = @StartTime, EndTime = @EndTime, Day = @Day WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schedule.ID);
                command.Parameters.AddWithValue("@SubjectID", schedule.SubjectID);
                command.Parameters.AddWithValue("@StartTime", schedule.StartTime);
                command.Parameters.AddWithValue("@EndTime", schedule.EndTime);
                command.Parameters.AddWithValue("@Day", schedule.Day);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateApplicationForm(ApplicationForm applicationform)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Applications SET StudentID = @StudentID, AddressID = @AddressID, ContactID = @ContactID, SchoolHistoryID = @SchoolHistoryID" +
                ", GuardianID = @GuardianID, Course = @Course, AdmitType = @AdmitType, YearLevel = @YearLevel, SchoolYear = @SchoolYear," +
                " Term = @Term, SubmissionDate = @SubmissionDate, Status = @Status, IsRegular = @IsRegular WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", applicationform.ID);
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

        public static void updateApplicationSubject(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            for (int i = 0; i < application.SubjectIDs.Count; i++)
            {
                String query = "UPDATE ApplicationSubjects SET ApplicationID = @ApplicationID, SubjectID = @SubjectID WHERE ID = @ID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", application.ID);
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@SubjectID", application.SubjectIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void updateApplicationSchedule(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                String query = "UPDATE ApplicationSchedules SET ApplicationID = @ApplicationID, ScheduleID = @ScheduleID WHERE ID = @ID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", application.ID);
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@ScheduleID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void updateApplicationRequirements(ApplicationForm application)
        {
            SqlConnection connection = GetConnection();
            for (int i = 0; i < application.ScheduleIDs.Count; i++)
            {
                String query = "UPDATE ApplicationRequirements SET ApplicationID = @ApplicationID, RequirementID = @RequirementID WHERE ID = @ID";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", application.ID);
                    command.Parameters.AddWithValue("@ApplicationID", application.ID);
                    command.Parameters.AddWithValue("@RequirementID", application.ScheduleIDs[i]);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }

        public static void updateRequirement(Requirement requirement)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Requirements SET PicturePath = @PicturePath, PSAPath = @PSAPath, GoodMoralPath = @GoodMoralPath, " +
                "RecommendationPath = @RecommendationPath WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", requirement.ID);
                command.Parameters.AddWithValue("@PicturePath", requirement.PicturePath);
                command.Parameters.AddWithValue("@PSAPath", requirement.PSAPath);
                command.Parameters.AddWithValue("@GoodMoralPath", requirement.GoodMoralPath);
                command.Parameters.AddWithValue("@RecommendationPath", requirement.RecommendationPath);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateAddress(Address address)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Addresses SET StreetUnitNumber = @StreetUnitNumber, Street = @Street, SubdivisionVillageBldg = @SubdivisionVillageBldg" +
                ", Barangay = @Barangay, City = @City, Province = @Province, ZipCode = @ZipCode WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", address.ID);
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

        public static void updateAdmin(Admin admin)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Admins SET username = @username, password = @password WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", admin.ID);
                command.Parameters.AddWithValue("@username", admin.Username);
                command.Parameters.AddWithValue("@password", admin.Password);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateContact(Contact contact)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Contacts SET TelephoneNo = @TelephoneNo, MobileNo = @MobileNo, Email = @Email WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", contact.ID);
                command.Parameters.AddWithValue("@TelephoneNo", contact.TelephoneNo);
                command.Parameters.AddWithValue("@MobileNo", contact.MobileNo);
                command.Parameters.AddWithValue("@Email", contact.Email);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateGuardian(Guardian guardian)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Guardians SET FirstName = @FirstName, LastName = @LastName, MiddleInitial = @MiddleInitial, " +
                "SuffixName = @SuffixName, MobileNumber = @MobileNumber, Email = @Email, Occupation = @Occupation, " +
                "Relation = @Relation WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", guardian.ID);
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

        public static void updateSchoolHistory(SchoolHistory schoolhistory)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE SchoolHistory SET Type = @Type, Name = @Name, ProgramTrackSpecialization = @ProgramTrackSpecialization WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", schoolhistory.ID);
                command.Parameters.AddWithValue("@Type", schoolhistory.Type);
                command.Parameters.AddWithValue("@Name", schoolhistory.Name);
                command.Parameters.AddWithValue("@ProgramTrackSpecialization", schoolhistory.ProgramTrackSpecialization);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }


        public static void updateStudent(Student student)
        {
            SqlConnection connection = GetConnection();
            String query = "UPDATE Students SET ApplicationID = @ApplicationID, FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                "Gender = @Gender, Status = @Status, Citizenship = @Citizenship, BirthDate = @BirthDate, Birthplace = @Birthplace, " +
                "Religion = @Religion WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", student.ID);
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

        /**
         * A group of method that manages the return of recent id of a data
         * in the database.
         */
        public static int getRecentCourseID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Courses')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentSubjectID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Subjects')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentScheduleID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Schedules')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentApplicationID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Applications')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentAdminID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Admins')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentAddressID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Addresses')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentContactID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Contacts')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentGuardianID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Guardians')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentRequirementID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Requirements')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentSchedulesID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Schedules')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentSchoolHistoryID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('SchoolHistory')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentStudentID()
        {
            SqlConnection connection = GetConnection();
            String query = @"SELECT IDENT_CURRENT ('Students')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
