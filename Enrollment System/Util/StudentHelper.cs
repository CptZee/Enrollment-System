using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class StudentHelper
    {
        public static void createStudentsTable()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadStudents()
        {
            StudentManager studentManager = StudentManager.getInstance();
            studentManager.clear();
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
                        if (!reader.IsDBNull(5))
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
        
        public static void addStudent(Student student)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
        
        public static void removeStudent(Student student)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Students WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", student.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        
        public static void removeStudent(int ID)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "DELETE FROM Students WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateStudent(Student student)
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = "UPDATE Students SET ApplicationID = @ApplicationID, FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, " +
                "Gender = @Gender, Status = @Status, Citizenship = @Citizenship, BirthDate = @BirthDate, Birthplace = @Birthplace, " +
                "Religion = @Religion WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", student.ID);
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

        public static int getRecentScheduleID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
            String query = @"SELECT IDENT_CURRENT ('Applications')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }

        public static int getRecentStudentID()
        {
            SqlConnection connection = DatabaseHelper.getApplicationConnection();
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
