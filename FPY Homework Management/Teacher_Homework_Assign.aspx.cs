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
        string userID, username;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { }

            username = Session["user"].ToString();
            userID = findTeacherID();

            lblErrorMessage.Visible = false;
            divErrorMessage.Visible = false;
            lblSuccessMessage.Visible = false;
            divSuccessMessage.Visible = false;
        }

        protected void btnAssignHomework_Click(object sender, EventArgs e)
        {
            string selectedHW = dropSelectHomework.SelectedValue.ToString();
            string selectedClass = drpSelectClass.SelectedValue.ToString();            
            string setByTeacher = userID;//logged in teacher ----------------------------------------------------------------------------------------------
            

            ArrayList studentsInSelectedClass = selectedClassStudentIDs(selectedClass);

            if (dueDateIn.Text != "")
            {

                string timeToComplete = originalTimeToCompleteCopy();
                DateTime dueDate = Convert.ToDateTime(dueDateIn.Text);

                //create issued homework
                for (int i = 0; i < studentsInSelectedClass.Count; i++)
                {
                    IssuedHomework newHW = new IssuedHomework(selectedHW, studentsInSelectedClass[i].ToString(), setByTeacher, timeToComplete, dueDate);
                    newHW.createIssuedHomework();

                }

                ArrayList newIssuedHW = new ArrayList();
                IssuedHomework allIssHW = new IssuedHomework();
                ArrayList arrAllIssHW = allIssHW.readAllNewIssuedHomework();

                //adds newest issued hw id's to arraylist
                for (int i = 0; i < studentsInSelectedClass.Count; i++)
                {
                    int currentHWID = (arrAllIssHW.Count - 1) - i;
                    newIssuedHW.Add(arrAllIssHW[currentHWID]);
                }

                string questionQuery = "SELECT * FROM CoreQuestions WHERE CoreHomeworkParent = " + selectedHW;
                //ArrayList selectedQuestions = new ArrayList();
                conn.Open();

                SqlCommand cmd = new SqlCommand(questionQuery, conn);
                //cmd.Parameters.AddWithValue("@id", selectedHW);
                SqlDataReader re = cmd.ExecuteReader();
                QuestionToAnswer newQ = new QuestionToAnswer();


                while (re.Read())
                {

                    for (int i = 0; i < newIssuedHW.Count; i++)//homework count
                    {
                        string IssuedHomeworkID, QuestionText, QuestionNumber, MarksForQuestion;
                        IssuedHomeworkID = newIssuedHW[i].ToString();
                        QuestionText = re["QuestionToAnswer"].ToString();
                        QuestionNumber = re["QuestionNumber"].ToString();
                        MarksForQuestion = re["MaximumMarksForQuestion"].ToString();

                        //homework id in the questions to answer db table is now an int
                        //line 99 is where it breaks, if not line 100
                        //the hwid should be fine as a string but the conversion is breaking somwhere, making both sides an int didnt help (the string was referencing an int)
                        //

                        newQ = new QuestionToAnswer(IssuedHomeworkID, QuestionText, QuestionNumber, MarksForQuestion);
                        newQ.createQuestionToAnswer();


                    }



                }

                conn.Close();
                dueDateIn.Text = "";

                lblErrorMessage.Visible = false;
                divErrorMessage.Visible = false;
                lblSuccessMessage.Visible = true;
                divSuccessMessage.Visible = true;

            }
            else
            {

                lblErrorMessage.Visible = true;
                divErrorMessage.Visible = true;
                lblSuccessMessage.Visible = false;
                divSuccessMessage.Visible = false;

            }

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
            string query = "SELECT CoreQuestionID FROM CoreQuestions WHERE CoreHomeworkParent = " + id;

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


        public string originalTimeToCompleteCopy()
        {
            string selectedHW = dropSelectHomework.SelectedValue.ToString();
            string ttc = "";

            //Homework hw = new Homework();
            string query = "SELECT MinutesToComplete from CoreHomework where CoreHomeworkID = @id";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", selectedHW);
            SqlDataReader re = cmd.ExecuteReader();

            while (re.Read())
            {
                ttc = re["MinutesToComplete"].ToString();
            }

            conn.Close();
            return ttc;
        }

        protected string findTeacherID()
        {

            string query = "SELECT TeacherID from Teachers where TeacherUsername = '" + username + "'";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();
            string id = "";

            while (re.Read())
            {
                id = re["TeacherID"].ToString();
            }

            conn.Close();
            return id;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }


    }
}