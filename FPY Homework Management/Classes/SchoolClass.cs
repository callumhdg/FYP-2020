using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management.Classes
{
    public class SchoolClass
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        public string clsID { get; set; }
        public string clsTeachID { get; set; }
        public string clsSubj { get; set; }
        public string clsYe { get; set; }


        public SchoolClass(string cID, string cTeacher, string cSubject, string cYear)
        {
            clsID = cID;
            clsTeachID = cTeacher;
            clsSubj = cSubject;
            clsYe = cYear;
        }

        public SchoolClass(string cTeacher, string cSubject, string cYear)
        {
            clsTeachID = cTeacher;
            clsSubj = cSubject;
            clsYe = cYear;
        }

        public SchoolClass()
        { }



        public ArrayList readAllClasses()
        {
            ArrayList allClasses = new ArrayList();
            string query = "SELECT * from Class";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                SchoolClass cls = new SchoolClass(re["ClassID"].ToString(), re["ClassTeacherID"].ToString(), re["ClassSubject"].ToString(), re["ClassYearGroup"].ToString());
                allClasses.Add(cls);
            }

            conn.Close();
            return allClasses;
        }



        public SchoolClass readSingleSchoolClass(string id)
        {
            string query = "SELECT * from Class where ClassID = @id";
            SchoolClass selectedSchoolClass = new SchoolClass();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                selectedSchoolClass = new SchoolClass(re["ClassID"].ToString(), re["ClassTeacherID"].ToString(), re["ClassSubject"].ToString(), re["ClassYearGroup"].ToString());
            }

            conn.Close();
            return selectedSchoolClass;
        }



        public void createSchoolClass()
        {
            //string query = "INSERT into Class (ClassID, ClassTeacherID, ClassSubject, ClassYearGroup) VALUES (@ClassID, @ClassTeacherID, @ClassSubject, @ClassYearGroup)";
            string query = "INSERT into Class (ClassTeacherID, ClassSubject, ClassYearGroup) VALUES (@ClassTeacherID, @ClassSubject, @ClassYearGroup)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("ClassID", this.clsID);
            cmd.Parameters.AddWithValue("ClassTeacherID", this.clsTeachID);
            cmd.Parameters.AddWithValue("ClassSubject", this.clsSubj);
            cmd.Parameters.AddWithValue("ClassYearGroup", this.clsYe);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


                                    
        






    }
}