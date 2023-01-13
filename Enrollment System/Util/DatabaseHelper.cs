using System;
using Enrollment_System.Data;
using System.Data.SqlClient;
using Enrollment_System.Data;

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
        protected static String connectionString = @"Data Source=AARON\SQLEXPRESS;Integrated Security=True";

        /*
         * A simple method which returns the connection.
         * 
        **/
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [Name] NCHAR(30) NOT NULL
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
         * A simple code that will create the Addresses table.
         * 
         * @return if the table is created successfully.
         * 
         */
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
                    [Id] INT NOT NULL PRIMARY KEY,
                    [StreetUnitNumber] NCHAR(30),
                    [Street] NCHAR(30) NOT NULL,
                    [SubdivisionVillageBldg] NCHAR(30) NOT NULL,
                    [Barangay] NCHAR(30) NOT NULL,
                    [City] NCHAR(30) NOT NULL,
                    [Province] NCHAR(30) NOT NULL,
                    [ZipCode] NCHAR(30) NOT NULL
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
         * A simple code that will create the admins table.
         * 
         * @return if the table is created successfully.
         * 
         */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [Username] NCHAR(30) NOT NULL,
                    [Password] NCHAR(30) NOT NULL
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
        * A simple code that will create the Contacts table.
        * 
        * @return if the table is created successfully.
        * 
        */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [TelephoneNo] NCHAR(30) NOT NULL,
                    [MobileNo] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL
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
        * A simple code that will create the Guardians table.
        * 
        * @return if the table is created successfully.
        * 
        */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [FirstName] NCHAR(30) NOT NULL,
                    [LastName] NCHAR(30) NOT NULL,
                    [MiddleInitial] NCHAR(30) NOT NULL,
                    [SuffixName] NCHAR(30) NOT NULL,
                    [MobileNumber] NCHAR(30) NOT NULL,
                    [Email] NCHAR(30) NOT NULL,
                    [Occupation] NCHAR(30) NOT NULL,
                    [Relation] NCHAR(30) NOT NULL
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
        * A simple code that will create the School History table.
        * 
        * @return if the table is created successfully.
        * 
        */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [Type] NCHAR(30) NOT NULL,
                    [Name] NCHAR(30) NOT NULL,
                    [ProgramTrackSpecialization] NCHAR(30) NOT NULL
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
                    [Id] INT NOT NULL PRIMARY KEY, 
                    [FirstName] NCHAR(30) NOT NULL,
                    [MiddleName] NCHAR(30) NOT NULL,
                    [LastName] NCHAR(30) NOT NULL,
                    [SuffixName] NCHAR(30) NOT NULL,
                    [Gender] NCHAR(30) NOT NULL,
                    [Status] NCHAR(30) NOT NULL,
                    [Citizenship] NCHAR(30) NOT NULL,
                    [BirthDate] DATE NOT NULL,
                    [Birthplace] NCHAR(30) NOT NULL,
                    [Religion] NCHAR(30)  NOT NULL
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
         * A simple code that will create the Application Forms table.
         * 
         * @return if the table is created successfully.
         * 
         */
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
                    [Id] INT NOT NULL PRIMARY KEY, 
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
                    [Status] NCHAR(30) NOT NULL 
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
        public static void loadAddresses()
        {
            AddressManager addressManager = AddressManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT Id, StreetUnitNumber, Street, SubdivisionVillageBldg, Barangay, City, Province, ZipCode FROM Addresses";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Address address = new Address();

                        address.Id = reader.GetInt32(0);
                        address.StreetUnitNumber = reader.GetString(1);
                        address.Street = reader.GetString(2);
                        address.SubdivisionVillageBldg = reader.GetString(3);
                        address.Barangay = reader.GetString(4);
                        address.City = reader.GetString(5);
                        address.Province = reader.GetString(6);
                        address.ZipCode = reader.GetString(7);

                        addressManager.addAddress(address);
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
            String query = @"SELECT Id, Username, Password FROM Admins";
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

                        adminManager.addAdmin(admin);
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
            String query = @"SELECT Id, TelephoneNo, MobileNo, Email FROM Contacts";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact contact = new Contact();

                        contact.Id = reader.GetInt32(0);
                        contact.TelephoneNo = reader.GetString(1);
                        contact.MobileNo = reader.GetString(2);
                        contact.Email = reader.GetString(3);

                        contactManager.addContact(contact);
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

        public static void loadCourses()
        {
            CourseManager courseManager = CourseManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT Id, Name FROM Courses";
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

                        courseManager.addCourses(course);
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

        public static void loadGuardians()
        {
            GuardianManager guardianManager = GuardianManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT Id, FirstName, LastName, MiddleInitial, SuffixName, MobileNumber, Email, Occupation, Relation FROM Guardians";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guardian guardian = new Guardian();
                        guardian.Id = reader.GetInt32(0);
                        guardian.FirstName = reader.GetString(1);
                        guardian.LastName = reader.GetString(2);
                        guardian.MiddleInitial = reader.GetString(3);
                        guardian.SuffixName = reader.GetString(4);
                        guardian.MobileNumber = reader.GetString(5);
                        guardian.Email = reader.GetString(6);
                        guardian.Occupation = reader.GetString(7);
                        guardian.Relation = reader.GetString(8);

                        guardianManager.addGuardian(guardian);
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
            String query = @"SELECT Id, Type, Name, ProgramTrackSpecialization FROM SchoolHistory";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SchoolHistory schoolHistory = new SchoolHistory();
                        schoolHistory.Id = reader.GetInt32(0);
                        schoolHistory.Type = reader.GetString(1);
                        schoolHistory.Name = reader.GetString(2);
                        schoolHistory.ProgramTrackSpecialization = reader.GetString(3);

                        schoolHistories.addSchoolHistory(schoolHistory);
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
            String query = @"SELECT Id, FirstName, MiddleName, LastName, SuffixName, Gender, Status, Citizenship, BirthDate, Birthplace, Religion  FROM Students";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student();
                        student.Id = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.MiddleName = reader.GetString(2);
                        student.LastName = reader.GetString(3);
                        student.SuffixName = reader.GetString(4);
                        student.Gender = reader.GetString(5);
                        student.Status = reader.GetString(6);
                        student.Citizenship = reader.GetString(7);
                        student.BirthDate = reader.GetDateTime(8);
                        student.Birthplace = reader.GetString(9);
                        student.Religion = reader.GetString(10);

                        studentManager.addStudent(student);
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

        public static void loadApplicationForms()
        {
            ApplicationFormsManager applicationFormsManager = ApplicationFormsManager.getInstance();
            SqlConnection connection = GetConnection();
            String query = @"SELECT Id, StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, Course, AdmitType, YearLevel, SchoolYear, Term, SubmissionDate, Status FROM Applications";
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

        /**
         * A group of method that manages the addition of rows or data
         * in the database.
         * 
         */ 

        public static void addCourse(Course course)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(Id, Name) VALUES(@Id, @Name)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", course.ID);
                    command.Parameters.AddWithValue("@Name", course.name);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("ERROR: Successfully added course with the id " + course.ID);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + course.ID);
            }
        }

        public static void addAddress(Address address)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Adresses(Id, StreetUnitNumber, Street, SubdivisionVillageBldg, Barangay, City, Province, ZipCode) VALUES(@Id, @StreetUnitNumber, @Street, @SubdivisionVillageBldg, @Barangay, @City, @Province, @ZipCode)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", address.Id);
                    command.Parameters.AddWithValue("@StreetUnitNumber", address.StreetUnitNumber);
                    command.Parameters.AddWithValue("@Street", address.Street);
                    command.Parameters.AddWithValue("@SubdivisionVillageBldg", address.SubdivisionVillageBldg);
                    command.Parameters.AddWithValue("@Barangay", address.Barangay);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@Province", address.Province);
                    command.Parameters.AddWithValue("@ZipCode", address.ZipCode);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("ERROR: Successfully added course with the id " + address.Id);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + address.Id);
            }
        }

        public static void addAdmin(Admin admin)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(ID, username, password) VALUES(@ID, @username, @password)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", admin.ID);
                    command.Parameters.AddWithValue("@username", admin.username);
                    command.Parameters.AddWithValue("@password", admin.password);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("ERROR: Successfully added course with the id " + admin.ID);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + admin.ID);
            }
        }

        public static void addApplicationForm(ApplicationForm applicationform)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(ID, StudentID, AddressID, ContactID, SchoolHistoryID, GuardianID, Course, AdmitType, YearLevel, SchoolYear, Term, SubmissionDate, Status) VALUES(@ID, @StudentID, @AddressID, @ContactID, @SchoolHistoryID, @GuardianID, @Course, @AdmitType, @YearLevel, @SchoolYear, @Term, @SubmissionDate, @Status)";
            try
            {
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
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("ERROR: Successfully added course with the id " + applicationform.ID);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + applicationform.ID);
            }
        }

        public static void addContact(Contact contact)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(Id, TelephoneNo, MobileNo, Email) VALUES(@Id, @TelephoneNo, @MobileNo, @Email)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", contact.Id);
                    command.Parameters.AddWithValue("@TelephoneNo", contact.TelephoneNo);
                    command.Parameters.AddWithValue("@MobileNo", contact.MobileNo);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("ERROR: Successfully added course with the id " + contact.Id);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + contact.Id);
            }
        }

        public static void addGuardian(Guardian guardian)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(Id, FirstName, LastName, MiddleInitial, SuffixName, MobileNumber, Email, Occupation, Relation) VALUES(@Id, @FirstName, @LastName, @MiddleInitial, @SuffixName, @MobileNumber, @Email, @Occupation, @Relation)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", guardian.Id);
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
                Console.WriteLine("ERROR: Successfully added course with the id " + guardian.Id);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + guardian.Id);
            }
        }

        public static void addSchoolHistory(SchoolHistory schoolhistory)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(Id, Type, Name, ProgramTrackSpecialization) VALUES(@Id, @Type, @Name, @ProgramTrackSpecialization)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", schoolhistory.Id);
                    command.Parameters.AddWithValue("@Type", schoolhistory.Type);
                    command.Parameters.AddWithValue("@Name", schoolhistory.Name);
                    command.Parameters.AddWithValue("@ProgramTrackSpecialization", schoolhistory.ProgramTrackSpecialization);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("ERROR: Successfully added course with the id " + schoolhistory.Id);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + schoolhistory.Id);
            }
        }


        public static void addStudent(Student student)
        {
            SqlConnection connection = GetConnection();
            String query = "INSERT INTO Courses(Id, FirstName, MiddleName, LastName, Gender, Status, Citizenship, BirthDate, Birthplace, Religion) VALUES(@Id, @FirstName, @MiddleName, @LastName, @Gender, @Status, @Citizenship, @BirthDate, @Birthplace, @Religion)";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", student.Id);
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
                Console.WriteLine("ERROR: Successfully added course with the id " + student.Id);
                connection.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add course with the id " + student .Id);
            }
        }


        /**
        * A simple code that will add a user to the database
        * NOTE: DO NOT RUN ON THE MAIN THREAD!
        * 
        */
        /*
        public static void addUser(Student user)
        {
            UserManager userManager = UserManager.Instance;
            SqlConnection connection = GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "INSERT INTO Users * VALUES(" + user.Id + ",'" + user.FName + "','" + user.MName + "','" + user.LName + "'," +
                user.Age + ",'" + user.Gender + "','" + user.Municipality + "','" + user.City + "','" + user.PostalCode + "','" + user.ContactNumber + "','" + 
                user.Email + "','" + user.StudNo + "','" + user.Program + "','" + user.YearLvl + "','" + user.Semester + "'," + user.isRegular + ")";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                adapter.InsertCommand = new SqlCommand(query, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                userManager.addUser(user);
                Console.WriteLine("DEBUG: User " + user.Id + " added to the database.");
            }
            catch (SqlException)
            {
                Console.WriteLine("ERROR: Unable to add user with the id " + user.Id);
            }
        }
            */
    }
}
