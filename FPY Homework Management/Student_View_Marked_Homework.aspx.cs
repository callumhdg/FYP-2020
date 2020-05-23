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
    public partial class Student_View_Marked_Homework : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PRCO304_CHarding"].ToString());
        string username, userID, hwID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["SelectedHomework"] == null)
            {
                Response.Redirect("Student_Home.aspx");
            }
            else { }

            username = Session["user"].ToString();
            userID = findStudentID();

            hwID = Session["SelectedHomework"].ToString();

            hideAllQuestions();
            fillAnswers();
        }

        protected void btnReturnHome_Click(object sender, EventArgs e)
        {
            Session["SelectedHomework"] = null;


            Response.Redirect("Student_Home.aspx");
        }

        protected string findStudentID()
        {

            string query = "SELECT StudentID from Students where StudentUsername = '" + username + "'";
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader re = cmd.ExecuteReader();
            string id = "";

            while (re.Read())
            {
                id = re["StudentID"].ToString();
            }

            conn.Close();
            return id;
        }


        public void hideAllQuestions()
        {
            q1Conainer.Visible = false;
            q2Conainer.Visible = false;
            q3Conainer.Visible = false;
            q4Conainer.Visible = false;
            q5Conainer.Visible = false;
            q6Conainer.Visible = false;
            q7Conainer.Visible = false;
            q8Conainer.Visible = false;
            q9Conainer.Visible = false;
            q10Conainer.Visible = false;
        }


        private void fillAnswers()
        {
            ArrayList allSelectedQuestions = new ArrayList();
            QuestionToAnswer question = new QuestionToAnswer();
            allSelectedQuestions = question.readSelectedQuestionInHomework(hwID);



            if (allSelectedQuestions.Count == 1)
            {
                fillAnswer1();
            }
            else if (allSelectedQuestions.Count == 2)
            {
                fillAnswer1();
                fillAnswer2();
            }
            else if (allSelectedQuestions.Count == 3)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
            }
            else if (allSelectedQuestions.Count == 4)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
            }
            else if (allSelectedQuestions.Count == 5)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
            }
            else if (allSelectedQuestions.Count == 6)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
            }
            else if (allSelectedQuestions.Count == 7)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
            }
            else if (allSelectedQuestions.Count == 8)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
                fillAnswer8();
            }
            else if (allSelectedQuestions.Count == 9)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
                fillAnswer8();
                fillAnswer9();
            }
            else if (allSelectedQuestions.Count == 10)
            {
                fillAnswer1();
                fillAnswer2();
                fillAnswer3();
                fillAnswer4();
                fillAnswer5();
                fillAnswer6();
                fillAnswer7();
                fillAnswer8();
                fillAnswer9();
                fillAnswer10();
            }
            else { }
        }


                                   
        private void fillAnswer1()
        {
            q1Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "1");

            q1Text.InnerText = thisQuestion.QuestionText;

            txtQ1Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            //txtQ1StudentAnswer.Text = thisQuestion.getAnswer(thisQuestion.QuestionToAnswerID);
            txtQ1StudentAnswer.Text = thisQuestion.Answer;

            txtQ1Feedback.Text = thisQuestion.Feedback;

        }



        private void fillAnswer2()
        {
            q2Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "2");

            q2Text.InnerText = thisQuestion.QuestionText;

            txtQ2Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ2StudentAnswer.Text = thisQuestion.Answer;

            txtQ2Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer3()
        {
            q3Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "3");

            q3Text.InnerText = thisQuestion.QuestionText;

            txtQ3Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ3StudentAnswer.Text = thisQuestion.Answer;

            txtQ3Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer4()
        {
            q4Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "4");

            q4Text.InnerText = thisQuestion.QuestionText;

            txtQ4Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ4StudentAnswer.Text = thisQuestion.Answer;

            txtQ4Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer5()
        {
            q5Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "5");

            q5Text.InnerText = thisQuestion.QuestionText;

            txtQ5Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ5StudentAnswer.Text = thisQuestion.Answer;

            txtQ5Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer6()
        {
            q6Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "6");

            q6Text.InnerText = thisQuestion.QuestionText;

            txtQ6Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ6StudentAnswer.Text = thisQuestion.Answer;

            txtQ6Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer7()
        {
            q7Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "7");

            q7Text.InnerText = thisQuestion.QuestionText;

            txtQ7Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ7StudentAnswer.Text = thisQuestion.Answer;

            txtQ7Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer8()
        {
            q8Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "8");

            q8Text.InnerText = thisQuestion.QuestionText;

            txtQ8Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ8StudentAnswer.Text = thisQuestion.Answer;

            txtQ8Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer9()
        {
            q9Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "9");

            q9Text.InnerText = thisQuestion.QuestionText;

            txtQ9Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ9StudentAnswer.Text = thisQuestion.Answer;

            txtQ9Feedback.Text = thisQuestion.Feedback;

        }


        private void fillAnswer10()
        {
            q10Conainer.Visible = true;

            QuestionToAnswer thisQuestion = new QuestionToAnswer();
            thisQuestion = thisQuestion.readMarkedQuestion(hwID, "10");

            q10Text.InnerText = thisQuestion.QuestionText;

            txtQ10Marks.InnerText = "You achived:  " + thisQuestion.Results + " / " + thisQuestion.MarksForQuestion;
            txtQ10StudentAnswer.Text = thisQuestion.Answer;

            txtQ10Feedback.Text = thisQuestion.Feedback;

        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["SelectedHomework"] = null;

            Response.Redirect("Login.aspx");
        }


        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["SelectedHomework"] = null;

            Response.Redirect("Student_Home.aspx");
        }

    }
}