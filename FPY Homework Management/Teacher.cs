using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class Teacher
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());


        public string teacherID { get; set; }

        public string teacherUsername { get; set; }

        public string teacherPassword { get; set; }



        public Teacher(string tID, string tUsername, string tPassword)
        {
            teacherID = tID;
            teacherUsername = tUsername;
            teacherPassword = tPassword;
            
        }

        public Teacher()
        {
        }



        public ArrayList readTeachers()
        {
            ArrayList allTeachers = new ArrayList();
            string query = "SELECT * from Teachers";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                Teacher teacher = new Teacher(re["TeacherID"].ToString(), re["TeacherUsername"].ToString(), re["TeacherPassword"].ToString());
                allTeachers.Add(teacher);
            }
            conn.Close();
            return allTeachers;
        }


        public Teacher readSingleTeacher(string id)
        {
            string query = "SELECT * from Teacher where TeacherID = @id";
            Teacher seclectedTeacher = new Teacher();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                seclectedTeacher = new Teacher(re["TeacherID"].ToString(), re["TeacherUsername"].ToString(), re["TeacherPassword"].ToString());
            }

            conn.Close();
            return seclectedTeacher;
        }


        public void createTeacher()
        {
            string query = "INSERT into Teachers (TeacherUsername, TeacherPassword) Values (@TeacherUsername, @TeacherPassword)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TeacherUsername", this.teacherUsername);
            cmd.Parameters.AddWithValue("@TeacherPassword", this.teacherPassword);

            cmd.ExecuteNonQuery();
            conn.Close();
        }











    }
}