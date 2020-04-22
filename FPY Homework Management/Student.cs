using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace FPY_Homework_Management.Classes
{
    public class Student
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string studentID { get; set; }
        public string studentUsername { get; set; }
        public string studentPassword { get; set; }
        public string studentFirstName { get; set; }
        public string studentLastName { get; set; }
        public string studentParEmail { get; set; }
        public DateTime studentDOB { get; set; }


        public Student(string sID, string sFirstName, string sLastName, string sUsername, string sPassword, string sParEmail, DateTime sDOB)
        {
            studentID = sID;
            studentFirstName = sFirstName;
            studentLastName = sLastName;
            studentUsername = sUsername;
            studentPassword = sPassword;
            studentParEmail = sParEmail;
            studentDOB = sDOB;
        }

        public Student(string sFirstName, string sLastName, string sUsername, string sPassword, string sParEmail, DateTime sDOB)
        {
            studentFirstName = sFirstName;
            studentLastName = sLastName;
            studentUsername = sUsername;
            studentPassword = sPassword;
            studentParEmail = sParEmail;
            studentDOB = sDOB;
        }

        public Student(string sUsername)
        {
            studentUsername = sUsername;
        }

        public Student()
        {
        }

        public ArrayList readStudents()
        {
            ArrayList allStudents = new ArrayList();
            string query = "SELECT * from Students";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Student student = new Student(re["StudentID"].ToString(), re["StudentFirstName"].ToString(), re["StudentLastName"].ToString(), re["StudentUsername"].ToString(), re["StudentPassword"].ToString(), re["ParentEmailAddress"].ToString(), Convert.ToDateTime(re["StudentDOB"]));
                allStudents.Add(student);
            }
            conn.Close();
            return allStudents;
        }


        public ArrayList readStudentUsernames()
        {
            ArrayList allTUsernames = new ArrayList();
            string query = "SELECT StudentUsername from Students";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Student student = new Student(re["StudentUsername"].ToString());
                allTUsernames.Add(student);
            }
            conn.Close();
            return allTUsernames;
        }



        public Student readSingleStudent(string id)
        {
            string query = "SELECT * from Student where StudentID = @id";
            Student seclectedStudent = new Student();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                seclectedStudent = new Student(re["StudentID"].ToString(), re["StudentFirstName"].ToString(), re["StudentLastName"].ToString(), re["StudentUsername"].ToString(), re["StudentPassword"].ToString(), re["ParentEmailAddress"].ToString(), Convert.ToDateTime(re["StudentDOB"]));
            }

            conn.Close();
            return seclectedStudent;
        }


        public void createStudent()
        {
            string query = "INSERT into Students (StudentFirstName, StudentLastName, StudentUsername, StudentPassword, ParentEmailAddress, StudentDOB) VALUES (@StudentFirstName, @StudentLastName, @StudentUsername, @StudentPassword, @ParentEmailAddress, @StudentDOB)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@StudentUsername", this.studentUsername);
            cmd.Parameters.AddWithValue("@StudentPassword", this.studentPassword);
            cmd.Parameters.AddWithValue("@StudentFirstName", this.studentFirstName);
            cmd.Parameters.AddWithValue("@StudentLastName", this.studentLastName);
            cmd.Parameters.AddWithValue("@ParentEmailAddress", this.studentParEmail);
            cmd.Parameters.AddWithValue("@StudentDOB", this.studentDOB);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public ArrayList findStudentsByYear(string dob)
        {
            ArrayList yearStudents = new ArrayList();
            ArrayList allStudents = new ArrayList();
            string query = "";

            Student student = new Student();
            allStudents = student.readStudents();

            //todays date - dob = year group




            return yearStudents;
        }




    }
}