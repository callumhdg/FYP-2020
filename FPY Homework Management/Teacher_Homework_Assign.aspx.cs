using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FPY_Homework_Management.Classes;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace FPY_Homework_Management
{
    public partial class Teacher_Homework_Assign : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAssignHomework_Click(object sender, EventArgs e)
        {
            string selectedHW = dropSelectHomework.SelectedValue.ToString();
            string selectedClass = drpSelectClass.SelectedValue.ToString();

            ArrayList studentsInSelectedClass = selectedClassStudentIDs(selectedClass);
            ArrayList questionsInSelectedHomework = selectedHomeworkQuestionIDs(selectedHW);






        }

        public ArrayList selectedClassStudentIDs(string id)
        {
            ArrayList studentIDs = new ArrayList();
            string query = "SELECT StudentID FROM StudentsInClass WHERE ClassID = " + id;

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            try
            {
                while (re.Read())
                {
                    studentIDs.Add(re["StudentID"].ToString());
                }
            }
            catch
            { }

            conn.Close();
            return studentIDs;
        }

        
        public ArrayList selectedHomeworkQuestionIDs(string id)
        {
            ArrayList questionIDs = new ArrayList();
            string query = "SELECT CoreQuestionID FROM CoreQuestions WHERE CoreHomeworkParent " + id;

            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();

            try
            {
                while (re.Read())
                {
                    questionIDs.Add(re["CoreQuestionID"].ToString());
                }
            }
            catch
            { }

            conn.Close();
            return questionIDs;
        }








    }
}