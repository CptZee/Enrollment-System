using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Enrollment_System.Data;

namespace Enrollment_System.Util
{
    class SubjectsHelper
    {
        private static SqlConnection GetConnection()
        {
            return DatabaseHelper.GetConnection();
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

        public static DataSet getSubjects()
        {

            String select = "SELECT * FROM Subjects";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, GetConnection());

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
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
    }
}
