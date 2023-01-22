using System;
using Enrollment_System.Data;
using System.Data.SqlClient;


namespace Enrollment_System.Util
{
    class SubjectHelper
    {
        public static void createSubjectsTable()
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
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
                    [Prerequisite] NCHAR(255) NOT NULL,
                    [Units] INT NOT NULL,
                    PRIMARY KEY (ID)
                )";
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static void loadSubjects()
        {
            SubjectManager subjectManager = SubjectManager.getInstance();
            subjectManager.clear();
            SqlConnection connection = DatabaseHelper.getSystemConnection();
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

        public static void addSubject(Subject subject)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
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

        public static void removeSubject(Subject subject)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "DELETE FROM Subjects WHERE ID = @ID";
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", subject.ID);

                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void updateSubject(Subject subject)
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = "UPDATE Subjects SET Name = @Name, YearLevel = @YearLevel, Term = @Term, Prerequisite = @Prerequisite, Units = @Units WHERE ID = @ID";
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

        public static int getRecentSubjectID()
        {
            SqlConnection connection = DatabaseHelper.getSystemConnection();
            String query = @"SELECT IDENT_CURRENT ('Subjects')";
            int ID = 0;
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);

            ID = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return ID;
        }
    }
}
