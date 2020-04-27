using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FPY_Homework_Management.Classes;
using System.Data.SqlClient;
using System.Collections;

namespace FPY_Homework_Management
{
    public partial class Teacher_Assign_Students_To_Class : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void populateInClassTable()
        {
            ArrayList arrStudentsInClass = selectStudentsInClass();

            //for (int i = 0; i < arrStudentsInClass.Count; i++)
            //{
            //    Student s = new Student();
            //    ArrayList allStudentsInThisClass = new ArrayList();
            //    allStudentsInThisClass.Add(s.readSingleStudent(i.ToString()));
            //}

            string inClassQuery = "SELECT StudentID, StudentFirstName, StudentLastName, StudentDOB FROM Students WHERE StudentID IN (";
            for (int i = 0; i < arrStudentsInClass.Count; i++)
            {
                inClassQuery = inClassQuery + "'" + arrStudentsInClass[i].ToString() + "', ";
            }
            inClassQuery = inClassQuery + ")" + '"';

            ViewAllStudentsInClass.SelectCommand = inClassQuery;
        }


        public void populateNotInClassTable()
        {
            ArrayList arrStudentsInClass = selectStudentsNotInClass();

            string inClassQuery = "SELECT StudentID, StudentFirstName, StudentLastName, StudentDOB FROM Students WHERE StudentID IN (";
            for (int i = 0; i < arrStudentsInClass.Count; i++)
            {
                inClassQuery = inClassQuery + "'" + arrStudentsInClass[i].ToString() + "', ";
            }
            inClassQuery = inClassQuery + ")" + '"';

            ViewAllStudentsNotInClass.SelectCommand = inClassQuery;
        }



        public ArrayList selectStudentsInClass()
        {
            ArrayList arrAllInClass = new ArrayList();
            string query = "SELECT StudentsInClassID, StudentID, ClassID FROM StudentsInClass WHERE ClassID = @ClassID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ClassID", drpSelectTeacher.SelectedValue);

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                StudentsInClass stu = new StudentsInClass(re["StudentsInClassID"].ToString(), re["StudentID"].ToString(), re["ClassID"].ToString());
                arrAllInClass.Add(stu);
            }

            cmd.ExecuteNonQuery();                        
            conn.Close();
            return arrAllInClass;
        }


        public ArrayList selectStudentsNotInClass()
        {
            ArrayList arrAllNotInClass = new ArrayList();
            string query = "SELECT StudentsInClassID, StudentID, ClassID FROM StudentsInClass WHERE ClassID != @ClassID";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@ClassID", drpSelectTeacher.SelectedValue);

            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                StudentsInClass stu = new StudentsInClass(re["StudentsInClassID"].ToString(), re["StudentID"].ToString(), re["ClassID"].ToString());
                arrAllNotInClass.Add(stu);
            }

            cmd.ExecuteNonQuery();
            conn.Close();
            return arrAllNotInClass;
        }



    }
}