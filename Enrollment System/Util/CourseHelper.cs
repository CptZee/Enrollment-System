using System;
using Enrollment_System.Data;
using System.Data.SqlClient;

namespace Enrollment_System.Util
{
    class CourseHelper
    {
        public static void createCoursesTable()
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
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
                    [Name] NCHAR(255) NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadCourses()
        {
            CourseManager courseManager = CourseManager.getInstance();
            courseManager.clear();
            SqlConnection connection = DatabaseHelper.getSystemConnection();
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


        public static void addCourse(Course course)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "INSERT INTO Courses(Name) VALUES(@Name)";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", course.Name);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void removeCourse(Course course)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "DELETE FROM Courses WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", course.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateCourses(Course course)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
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

        public static int getRecentCourseID()
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = @"SELECT IDENT_CURRENT ('Courses')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
