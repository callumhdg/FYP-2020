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
        public string clsName { get; set; }
        

        public SchoolClass(string cID, string cTeacher, string cSubject, string cYear, string cName)
        {
            clsID = cID;
            clsTeachID = cTeacher;
            clsSubj = cSubject;
            clsYe = cYear;
            clsName = cName;
        }

        public SchoolClass(string cTeacher, string cSubject, string cYear, string cName)
        {
            clsTeachID = cTeacher;
            clsSubj = cSubject;
            clsYe = cYear;
            clsName = cName;
        }
        public SchoolClass(string cName)
        {
            clsName = cName;
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
                SchoolClass cls = new SchoolClass(re["ClassID"].ToString(), re["ClassTeacherID"].ToString(), re["ClassSubject"].ToString(), re["ClassYearGroup"].ToString(), re["ClassName"].ToString());
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
                selectedSchoolClass = new SchoolClass(re["ClassID"].ToString(), re["ClassTeacherID"].ToString(), re["ClassSubject"].ToString(), re["ClassYearGroup"].ToString(), re["ClassName"].ToString());
            }

            conn.Close();
            return selectedSchoolClass;
        }


                     
        public ArrayList readClassNames()
        {
            ArrayList allClassNames = new ArrayList();
            string query = "SELECT ClassName from Class";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                SchoolClass cls = new SchoolClass(re["ClassName"].ToString());
                allClassNames.Add(cls);
            }
            conn.Close();
            return allClassNames;
        }


                     
        public void createSchoolClass()
        {
            //string query = "INSERT into Class (ClassID, ClassTeacherID, ClassSubject, ClassYearGroup) VALUES (@ClassID, @ClassTeacherID, @ClassSubject, @ClassYearGroup)";
            string query = "INSERT into Class (ClassTeacherID, ClassSubject, ClassYearGroup, ClassName) VALUES (@ClassTeacherID, @ClassSubject, @ClassYearGroup, @ClassName)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("ClassID", this.clsID);
            cmd.Parameters.AddWithValue("@ClassTeacherID", this.clsTeachID);
            cmd.Parameters.AddWithValue("@ClassSubject", this.clsSubj);
            cmd.Parameters.AddWithValue("@ClassYearGroup", this.clsYe);
            cmd.Parameters.AddWithValue("@ClassName", this.clsName);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


                                    
        






    }
}