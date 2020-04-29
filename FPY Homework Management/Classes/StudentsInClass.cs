using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace FPY_Homework_Management.Classes
{
    public class StudentsInClass
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string studentsClassID { get; set; }
        public string classID { get; set; }
        public string studentID { get; set; }


        public StudentsInClass(string stuClsID, string clsID, string stuID)
        {
            studentsClassID = stuClsID;
            classID = clsID;
            studentID = stuID;
        }

        public StudentsInClass(string clsID, string stuID)
        {
            classID = clsID;
            studentID = stuID;
        }

        public StudentsInClass()
        { }



        public ArrayList readStudentClassList()
        {
            ArrayList allStudentClassListings = new ArrayList();
            string query = "SELECT * from StudentsInClass";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                StudentsInClass clsListings = new StudentsInClass(re["StudentsInClassID"].ToString(), re["ClassID"].ToString(), re["StudentID"].ToString());
                allStudentClassListings.Add(clsListings);
            }

            return allStudentClassListings;
        }



        public void createStudentClassListing()
        {
            //string query = "INSERT into StudentsInClass (StudentsInClassID, ClassID, StudentID) VALUES (@StudentsInClassID, @ClassID, @StudentID)";
            string query = "INSERT into StudentsInClass (ClassID, StudentID) VALUES (@ClassID, @StudentID)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("@StudentsInClassID", this.studentsClassID);
            cmd.Parameters.AddWithValue("@ClassID", this.classID);
            cmd.Parameters.AddWithValue("@StudentID", this.studentID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void removeStudentFromClass(string id)
        {
            string query = "DELETE FROM StudentsInClass WHERE StudentID = @StudentID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@StudentID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


    



    }
}