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
            lblSuccessMessage.Visible = false;
        }

        protected void btnAssignHomework_Click(object sender, EventArgs e)
        {
            string selectedHW = dropSelectHomework.SelectedValue.ToString();
            string selectedClass = drpSelectClass.SelectedValue.ToString();            
            string setByTeacher = "1";//logged in teacher ----------------------------------------------------------------------------------------------
            string timeToComplete = originalTimeToCompleteCopy();
            DateTime dueDate = Convert.ToDateTime(dueDateIn.Text);

            ArrayList studentsInSelectedClass = selectedClassStudentIDs(selectedClass);
            //ArrayList questionsInSelectedHomework = selectedHomeworkQuestionIDs(selectedHW);

            //create issued homework
            for (int i = 0; i < studentsInSelectedClass.Count; i++)
            {
                IssuedHomework newHW = new IssuedHomework(selectedHW, studentsInSelectedClass[i].ToString(), setByTeacher, timeToComplete, dueDate);
                newHW.createIssuedHomework();

            }

            ArrayList newIssuedHW = new ArrayList();
            IssuedHomework allIssHW = new IssuedHomework();
            ArrayList arrAllIssHW = allIssHW.readAllNewIssuedHomework();//

            //adds newest issued hw id's to arraylist
            for (int i = 0; i < studentsInSelectedClass.Count; i++)
            {
                int currentHWID = (arrAllIssHW.Count - 1) - i;
                newIssuedHW.Add(arrAllIssHW[currentHWID]);
            }


            //create questions for issued homework
            //Homework currentCoreHW = new Homework();
            //currentCoreHW = currentCoreHW.readSingleCoreHomework(selectedHW);


            string questionQuery = "SELECT * FROM CoreQuestions WHERE CoreHomeworkParent = " + selectedHW;
            //ArrayList selectedQuestions = new ArrayList();
            conn.Open();

            SqlCommand cmd = new SqlCommand(questionQuery, conn);
            //cmd.Parameters.AddWithValue("@id", selectedHW);
            SqlDataReader re = cmd.ExecuteReader();
            QuestionToAnswer newQ = new QuestionToAnswer();
            //ArrayList questionDetails = new ArrayList();
            //while (re.Read())
            //{                
            //    questionDetails.Add(new QuestionToAnswer { QuestionText = re["QuestionText"].ToString(), QuestionNumber = re["QuestionNumber"].ToString(), MarksForQuestion = re["MarksForQuestion"].ToString() });
            //}



            while (re.Read())
            {

                for (int i = 0; i < newIssuedHW.Count; i++)//homework count
                {
                //for (int q = 0; q < questionDetails.Count; q++)//question count
                //{
                //    QuestionToAnswer newQuestion = new QuestionToAnswer();
                //}
                //while (re.Read())
                //{
                    //questionDetails.Add(new QuestionToAnswer { IssuedHomeworkID = newIssuedHW[i].ToString(), QuestionText = re["QuestionText"].ToString(), QuestionNumber = re["QuestionNumber"].ToString(), MarksForQuestion = re["MarksForQuestion"].ToString() });
                    //newQ = new QuestionToAnswer(newIssuedHW[i].ToString(), re["QuestionToAnswer"].ToString(), re["QuestionNumber"].ToString(), re["MaximumMarksForQuestion"].ToString());
                    string IssuedHomeworkID, QuestionText, QuestionNumber, MarksForQuestion;
                    IssuedHomeworkID = newIssuedHW[i].ToString();
                    QuestionText = re["QuestionToAnswer"].ToString();
                    QuestionNumber = re["QuestionNumber"].ToString();
                    MarksForQuestion = re["MaximumMarksForQuestion"].ToString();

                    //int iHWID = Convert.ToInt32(IssuedHomeworkID);


                    //homework id in the questions to answer db table is now an int
                    //line 99 is where it breaks, if not line 100
                    //the hwid should be fine as a string but the conversion is breaking somwhere, making both sides an int didnt help (the string was referencing an int)
                    //

                    newQ = new QuestionToAnswer(IssuedHomeworkID, QuestionText, QuestionNumber, MarksForQuestion);
                    //newQ = new QuestionToAnswer(Convert.ToInt32(IssuedHomeworkID), QuestionText, QuestionNumber, MarksForQuestion);                    
                    newQ.createQuestionToAnswer();

                    
                }


                //while (re.Read())
                //{
                //    QuestionToAnswer newQ = new QuestionToAnswer(newIssuedHW[i].ToString(), re["QuestionText"].ToString(), re["QuestionNumber"].ToString(), re["MarksForQuestion"].ToString());
                //    selectedQuestions.Add(newQ);
                //}
            }
            conn.Close();




            //for (int i = 0; i < newIssuedHW.Count; i++)
            //{

            //}




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


        



    }
}